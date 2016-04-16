using Accord.Imaging.Converters;
using ColorMine.ColorSpaces;
using System.Drawing;

namespace AccordTests.SLIC
{
    class Pixels5DimConverterLabSpace : IPixels5DimConverter
    {
        private readonly int spatialConsistency;

        public Pixels5DimConverterLabSpace(int spatialConsistency)
        {
            this.spatialConsistency = spatialConsistency;
        }

        public double[][] GetPixels(Bitmap image)
        {
            int imageHeight = image.Height;
            int imageWidth = image.Width;
            ImageToMatrix imageToMatrix = new ImageToMatrix();

            Color[,] pixelsMatrix;
            imageToMatrix.Convert(image, out pixelsMatrix);

            int noPixels = pixelsMatrix.Length;
            double[][] pixels5dim = new double[noPixels][];

            for (int i = 0; i < imageHeight; i++)
            {
                for (int j = 0; j < imageWidth; j++)
                {
                    double[] temp = new double[5];
                    int indexJaggedArray = i * imageWidth + j;

                    Color curPixel = pixelsMatrix[i, j];

                    var myRgb = new Rgb { R = curPixel.R, G = curPixel.G, B = curPixel.B };
                    var myLab = myRgb.To<Lab>();

                    temp[0] = myLab.L;
                    temp[1] = myLab.A;
                    temp[2] = myLab.B;
                    temp[3] = i;
                    temp[4] = j;


                    pixels5dim[indexJaggedArray] = temp;
                }
            }
            return pixels5dim;
        }



        public Bitmap GetImage(double[][] pixels, int height, int width)
        {
            ArrayToImage arrayToImage = new ArrayToImage(width, height);
            double[][] outPixels = new double[pixels.Length][];

            for (int i = 0; i < pixels.Length; i++)
            {
                double L = pixels[i][0];
                double A = pixels[i][1];
                double B = pixels[i][2];

                var myLab = new Lab { L = L, A = A, B = B };
                var myRgb = myLab.To<Rgb>();

                double[] temp = new double[3];

                temp[0] = Utils.GetScaledValue(myRgb.R, SLICMethod.RGB_minVal, SLICMethod.RGB_maxVal);
                temp[1] = Utils.GetScaledValue(myRgb.G, SLICMethod.RGB_minVal, SLICMethod.RGB_maxVal);
                temp[2] = Utils.GetScaledValue(myRgb.B, SLICMethod.RGB_minVal, SLICMethod.RGB_maxVal);

                outPixels[i] = temp;
            }

            Bitmap image;
            arrayToImage.Convert(outPixels, out image);
            return image;
        }


    }
}
