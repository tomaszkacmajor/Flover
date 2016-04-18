using System.Drawing;
using System;
using ColorMine.ColorSpaces;

namespace AccordTests.SLIC
{
    public enum ColorSpaceType { Lab, Rgb }

    class SLICMethod
    {
      

        // parametry metody SLIC
        private readonly int noClusters;
        private readonly int spatialConsistency;
        private readonly ColorSpaceType colorSpace;
        int imageHeight;
        int imageWidth;

        public bool ShowEdges = true;
        public bool ShowRandomColorSegments = false;

        public Pixel[,] Pixels;
        public Segment[] Segments;

        public SLICMethod(int noClusters, int spatialConsistency, ColorSpaceType colorSpace)
        {
            this.noClusters = noClusters;
            this.spatialConsistency = spatialConsistency;
            this.colorSpace = colorSpace;

            Segments = new Segment[noClusters];
           
        }

        public Bitmap Segment(Bitmap image)
        {
            imageHeight = image.Height;
            imageWidth = image.Width;

            // Konwersja obrazu do tablicy pikseli o wymiarach: ilość pikseli x (3 składowe RGB + 2 składowe położenia)
            IPixels5DimConverter converter = GetPixels5DimConverter();
            var pixels5dim = converter.GetPixels(image);

            Pixels5DimConverterRgbSpace rgbConverter = new Pixels5DimConverterRgbSpace();
            Pixels = rgbConverter.GetPixels2(image); 


            // konstrukcja algorytmu k-means do wyznaczenia segmentów 
            // używając przy tym metryki euklidesowej

            KMeansSLIC kmeans = new KMeansSLIC(noClusters)
            {
                //Distance = new Accord.Math.Distances.SquareEuclidean(),
                SpatialConsistency = spatialConsistency,
                imageHeight = image.Height,
                imageWidth = image.Width
            };


            // uruchomienie algorytmu do miejsca gdy tolerancja 
            // (różnica centrów klastrów) w dwóch kolejnych iteracjach będzie mniejsza niż 0.05
            kmeans.Tolerance = 0.05;
            int[] idx = kmeans.Run(pixels5dim);

            // zamiana każdego piksela na odpowiadające mu centrum segmentu
            pixels5dim = pixels5dim.Apply((x, i) => kmeans.Clusters.Centroids[idx[i]]);

            SetSegmentInfoToPixels(idx);
            SetSegments(kmeans.Clusters.Centroids);

            if (ShowRandomColorSegments)
                ColorSegments(ref pixels5dim, idx, noClusters);
            if (ShowEdges)
                ApplyEdges(ref pixels5dim, idx);

            // konwersja tablicy pikseli do obrazu
            return converter.GetImage(pixels5dim, image.Height, image.Width);
        }

        void SetSegmentInfoToPixels(int[] idx)
        {
            for (int i = 0; i < imageHeight; i++)
            {
                for (int j = 0; j < imageWidth; j++)
                {
                    int ind = Utils.GetJaggedArrInd(i, j, imageWidth);
                    Pixels[i, j].SegmentInd = idx[ind];
                }
            }
        }

        void SetSegments(double[][] centroids)
        {
            for (int i = 0; i < centroids.Length; i++)
            {
                double[] centroid = centroids[i];

                int R = (int)centroid[0];
                int G = (int)centroid[1];
                int B = (int)centroid[2];
                int X = (int)centroid[3];
                int Y = (int)centroid[4];

                if (colorSpace == ColorSpaceType.Lab)
                {
                    var myLab = new Lab { L = centroid[0], A = centroid[1], B = centroid[2] };
                    var myRgb = myLab.To<Rgb>();

                    R = (int)myRgb.R;
                    G = (int)myRgb.G;
                    B = (int)myRgb.B;
                }

                
               

                MyRGB color = new MyRGB(R, G, B);
                Point point = new Point(X, Y);

                Segments[i] = new Segment(color, point);
            }

            int[] count = new int[centroids.Length];

            for (int i = 0; i < imageHeight; i++)
            {
                for (int j = 0; j < imageWidth; j++)
                {
                    count[Pixels[i, j].SegmentInd]++;
                }
            }

            for (int i = 0; i < centroids.Length; i++)
            {
                Segments[i].CreatePixelsArr(count[i]);
            }

            for (int i = 0; i < imageHeight; i++)
            {
                for (int j = 0; j < imageWidth; j++)
                {
                    int segmentInd = Pixels[i, j].SegmentInd;
                    int pixInd = Segments[segmentInd].currPixInd;
                    Segments[segmentInd].Pixels[pixInd] = Pixels[i,j];
                    Segments[segmentInd].currPixInd++;
                }
            }

        }

        private void ColorSegments(ref double[][] pixels, int[] labels, int noSegments)
        {
            double[,] randColors = new double[noSegments, 3];
            Random rand = new Random();

            for (int i = 0; i < noSegments; i++)
            {
                randColors[i, 0] = rand.Next(0, 100);
                randColors[i, 1] = rand.Next(-128, 128);
                randColors[i, 2] = rand.Next(-128, 128);

            }

            for (int i = 0; i < pixels.Length; i++)
            {
                double[] temp = new double[5];
                temp[0] = randColors[labels[i], 0];
                temp[1] = randColors[labels[i], 1];
                temp[2] = randColors[labels[i], 2];
                temp[3] = pixels[i][3];
                temp[4] = pixels[i][4];

                pixels[i] = temp;
            }
        }

        private void ApplyEdges(ref double[][] pixels, int[] labels)
        {
            bool[,] pixelTaken = new bool[imageHeight, imageWidth];
            Point[] neighbours8 = new Point[8];
            neighbours8[0] = new Point(-1, -1);
            neighbours8[1] = new Point(-1, 0);
            neighbours8[2] = new Point(-1, 1);
            neighbours8[3] = new Point(0, -1);
            neighbours8[4] = new Point(0, 1);
            neighbours8[5] = new Point(1, -1);
            neighbours8[6] = new Point(1, 0);
            neighbours8[7] = new Point(1, 1);

            
            for (int i = 0; i < imageHeight; i++)
            {
                for (int j = 0; j < imageWidth; j++)
                {
                    int ind = Utils.GetJaggedArrInd(i, j, imageWidth);
                    int pixelTakenCnt = 0;

                    foreach (var neighbourPoint in neighbours8)
                    {
                        int ind2 = Utils.GetJaggedArrInd((i + neighbourPoint.X), (j + neighbourPoint.Y), imageWidth);
                        if (ind2 >= 0 && ind2 < pixels.Length && !pixelTaken[i, j] && labels[ind] != labels[ind2])
                        {
                            pixelTakenCnt++;
                        }
                    }

                    if (pixelTakenCnt >= 2)
                    {
                        double[] temp = new double[5];
                        temp[0] = 0;
                        temp[1] = 0;
                        temp[2] = 0;
                        temp[3] = pixels[ind][3];
                        temp[4] = pixels[ind][4];
                        pixels[ind] = temp;

                        pixelTaken[i, j] = true;
                    }

                }
            }
        }

     


        
        IPixels5DimConverter GetPixels5DimConverter()
        {
            if (colorSpace == ColorSpaceType.Rgb)
                return new Pixels5DimConverterRgbSpace();
            else
                return new Pixels5DimConverterLabSpace();

        }
    }
    

}

