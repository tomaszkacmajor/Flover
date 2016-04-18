using Accord.Imaging.Converters;
using System.Collections.Generic;
using System.Drawing;

namespace AccordTests.SLIC
{
    class Pixels5DimConverterRgbSpace : IPixels5DimConverter
    {
      
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

                    temp[0] = curPixel.R;
                    temp[1] = curPixel.G;
                    temp[2] = curPixel.B;
                    temp[3] = i;
                    temp[4] = j;

                    pixels5dim[indexJaggedArray] = temp;
                }
            }
            return pixels5dim;
        }

        public Pixel[,] GetPixels2(Bitmap image)
        {
            int imageHeight = image.Height;
            int imageWidth = image.Width;
            ImageToMatrix imageToMatrix = new ImageToMatrix();
            Pixel[,] retPixelArr = new Pixel[imageHeight, imageWidth];

            Color[,] pixelsMatrix;
            imageToMatrix.Convert(image, out pixelsMatrix);
           
            for (int i = 0; i < imageHeight; i++)
            {
                for (int j = 0; j < imageWidth; j++)
                {                 
                    Color curPixel = pixelsMatrix[i, j];
                    int R = curPixel.R;
                    int G = curPixel.G;
                    int B = curPixel.B;

                    retPixelArr[i, j] = new Pixel(new MyRGB(R, G, B) , i, j);
                    retPixelArr[i, j].Alpha = curPixel.A;
                }
            }

            return retPixelArr;
        }

        public Bitmap GetImage(double[][] pixels, int height, int width)
        {
            ArrayToImage arrayToImage = new ArrayToImage(width, height);
            double[][] outPixels = new double[pixels.Length][];

            for (int i = 0; i < pixels.Length; i++)
            {
                double[] temp = new double[3];

                temp[0] = Utils.GetScaledValue(pixels[i][0], Utils.RGB_minVal, Utils.RGB_maxVal);
                temp[1] = Utils.GetScaledValue(pixels[i][1], Utils.RGB_minVal, Utils.RGB_maxVal);
                temp[2] = Utils.GetScaledValue(pixels[i][2], Utils.RGB_minVal, Utils.RGB_maxVal);

                outPixels[i] = temp;
            }

            Bitmap image;
            arrayToImage.Convert(outPixels, out image);
            return image;
        }

        public Bitmap GetImage2(Pixel[,] pixels)
        {
            int height = pixels.GetLength(0);
            int width = pixels.GetLength(1);

            ArrayToImage arrayToImage = new ArrayToImage(width, height);
            double[][] outPixels = new double[width*height][];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int ind = Utils.GetJaggedArrInd(i, j, width);
                    double[] temp = new double[3];

                    temp[0] = Utils.GetScaledValue(pixels[i,j].Color.R, Utils.RGB_minVal, Utils.RGB_maxVal);
                    temp[1] = Utils.GetScaledValue(pixels[i,j].Color.G, Utils.RGB_minVal, Utils.RGB_maxVal);
                    temp[2] = Utils.GetScaledValue(pixels[i,j].Color.B, Utils.RGB_minVal, Utils.RGB_maxVal);

                    outPixels[ind] = temp;
                }
            }

            Bitmap image;
            arrayToImage.Convert(outPixels, out image);
            return image;
        }
    }
}
