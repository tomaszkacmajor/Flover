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
        int[] outputs;

        public MainForm()
        {
            InitializeComponent();

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

        private int EliminateBckg(Bitmap image, Bitmap triImage)
        {
            slic = new SLICMethod(SLICTrackBar.Value, spatialConsTrackBar.Value, ColorSpaceType.Lab);
            slic.ShowEdges = applyEdgesChkBox.Checked;
            slic.ShowRandomColorSegments = randomColorSegmentsChkBox.Checked;

            segmentedImage = slic.Segment(image);
            resultImagePictureBox.Image = segmentedImage;
            Refresh();

            Segments = slic.Segments;
            Pixels = slic.Pixels;

            AttachLabelToSegment(Segments, triImage);

            foreach (var segment in Segments)
            {
                segment.FormFeatures();

                int FGPix = Math.Sign(machine.Compute(segment.FeatureVec));
                foreach (var item in segment.Pixels)
                {
                    if (FGPix == -1)
                        item.Color = new MyRGB(0, 0, 0);
                }

            }

            Pixels5DimConverterRgbSpace converter = new Pixels5DimConverterRgbSpace();
            Bitmap segmImage = converter.GetImage2(Pixels);
            resultImagePictureBox.Image = segmImage;

            int cntAllRight = 0;
            for (int i = 0; i < Segments.Length; i++)
            {
                int FGPix = Math.Sign(machine.Compute(Segments[i].FeatureVec));
                if ((FGPix == 1 && Segments[i].MaskType == MaskTypes.Foreground) ||
                    (FGPix == -1 && (Segments[i].MaskType == MaskTypes.Background || Segments[i].MaskType == MaskTypes.Unknown)))
                    cntAllRight++;
            }

            return cntAllRight;
        }

        private void SegmentFGBGBtn_Click(object sender, EventArgs e)
        {
            int cntAllRight = EliminateBckg(image, trimapImages[0]);

            FGBGErrorLabel.Text = ((double)cntAllRight / Segments.Length).ToString();
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialogMulti.ShowDialog();
            loadedImages = GetImagesSet(openFileDialogMulti.FileNames);
            trimapImages = GetTrimapImagesSet(openFileDialogMulti.FileNames);         
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
                string trimapImagePath = imageFileNames[i].Replace("samples", "trimaps\\trimaps").Replace(".jpg", ".png");
                ImagesArr[i] = new Bitmap(trimapImagePath);
            }

            return ImagesArr;
        }

        Bitmap[] GetTrimapImagesSet(string imageFileName)
        {
            string[] imageFileNames = new string[1];
            imageFileNames[0] = imageFileName;
            return GetTrimapImagesSet(imageFileNames);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int noFeatures = loadedImages.Length * SLICTrackBar.Value;
            features = new double[noFeatures][];
            outputs = new int[noFeatures];
            int featureNo = 0;

            for (int i=0; i< loadedImages.Length; i++)
            {
                Bitmap curImage = loadedImages[i];
                Bitmap curTriImage = trimapImages[i];

                workingImagePictureBox.Image = curImage;

                slic = new SLICMethod(SLICTrackBar.Value, spatialConsTrackBar.Value, ColorSpaceType.Lab);
                slic.ShowEdges = applyEdgesChkBox.Checked;
                slic.ShowRandomColorSegments = randomColorSegmentsChkBox.Checked;

                segmentedImage = slic.Segment(curImage);
                resultImagePictureBox.Image = segmentedImage;

                Segments = slic.Segments;
                Pixels = slic.Pixels;

                AttachLabelToSegment(Segments, curTriImage);

                foreach (var segment in Segments)
                {
                    segment.FormFeatures();
                    features[featureNo] = segment.FeatureVec;

                    if (segment.MaskType == MaskTypes.Foreground)
                        outputs[featureNo] = 1;
                    else outputs[featureNo] = -1;

                    featureNo++;
                }

            }
        
        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            IKernel kernel = new Gaussian(70);
            // Create a Support Vector Machine for the given inputs
            machine = new KernelSupportVectorMachine(kernel, features[0].Length);

            // Instantiate a new learning algorithm for SVMs
            SequentialMinimalOptimization smo = new SequentialMinimalOptimization(machine, features, outputs);

            // Set up the learning algorithm
            smo.Complexity = 85;
            
            // Run
            try
            {
                double error = smo.Run();
                MessageBox.Show("SVM Trained");
            }
            catch
            {
                MessageBox.Show("SVM Fail");
            }


            int cntAllRight = 0;
            for (int i = 0; i < features.Length; i++)
            {
                int FGPix = Math.Sign(machine.Compute(features[i]));
                if (FGPix == outputs[i])
                    cntAllRight++;
            }

            LearnErrLabel.Text = ((double)cntAllRight / features.Length).ToString();

            machine.Save("D://txt.txt");
          //  machine = SupportVectorMachine.Load("");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialogMulti.ShowDialog();
            testImages = GetImagesSet(openFileDialogMulti.FileNames);
            testTrimapImages = GetTrimapImagesSet(openFileDialogMulti.FileNames);
        }


        private void button7_Click(object sender, EventArgs e)
        {
            int noFeatures = testImages.Length * SLICTrackBar.Value;      
            int cntAllRight_alltestImages = 0;

            for (int i = 0; i < testImages.Length; i++)
            {
                Bitmap curImage = testImages[i];
                Bitmap curTriImage = testTrimapImages[i];

                workingImagePictureBox.Image = curImage;
                Refresh();

                int cntAllRight = EliminateBckg(curImage, curTriImage);
                cntAllRight_alltestImages += cntAllRight;

                Console.WriteLine(((double)cntAllRight / Segments.Length).ToString());
            }

            TestErrLabel.Text = ((double)cntAllRight_alltestImages / noFeatures).ToString();
        }
    }
}