using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Accord.Imaging;
using Accord.Imaging.Converters;
using Accord.Imaging.Filters;
using Accord.MachineLearning;
using Accord.Math;
using Accord.Statistics.Distributions.DensityKernels;
using AForge.Imaging.Filters;
using System.IO.Compression;
using AForge.Imaging;
using AccordTests.SLIC;
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Statistics.Kernels;
using System.Threading;
using System.IO;
using System.Text;

namespace AccordTests
{
    public enum MaskTypes { Background,  Foreground,  Unknown };


    public partial class MainForm : Form
    {
        private Bitmap image;
        private Bitmap segmentedImage;
        OpenFileDialog openFileDialog;
        OpenFileDialog openFileDialogMulti;

        Bitmap[] loadedImages;
        Bitmap[] testImages;
        Bitmap[] trimapImages;
        Bitmap[] testTrimapImages;
        double[][] features;
        double[][] origFeatures;
        int[] outputs;

        public MainForm()
        {
            InitializeComponent();

            Utils.InitSystemSeparators();

            string openFileDialogFilter = "Graphics types|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tif;*.tiff" + "|BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff";
            openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = openFileDialogFilter;


            openFileDialogMulti = new OpenFileDialog();
            openFileDialogMulti.Multiselect = true;
            openFileDialogMulti.Filter = openFileDialogFilter;

        }

        private void loadPictureBtn_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            loadedImages = GetImagesSet(openFileDialog.FileName);

            if (!File.Exists(GetTrimapPath(openFileDialog.FileName)))
            {
                MessageBox.Show("The corresponding trimap image does not exist. Try to load another image.");
                return;
            }

            trimapImages = GetTrimapImagesSet(openFileDialog.FileName);

            image = loadedImages[0];// GetImageDownscaled(loadedImage);

            workingImagePictureBox.Image = image;

          
        }

     

        private void detectCornersBtn_Click(object sender, EventArgs e)
        {
            FastCornersDetector fast = new FastCornersDetector()
            {
                Threshold = fastDetectCornersThreshTrackBar.Value
            };

            CornersMarker corners = new CornersMarker(fast, Color.White);

            workingImagePictureBox.Image = corners.Apply(image);
        }

        private void harrisDetectCornersBtn_Click(object sender, EventArgs e)
        {
            double sigma = 1.4;
            float k = 0.04f;
            float threshold = (float)harrisDetectCornersThreshTrackBar.Value;

            HarrisCornersDetector harris = new HarrisCornersDetector(k)
            {
                Measure = HarrisCornerMeasure.Harris,
                Threshold = threshold,
                Sigma = sigma
            };

            CornersMarker corners = new CornersMarker(harris, Color.White);

            workingImagePictureBox.Image = corners.Apply(image);
        }

        private void surfDetectCornersBtn_Click(object sender, EventArgs e)
        {
            float threshold = ((float)surfDetectCornersThreshTrackBar.Value) / 10000;
            int octaves = 5;
            int initial = 2;

            SpeededUpRobustFeaturesDetector surf =
                new SpeededUpRobustFeaturesDetector(threshold, octaves, initial);

            List<SpeededUpRobustFeaturePoint> points = surf.ProcessImage(image);

            FeaturesMarker features = new FeaturesMarker(points);

            workingImagePictureBox.Image = features.Apply(image);
        }

        private void meanShiftBtn_Click(object sender, EventArgs e)
        {
            int pixelSize = 3;   // RGB color pixel
            double sigma = 0.1; // kernel bandwidth

            sigma = (double)meanShiftSigmaTrackBar.Value / 100;

            // Load a test image (shown below)
            //  Bitmap image = ...

            // Create converters
            ImageToArray imageToArray = new ImageToArray(min: -1, max: +1);
            ArrayToImage arrayToImage = new ArrayToImage(image.Width, image.Height, min: -1, max: +1);

            // Transform the image into an array of pixel values
            double[][] pixels;
            imageToArray.Convert(image, out pixels);

            // Create a MeanShift algorithm using given bandwidth
            //   and a Gaussian density kernel as kernel function.
            MeanShift meanShift = new MeanShift(pixelSize, new GaussianKernel(3), sigma);


            // Compute the mean-shift algorithm until the difference in
            //  shifting means between two iterations is below 0.05
            int[] idx = meanShift.Compute(pixels, 0.05, maxIterations: 10);


            // Replace every pixel with its corresponding centroid
            pixels.ApplyInPlace((x, i) => meanShift.Clusters.Modes[idx[i]]);

            // Retrieve the resulting image in a picture box
            Bitmap result;
            arrayToImage.Convert(pixels, out result);
            resultImagePictureBox.Image = result;
        }

        private void kMeansBtn_Click(object sender, EventArgs e)
        {
            int k = 5;
            k = kMeansKTrackBar.Value;

            // Create converters
            ImageToArray imageToArray = new ImageToArray(min: -1, max: +1);
            ArrayToImage arrayToImage = new ArrayToImage(image.Width, image.Height, min: -1, max: +1);

            // Transform the image into an array of pixel values
            double[][] pixels; imageToArray.Convert(image, out pixels);

            // Create a K-Means algorithm using given k and a
            //  square Euclidean distance as distance metric.
            KMeans kmeans = new KMeans(k, Distance.SquareEuclidean);

            // Compute the K-Means algorithm until the difference in
            //  cluster centroids between two iterations is below 0.05
            kmeans.Tolerance = 0.05;
            int[] idx = kmeans.Compute(pixels);


            // Replace every pixel with its corresponding centroid
            pixels.ApplyInPlace((x, i) => kmeans.Clusters.Centroids[idx[i]]);

            // Retrieve the resulting image in a picture box
            Bitmap result; arrayToImage.Convert(pixels, out result);
            resultImagePictureBox.Image = result;
        }

        SLICMethod slic;
        Segment[] Segments;
        Pixel[,] Pixels;
  
        private void SLICBtn_Click(object sender, EventArgs e)
        {
            slic = new SLICMethod(SLICTrackBar.Value, spatialConsTrackBar.Value, ColorSpaceType.Lab);
            slic.ShowEdges = applyEdgesChkBox.Checked;
            slic.ShowRandomColorSegments = randomColorSegmentsChkBox.Checked;

            segmentedImage = slic.Segment(image);
            resultImagePictureBox.Image = segmentedImage;

            Segments = slic.Segments;
            Pixels = slic.Pixels;

            foreach (var segment in Segments)
            {
                segment.FormFeatures();
            }
        }

       

        private void spatialConsTrackBar_Scroll(object sender, EventArgs e)
        {
            spatialConsistencyLabel.Text = spatialConsTrackBar.Value.ToString();
        }

        private void SLICTrackBar_Scroll(object sender, EventArgs e)
        {
            noSegmentsLabel.Text = SLICTrackBar.Value.ToString();
        }

        private void AttachLabelToSegment(Segment[] segments, Bitmap triImage)
        {
            Pixels5DimConverterRgbSpace rgbConverter = new Pixels5DimConverterRgbSpace();
            Pixel[,] trimapPixels = rgbConverter.GetPixels2(triImage);

            foreach (var segment in Segments)
            {
                int cntBG = 0;
                int cntFG = 0;
                int cntUNK = 0;

                foreach (var pixel in segment.Pixels)
                {
                    int x = pixel.Point.X;
                    int y = pixel.Point.Y;
                    MyRGB trimapPixColor = trimapPixels[x, y].Color;
                    if (trimapPixColor.R == 0 && trimapPixColor.G == 0 && trimapPixColor.B == 0)
                        cntUNK++;
                    else if (trimapPixColor.R == 1 && trimapPixColor.G == 1 && trimapPixColor.B == 1)
                        cntFG++;
                    else if (trimapPixColor.R == 3 && trimapPixColor.G == 3 && trimapPixColor.B == 3)
                        cntBG++;
                    else
                        cntUNK++;
                }

                if (cntBG > cntFG && cntBG > cntUNK)
                    segment.MaskType = MaskTypes.Background;
                if (cntFG > cntBG && cntFG > cntUNK)
                    segment.MaskType = MaskTypes.Foreground;
                if (cntUNK > cntFG && cntUNK > cntBG)
                    segment.MaskType = MaskTypes.Unknown;

                foreach (var item in segment.Pixels)
                {
                    item.MaskType = segment.MaskType;
                }
            }
        }       
       

        KernelSupportVectorMachine machine;

        private double EliminateBckg(Bitmap image, Bitmap triImage)
        {
            SegmentAndAttachLabels(image, triImage);

            int cntAllRight = 0;
            int cntUnionForeground = 0;

            foreach (var segment in Segments)
            {
                segment.FormFeatures();

                //double featureVec =  Accord.Statistics.Tools.ZScores(segment.FeatureVec, means, stdDev);

                double[] featureVec = new double[segment.FeatureVec.Length];
                segment.FeatureVec.CopyTo(featureVec, 0);


                //   Accord.Statistics.Tools.Center(featureVec, means);
                //for (int i = 0; i < featureVec.Length; i++)
                //{
                //    featureVec[i] += means[i];
                //}
                //  featureVec = Accord.Statistics.Tools.Standardize(stdDev);


                //featureVec = Accord.Statistics.Tools.Standardize(featureVec);





                double[][] newFeatures = new double[origFeatures.Length + 1][];
                for (int i = 0; i < origFeatures.Length; i++)
                {
                    newFeatures[i] = origFeatures[i];
                }
                newFeatures[origFeatures.Length] = featureVec;

                newFeatures = Accord.Statistics.Tools.ZScores(newFeatures);
                featureVec = newFeatures[origFeatures.Length];

                int FGPix = Math.Sign(machine.Compute(featureVec));
                foreach (var item in segment.Pixels)
                {
                    if (FGPix == -1)
                        item.Color = new MyRGB(0, 0, 0);
                }

                // int FGPix = Math.Sign(machine.Compute(Segments[i].FeatureVec));
                //if ((FGPix == 1 && segment.MaskType == MaskTypes.Foreground) ||
                //    (FGPix == -1 && (segment.MaskType == MaskTypes.Background || segment.MaskType == MaskTypes.Unknown)))
                //    cntAllRight++;

                if (FGPix == 1 && segment.MaskType == MaskTypes.Foreground)
                    cntAllRight++;

                if (FGPix == 1 || segment.MaskType == MaskTypes.Foreground)
                    cntUnionForeground++;
            }

            Pixels5DimConverterRgbSpace converter = new Pixels5DimConverterRgbSpace();
            Bitmap segmImage = converter.GetImage2(Pixels);
            resultImagePictureBox.Image = segmImage;

            //int cntAllRight = 0;
            //for (int i = 0; i < Segments.Length; i++)
            //{
              
            //}

            return (double)cntAllRight/cntUnionForeground ;
        }

        private void SegmentFGBGBtn_Click(object sender, EventArgs e)
        {
            double result = EliminateBckg(image, trimapImages[0]);

            FGBGErrorLabel.Text = result.ToString();
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialogMulti.ShowDialog();


            int noTrimapFiles = 0;
            for (int i = 0; i < openFileDialogMulti.FileNames.Length; i++)
            {
                string fileName = openFileDialogMulti.FileNames[i];
                if (File.Exists(GetTrimapPath(fileName)))
                    noTrimapFiles++;
            }

            Console.WriteLine("No. available trimaps: " + noTrimapFiles.ToString());

            string[] existingFileNames = new string[noTrimapFiles];
            int ind = 0;
            for (int i = 0; i < openFileDialogMulti.FileNames.Length; i++)
            {
                string fileName = openFileDialogMulti.FileNames[i];
                if (File.Exists(GetTrimapPath(fileName)))
                {
                    existingFileNames[ind] = fileName;
                    ind++;
                }
            }

            loadedImages = GetImagesSet(existingFileNames);
            trimapImages = GetTrimapImagesSet(existingFileNames);         
        }

        Bitmap[] GetImagesSet(string[] imageFileNames)
        {
            Bitmap[] ImagesArr = new Bitmap[imageFileNames.Length];

            for (int i = 0; i < imageFileNames.Length; i++)
            {
                ImagesArr[i] = new Bitmap(imageFileNames[i]);
            }

            return ImagesArr;
        }

        Bitmap[] GetImagesSet(string imageFileName)
        {
            string[] imageFileNames = new string[1];
            imageFileNames[0] = imageFileName;
            return GetImagesSet(imageFileNames);
        }

        Bitmap[] GetTrimapImagesSet(string[] imageFileNames)
        {
            Bitmap[] ImagesArr = new Bitmap[imageFileNames.Length];

            for (int i = 0; i < imageFileNames.Length; i++)
            {
                string trimapImagePath = GetTrimapPath(imageFileNames[i]);
                ImagesArr[i] = new Bitmap(trimapImagePath);
            }

            return ImagesArr;
        }

        string GetTrimapPath(string imageFileName)
        {
            return imageFileName.Replace("samples", "trimaps\\trimaps").Replace(".jpg", ".png");
        }

        Bitmap[] GetTrimapImagesSet(string imageFileName)
        {
            string[] imageFileNames = new string[1];
            imageFileNames[0] = imageFileName;
            return GetTrimapImagesSet(imageFileNames);
        }

        private void SegmentAndAttachLabels(Bitmap image, Bitmap triImage)
        {
            slic = new SLICMethod(SLICTrackBar.Value, spatialConsTrackBar.Value, ColorSpaceType.Lab);
            slic.ShowEdges = applyEdgesChkBox.Checked;
            slic.ShowRandomColorSegments = randomColorSegmentsChkBox.Checked;

            segmentedImage = slic.Segment(image);
            resultImagePictureBox.Image = segmentedImage;

            Segments = slic.Segments;
            Pixels = slic.Pixels;

            AttachLabelToSegment(Segments, triImage);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int noFeatures = loadedImages.Length * SLICTrackBar.Value;
            features = new double[noFeatures][];
            outputs = new int[noFeatures];
            int featureNo = 0;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();

            string filePath = sfd.FileName;
            int noVectors = features.Length;

            using (var sw = new StreamWriter(filePath))
            {
                sw.WriteLine(noVectors.ToString());


                for (int i = 0; i < loadedImages.Length; i++)
                {
                    Bitmap curImage = loadedImages[i];
                    Bitmap curTriImage = trimapImages[i];

                    workingImagePictureBox.Image = curImage;
                    Refresh();

                    SegmentAndAttachLabels(curImage, curTriImage);

                    foreach (var segment in Segments)
                    {
                        segment.FormFeatures();

                        features[featureNo] = segment.FeatureVec;

                        if (segment.MaskType == MaskTypes.Foreground)
                            outputs[featureNo] = 1;
                        else outputs[featureNo] = -1;

                        double[] feat = features[featureNo];
                        for (int j = 0; j < feat.Length; j++)
                        {
                            sw.Write(feat[j].ToString("N3") + ";");
                        }
                        sw.WriteLine(outputs[featureNo].ToString());

                        featureNo++;
                    }
                }






             
            }



          
        
        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            double kernelSigma = Utils.Str2Dbl(KernelSigmaTxtBox.Text);
            double complexity = Utils.Str2Dbl(ComplexityTxtBox.Text);
            TrainSVM(kernelSigma, complexity);
        }

        private void TrainSVM(double kernelSigma, double complexity)
        {
            Gaussian kernel = new Gaussian();
            kernel.Gamma = kernelSigma;
            //Gaussian kernel = Gaussian.Estimate(features);

            machine = new KernelSupportVectorMachine(kernel, features[0].Length);
            

            SequentialMinimalOptimization smo = new SequentialMinimalOptimization(machine, features, outputs);

            smo.Complexity = complexity;
            smo.Tolerance = 0.2;


            // smo.UseComplexityHeuristic = true;

            if (features.Length > 4000)
                smo.CacheSize = features.Length / 20;

            bool trained = false;

            // Run
            try
            {
                double error = smo.Run();
                //MessageBox.Show("SVM Trained");
                trained = true;
            }
            catch
            {
              //  MessageBox.Show("SVM Fail");
            }


            if (trained)
            {
                int cntAllRight = 0;
                int cntUnionForegrounds = 0;
                for (int i = 0; i < features.Length; i++)
                {
                    int FGPix = Math.Sign(machine.Compute(features[i]));

                    if (FGPix == 1 && outputs[i] == 1)
                        cntAllRight++;

                    if (FGPix == 1 || outputs[i] == 1)
                        cntUnionForegrounds++;
                }

                double LearnErr = (double)cntAllRight / cntUnionForegrounds;
                LearnErrLabel.Text = LearnErr.ToString("N3");

                cntAllRight = 0;
                cntUnionForegrounds = 0;
                for (int i = 0; i < validationFeatures.Length; i++)
                {
                    int FGPix = Math.Sign(machine.Compute(validationFeatures[i]));

                    if (FGPix == 1 && validationOutputs[i] == 1)
                        cntAllRight++;

                    if (FGPix == 1 || validationOutputs[i] == 1)
                        cntUnionForegrounds++;
                }

                double ValidErr = (double)cntAllRight / cntUnionForegrounds;
                ValidationErrLabel.Text = ValidErr.ToString("N3");

                if (testingFeatures != null)
                {
                    cntAllRight = 0;
                    cntUnionForegrounds = 0;
                    for (int i = 0; i < testingFeatures.Length; i++)
                    {
                        int FGPix = Math.Sign(machine.Compute(testingFeatures[i]));

                        if (FGPix == 1 && testingOutputs[i] == 1)
                            cntAllRight++;

                        if (FGPix == 1 || testingOutputs[i] == 1)
                            cntUnionForegrounds++;
                    }

                    double TestErr = (double)cntAllRight / cntUnionForegrounds;
                    TestingErrLabel.Text = TestErr.ToString("N3");
                }

                // Console.WriteLine(machine.SupportVectors.Length.ToString() + " support vectors");

                string output = "Sigma: " + kernelSigma.ToString() + ", complexity: " + complexity.ToString() + " - " + LearnErr.ToString() + " " + ValidErr.ToString();
                Console.WriteLine(output);
                sb.AppendLine(output);

               

                
            }
        }

        StringBuilder sb = new StringBuilder();

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialogMulti.ShowDialog();
            testImages = GetImagesSet(openFileDialogMulti.FileNames);
            testTrimapImages = GetTrimapImagesSet(openFileDialogMulti.FileNames);
        }


        private void button7_Click(object sender, EventArgs e)
        {
            int noFeatures = testImages.Length * SLICTrackBar.Value;
            double resultCum = 0;     
            //int cntAllRight_alltestImages = 0;

            for (int i = 0; i < testImages.Length; i++)
            {
                Bitmap curImage = testImages[i];
                Bitmap curTriImage = testTrimapImages[i];

                workingImagePictureBox.Image = curImage;
                Refresh();

                double result = EliminateBckg(curImage, curTriImage);
                resultCum += result;
               // cntAllRight_alltestImages += cntAllRight;

                Console.WriteLine(result.ToString());
            }

            ValidationErrLabel.Text = (resultCum / testImages.Length).ToString();
        }


        public void SaveFeatures()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();

            string filePath = sfd.FileName;
            int noVectors = features.Length;

            using (var sw = new StreamWriter(filePath))
            {
                sw.WriteLine(noVectors.ToString());

                for (int i = 0; i < features.Length; i++)
                {
                    double[] feat = features[i];

                    for (int j = 0; j < feat.Length; j++)
                    {
                        sw.Write(feat[j].ToString() + ";");
                    }

                    sw.WriteLine(outputs[i].ToString());
                }
            }
        }


    

        public void LoadFeatures()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string filePath = ofd.FileName;
            int noVectors;
            int noFeatures = 8;
            int cntPos = 0;
            int cntNeg = 0;



            using (var sr = new StreamReader(filePath))
            {
                noVectors = Utils.Str2Int(sr.ReadLine());
                features = new double[noVectors][];
                outputs = new int[noVectors];

                int featVecNo = 0;

                while(sr.Peek()>0)
                {
                    string line = sr.ReadLine();
                    string[] strSplit = line.Split(new char[] { ';' });
                    noFeatures = strSplit.Length - 1;

                    double[] temp = new double[noFeatures];


                    for (int j = 0; j < noFeatures; j++)
                    {
                        temp[j] = Utils.Str2Dbl(strSplit[j]);
                    }
                    features[featVecNo] = temp;
                    outputs[featVecNo] = Utils.Str2Int(strSplit[noFeatures ]);

                    if (outputs[featVecNo] == 1) cntPos++;
                    else cntNeg++;

                    featVecNo++;                 
                }
            }

            Console.WriteLine(cntPos.ToString());
            Console.WriteLine(cntNeg.ToString());


            ///

            //int[] sampleVector = Utils.SampleVector(noVectors);
           

            //int noRandomVectors = Utils.Str2Int(noVectorsTxtBox.Text);
            //double[][] randFeatures = new double[noRandomVectors][];
            //int[] randOutputs = new int[noRandomVectors];

            //for (int i = 0; i < noRandomVectors; i++)
            //{
            //    double[] temp = new double[noFeatures];

            //    temp = features[sampleVector[i]];
            //    randFeatures[i] = temp;
            //    randOutputs[i] = outputs[sampleVector[i]];             
            //}


            //int noValidationVectors = Utils.Str2Int(noValidationVecTxtBox.Text);
            //validationFeatures = new double[noValidationVectors][];
            //validationOutputs = new int[noValidationVectors];

            //for (int i = 0; i < noValidationVectors; i ++)
            //{
            //    double[] temp = new double[noFeatures];

            //    temp = features[sampleVector[i + noRandomVectors]];
            //    validationFeatures[i] = temp;
            //    validationOutputs[i] = outputs[sampleVector[i + noRandomVectors]];
            //}




            double[][] vectorsPositive = new double[cntPos][];
            double[][] vectorsNegative = new double[cntNeg][];
            int[] outputsPositive = new int[cntPos];
            int[] outputsNegative = new int[cntNeg];

            int indPos = 0;
            int indNeg = 0;
            for (int i = 0; i < noVectors; i++)
            {
                if (outputs[i] == 1)
                {
                    vectorsPositive[indPos] = features[i];
                    outputsPositive[indPos] = outputs[i];
                    indPos++;
                }
                else
                {
                    vectorsNegative[indNeg] = features[i];
                    outputsNegative[indNeg] = outputs[i];
                    indNeg++;
                }

            }


            int[] sampleVectorPos = Utils.SampleVector(indPos);
            int[] sampleVectorNeg = Utils.SampleVector(indNeg);


            int noRandomVectors = Utils.Str2Int(noVectorsTxtBox.Text);
            double[][] randFeatures = new double[noRandomVectors][];
            int[] randOutputs = new int[noRandomVectors];

            for (int i = 0; i < noRandomVectors; i += 2)
            {
                double[] temp = new double[noFeatures];

                temp = vectorsPositive[sampleVectorPos[i]];
                randFeatures[i] = temp;
                randOutputs[i] = outputsPositive[sampleVectorPos[i]];

                temp = vectorsNegative[sampleVectorNeg[i]];
                randFeatures[i + 1] = temp;
                randOutputs[i + 1] = outputsNegative[sampleVectorNeg[i]];
            }



            int noValidationVectors = Utils.Str2Int(noValidationVecTxtBox.Text);
            validationFeatures = new double[noValidationVectors][];
            validationOutputs = new int[noValidationVectors];

            for (int i = 0; i < noValidationVectors; i += 2)
            {
                double[] temp = new double[noFeatures];

                temp = vectorsPositive[sampleVectorPos[i + noRandomVectors]];
                validationFeatures[i] = temp;
                validationOutputs[i] = outputsPositive[sampleVectorPos[i + noRandomVectors]];

                temp = vectorsNegative[sampleVectorNeg[i + noRandomVectors]];
                validationFeatures[i + 1] = temp;
                validationOutputs[i + 1] = outputsNegative[sampleVectorNeg[i + noRandomVectors]];
            }



            int noTestingVectors = Utils.Str2Int(NoTestingVectorsTxtBox.Text);
            testingFeatures = new double[noTestingVectors][];
            testingOutputs = new int[noTestingVectors];

            for (int i = 0; i < noTestingVectors; i += 2)
            {
                double[] temp = new double[noFeatures];

                temp = vectorsPositive[sampleVectorPos[i + noRandomVectors + noValidationVectors]];
                testingFeatures[i] = temp;
                testingOutputs[i] = outputsPositive[sampleVectorPos[i + noRandomVectors]];

                temp = vectorsNegative[sampleVectorNeg[i + noRandomVectors + noValidationVectors]];
                testingFeatures[i + 1] = temp;
                testingOutputs[i + 1] = outputsNegative[sampleVectorNeg[i + noRandomVectors]];
            }





            features = randFeatures;
            outputs = randOutputs;

            Console.WriteLine(cntPos.ToString());
            Console.WriteLine(cntNeg.ToString());



            origFeatures = new double[noRandomVectors][];
            Array.Copy(features, origFeatures, noRandomVectors);           

            features = Accord.Statistics.Tools.ZScores(features);
            validationFeatures = Accord.Statistics.Tools.ZScores(validationFeatures);
    //        testingFeatures = Accord.Statistics.Tools.ZScores(testingFeatures);

            Console.WriteLine();





            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save learning vectors";
            sfd.ShowDialog();

            filePath = sfd.FileName;
            noVectors = features.Length;

            if (filePath != "")
            using (var sw = new StreamWriter(filePath))
            {
                sw.WriteLine(noVectors.ToString());

                for (int i = 0; i < features.Length; i++)
                {
                    double[] feat = features[i];

                    for (int j = 0; j < feat.Length; j++)
                    {
                        sw.Write(feat[j].ToString() + ";");
                    }

                    sw.WriteLine(outputs[i].ToString());
                }
            }



            sfd = new SaveFileDialog();
            sfd.Title = "Save validation vectors";
            sfd.ShowDialog();

            filePath = sfd.FileName;
            noVectors = validationFeatures.Length;

            if (filePath != "")
            using (var sw = new StreamWriter(filePath))
            {
                sw.WriteLine(noVectors.ToString());

                for (int i = 0; i < validationFeatures.Length; i++)
                {
                    double[] feat = validationFeatures[i];

                    for (int j = 0; j < feat.Length; j++)
                    {
                        sw.Write(feat[j].ToString() + ";");
                    }

                    sw.WriteLine(validationOutputs[i].ToString());
                }
            }


            if (testingFeatures != null)
            {
                sfd = new SaveFileDialog();
                sfd.Title = "Save testing vectors";
                sfd.ShowDialog();

                filePath = sfd.FileName;
                noVectors = testingFeatures.Length;

                if (filePath != "")
                    using (var sw = new StreamWriter(filePath))
                    {
                        sw.WriteLine(noVectors.ToString());

                        for (int i = 0; i < testingFeatures.Length; i++)
                        {
                            double[] feat = testingFeatures[i];

                            for (int j = 0; j < feat.Length; j++)
                            {
                                sw.Write(feat[j].ToString() + ";");
                            }

                            sw.WriteLine(testingOutputs[i].ToString());
                        }
                    }

            }
        }

        double[] means;
        double[] stdDev;

        double[][] validationFeatures;
        int[] validationOutputs;
        double[][] testingFeatures;
        int[] testingOutputs;

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFeatures();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadFeatures();
        }

        private void saveModelBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();

            string fileName = sfd.FileName;

            machine.Save(fileName);

        }

        private void LoadModelBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string fileName = ofd.FileName;

            machine = KernelSupportVectorMachine.Load(fileName);
        }

        private void CalcGMMBtn_Click(object sender, EventArgs e)
        {
            GaussianMixtureModel gmm = new GaussianMixtureModel(5);

            double[][] dataForGMM = new double[Segments.Length][];
            int cnt = 0;
            foreach (var segment in Segments)
            {
                segment.FormFeatures();
                dataForGMM[cnt] = new double[1];
                dataForGMM[cnt++][0] = segment.FeatureVec[0];

            }

                // Compute the model (estimate)
                gmm.Compute(dataForGMM, 0.0001);

            // Classify a single sample
            //int c = gmm.Gaussians.Nearest(sample);

            foreach (var item in gmm.Gaussians.Coefficients)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
         
        }

        private void noTestingVecTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string filePath = ofd.FileName;
            int noVectors;
            int noFeatures = 8;
          
            using (var sr = new StreamReader(filePath))
            {
                noVectors = Utils.Str2Int(sr.ReadLine());
                features = new double[noVectors][];
                outputs = new int[noVectors];

                int featVecNo = 0;

                while (sr.Peek() > 0)
                {
                    string line = sr.ReadLine();
                    string[] strSplit = line.Split(new char[] { ';' });
                    noFeatures = strSplit.Length - 1;

                    double[] temp = new double[noFeatures];


                    for (int j = 0; j < noFeatures; j++)
                    {
                        temp[j] = Utils.Str2Dbl(strSplit[j]);
                    }
                    features[featVecNo] = temp;
                    outputs[featVecNo] = Utils.Str2Int(strSplit[noFeatures]);

                   
                    featVecNo++;
                }
            }

            noVectorsTxtBox.Text = noVectors.ToString();

            origFeatures = new double[noVectors][];
            Array.Copy(features, origFeatures, noVectors);

            features = Accord.Statistics.Tools.ZScores(features);
         
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string filePath = ofd.FileName;
            int noVectors;
            int noFeatures = 8;

            using (var sr = new StreamReader(filePath))
            {
                noVectors = Utils.Str2Int(sr.ReadLine());
                validationFeatures = new double[noVectors][];
                validationOutputs = new int[noVectors];

                int featVecNo = 0;

                while (sr.Peek() > 0)
                {
                    string line = sr.ReadLine();
                    string[] strSplit = line.Split(new char[] { ';' });
                    noFeatures = strSplit.Length - 1;

                    double[] temp = new double[noFeatures];

                    for (int j = 0; j < noFeatures; j++)
                    {
                        temp[j] = Utils.Str2Dbl(strSplit[j]);
                    }
                    validationFeatures[featVecNo] = temp;
                    validationOutputs[featVecNo] = Utils.Str2Int(strSplit[noFeatures]);
                    
                    featVecNo++;
                }

            }

            noValidationVecTxtBox.Text = noVectors.ToString();
            validationFeatures = Accord.Statistics.Tools.ZScores(validationFeatures);
         
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string filePath = ofd.FileName;
            int noVectors;
            int noFeatures = 8;

            using (var sr = new StreamReader(filePath))
            {
                noVectors = Utils.Str2Int(sr.ReadLine());
                testingFeatures = new double[noVectors][];
                testingOutputs = new int[noVectors];

                int featVecNo = 0;

                while (sr.Peek() > 0)
                {
                    string line = sr.ReadLine();
                    string[] strSplit = line.Split(new char[] { ';' });
                    noFeatures = strSplit.Length - 1;

                    double[] temp = new double[noFeatures];

                    for (int j = 0; j < noFeatures; j++)
                    {
                        temp[j] = Utils.Str2Dbl(strSplit[j]);
                    }
                    testingFeatures[featVecNo] = temp;
                    testingOutputs[featVecNo] = Utils.Str2Int(strSplit[noFeatures]);

                    featVecNo++;
                }
            }

            NoTestingVectorsTxtBox.Text = noVectors.ToString();

            testingFeatures = Accord.Statistics.Tools.ZScores(testingFeatures);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            double[] gammas = new double[5] {0.04, 0.08, 0.2, 0.4, 0.8 };
            double[] ctable = new double[4] { 0.5, 1, 5, 20 };
           

            foreach (var item in gammas)
            {
                foreach (var item3 in ctable)
                {
                    TrainSVM(item, item3);
                }
            }

            using (StreamWriter sw = new StreamWriter("D:/learning_report.txt"))
            {
                sw.Write(sb);
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            int noVectors = features.Length;
            double[][] vectorsPositive = new double[noVectors/2][];
            double[][] vectorsNegative = new double[noVectors / 2][];
            int[] outputsPositive = new int[noVectors / 2];
            int[] outputsNegative = new int[noVectors / 2];

            int indPos = 0;
            int indNeg = 0;
            for (int i = 0; i < noVectors; i++)
            {
                if (outputs[i] == 1)
                {
                    vectorsPositive[indPos] = features[i];
                    outputsPositive[indPos] = outputs[i];
                    indPos++;
                }
                else
                {
                    vectorsNegative[indNeg] = features[i];
                    outputsNegative[indNeg] = outputs[i];
                    indNeg++;
                }

            }

            double threshold = 0.1;
            int cnt = 0;

            for (int i = 0; i < vectorsPositive.Length; i++)
            {
                for (int j = 0; j < vectorsNegative.Length; j++)
                {
                    double distance = Distance.SquareEuclidean(vectorsPositive[i], vectorsNegative[j]);
                    if (distance<threshold)
                    {
                        cnt++;
                        Console.WriteLine(i.ToString()+" and  " + j.ToString()+" - similarity: "+distance.ToString());
                        foreach (var item in vectorsPositive[i])
                        {
                            Console.Write(item.ToString()+";");
                        }
                        Console.WriteLine();

                        foreach (var item in vectorsNegative[i])
                        {
                            Console.Write(item.ToString() + ";");
                        }
                        Console.WriteLine();
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("No similar samples:" + cnt.ToString());
        }

        
    }
}