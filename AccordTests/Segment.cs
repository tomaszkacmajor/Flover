using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccordTests
{
    class Segment
    {
        public Segment(MyRGB color, Point point, int imageHeight, int imageWidth)
        {
            Color = color;
            Point = point;
            this.imageWidth = imageWidth;
            this.imageHeight = imageHeight;
        }

        public double[] FeatureVec = new double[8];

        public MyRGB Color { get; set; }
        public Point Point { get; set; }


        public Pixel[] Pixels { get; set; }
        public int currPixInd { get; set; }

        public MaskTypes MaskType { get; set; }

        private int imageHeight;
        private int imageWidth;


        public void CreatePixelsArr(int pixNo)
        {
            Pixels = new Pixel[pixNo];
        }

        public void FormFeatures()
        {      

            FeatureVec[0] = Color.R;
            FeatureVec[1] = Color.G;
            FeatureVec[2] = Color.B;

            double[] variance = GetVariance();

            FeatureVec[3] = variance[0];
            FeatureVec[4] = variance[1];
            FeatureVec[5] = variance[2];

            FeatureVec[6] = (double)Point.X / imageHeight;
            FeatureVec[7] = (double)Point.Y / imageWidth;          
        }

        double[] GetVariance()
        {
            double[] variance = new double[3];
            double cumR = 0;
            double cumG = 0;
            double cumB = 0;

            foreach (var item in Pixels)
            {
                cumR += Math.Pow((item.Color.R - Color.R), 2);
                cumG += Math.Pow((item.Color.G - Color.G), 2);
                cumB += Math.Pow((item.Color.B - Color.B), 2);
            }

            cumR /= currPixInd;
            cumG /= currPixInd;
            cumB /= currPixInd;

            variance[0] = cumR;
            variance[1] = cumG;
            variance[2] = cumB;

            return variance; 
        }


    }
}
