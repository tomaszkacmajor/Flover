using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Accord.Imaging;
using Accord.Imaging.Filters;
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
            float threshold = ((float)surfDetectCornersThreshTrackBar.Value)/10000;
            int octaves = 5;
            int initial = 2;

            SpeededUpRobustFeaturesDetector surf =
                new SpeededUpRobustFeaturesDetector(threshold, octaves, initial);

            List<SpeededUpRobustFeaturePoint> points = surf.ProcessImage(image);

            FeaturesMarker features = new FeaturesMarker(points);

            workingImagePictureBox.Image = features.Apply(image);
        }
    }
}
