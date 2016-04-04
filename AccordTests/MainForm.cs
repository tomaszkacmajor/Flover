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

namespace AccordTests
{
    public partial class MainForm : Form
    {
        private Bitmap image;

        public MainForm()
        {
            InitializeComponent();
        }

        private void loadPictureBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Graphics types|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tif;*.tiff" + "|BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff";
            openFileDialog.ShowDialog();

            string imageFileName = openFileDialog.FileName;
            image = new Bitmap(imageFileName);
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
  
        private void SLICBtn_Click(object sender, EventArgs e)
        {
            SLIC slic = new SLIC(SLICTrackBar.Value, 5, ColorSpaceType.Lab);
            resultImagePictureBox.Image = slic.Segment(image);
        }
    }
}
