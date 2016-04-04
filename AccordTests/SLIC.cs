using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using Accord.Imaging.Converters;
using Accord.MachineLearning;
using Accord.Math;
using ColorMine.ColorSpaces;

namespace AccordTests
{
    public enum ColorSpaceType { Lab, Rgb }

    class SLIC
    {
        public const int L_minVal = 0;
        public const int L_maxVal = 100;
        public const int A_minVal = -128;
        public const int A_maxVal = 128;
        public const int B_minVal = -128;
        public const int B_maxVal = 128;

        public const int RGB_minVal = 0;
        public const int RGB_maxVal = 256;

        // parametry metody SLIC
        private readonly int noClusters;
        private readonly int spatialConsistency;
        private readonly ColorSpaceType colorSpace;

        public SLIC(int noClusters, int spatialConsistency, ColorSpaceType colorSpace)
        {
            this.noClusters = noClusters;
            this.spatialConsistency = spatialConsistency;
            this.colorSpace = colorSpace;
        }

        public Bitmap Segment(Bitmap image)
        {
            // Konwersja obrazu do tablicy pikseli o wymiarach: ilość pikseli x (3 składowe RGB + 2 składowe położenia)
            IPixels5DimConverter converter = GetPixels5DimConverter();
            var pixels5dim = converter.GetPixels(image);

            // konstrukcja algorytmu k-means do wyznaczenia segmentów 
            // używając przy tym metryki euklidesowej
            KMeans kmeans = new KMeans(noClusters, Distance.SquareEuclidean);

            // uruchomienie algorytmu do miejsca gdy tolerancja 
            // (różnica centrów klastrów) w dwóch kolejnych iteracjach będzie mniejsza niż 0.05
            kmeans.Tolerance = 0.05;
            int[] idx = kmeans.Compute(pixels5dim);

            // zamiana każdego piksela na odpowiadające mu centrum segmentu
            pixels5dim.ApplyInPlace((x, i) => kmeans.Clusters.Centroids[idx[i]]);
            
            // konwersja tablicy pikseli do obrazu
            return converter.GetImage(pixels5dim, image.Height, image.Width);
        }


        IPixels5DimConverter GetPixels5DimConverter()
        {
            if (colorSpace == ColorSpaceType.Rgb)
                return new Pixels5DimConverterRgbSpace(spatialConsistency);
            else
                return new Pixels5DimConverterLabSpace(spatialConsistency);
            
        }
    }

    public interface IPixels5DimConverter
    {
        /// <summary>
        /// Gets 5-dimensional tuple of pixels
        /// </summary>
        /// <param name="image">Image to convert</param>
        /// <returns>Pixels[][] color values are in LAB or RGB space and are scaled to 0-1</returns>
        /// 
        double[][] GetPixels(Bitmap image);

        /// <summary>
        /// Gets image from 5-dimensional tuple of pixels
        /// </summary>
        /// <param name="pixels">color values are in LAB or RGB space and are scaled to 0-1</param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        Bitmap GetImage(double[][] pixels, int height, int width);
    }


    public class Pixels5DimConverterLabSpace : IPixels5DimConverter
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

                    temp[0] = Utils.GetScaledValue(myLab.L, SLIC.L_minVal, SLIC.L_maxVal);
                    temp[1] = Utils.GetScaledValue(myLab.A, SLIC.A_minVal, SLIC.A_maxVal);
                    temp[2] = Utils.GetScaledValue(myLab.B, SLIC.B_minVal, SLIC.B_maxVal);
                    temp[3] = (double)i / imageHeight * spatialConsistency;
                    temp[4] = (double)j / imageWidth * spatialConsistency;

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
                double L = Utils.GetOrigValue(pixels[i][0], SLIC.L_minVal, SLIC.L_maxVal);
                double A = Utils.GetOrigValue(pixels[i][1], SLIC.A_minVal, SLIC.A_maxVal);
                double B = Utils.GetOrigValue(pixels[i][2], SLIC.B_minVal, SLIC.B_maxVal);

                var myLab = new Lab {L = L, A = A, B = B};
                var myRgb = myLab.To<Rgb>();

                double[] temp = new double[3];

                temp[0] = Utils.GetScaledValue(myRgb.R, SLIC.RGB_minVal, SLIC.RGB_maxVal);
                temp[1] = Utils.GetScaledValue(myRgb.G, SLIC.RGB_minVal, SLIC.RGB_maxVal);
                temp[2] = Utils.GetScaledValue(myRgb.B, SLIC.RGB_minVal, SLIC.RGB_maxVal);

                outPixels[i] = temp;
            }

            Bitmap image;
            arrayToImage.Convert(outPixels, out image);
            return image;
        }
    }

    public class Pixels5DimConverterRgbSpace : IPixels5DimConverter
    {
        private readonly int spatialConsistency;

        public Pixels5DimConverterRgbSpace(int spatialConsistency)
        {
            this.spatialConsistency = spatialConsistency;
        }

        public double[][] GetPixels(Bitmap image)
        {
            throw new System.NotImplementedException();
        }

        public Bitmap GetImage(double[][] pixels, int height, int width)
        {
            throw new System.NotImplementedException();
        }
    }

    public static class Utils
    {
        public static double GetScaledValue(double value, int min, int max)
        {
            return (value - min) / (max - min);
        }

        public static double GetOrigValue(double value, int min, int max)
        {
            return value*(max - min) + min;
        }
    }
    
}
