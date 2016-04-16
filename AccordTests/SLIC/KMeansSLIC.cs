// Accord Machine Learning Library
// The Accord.NET Framework
// http://accord-framework.net
//
// Copyright © César Souza, 2009-2015
// cesarsouza at gmail.com
//
// Copyright © Antonino Porcino, 2010
// iz8bly at yahoo.it
//
//    This library is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 2.1 of the License, or (at your option) any later version.
//
//    This library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public
//    License along with this library; if not, write to the Free Software
//    Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
//

namespace AccordTests.SLIC
{
    using System;
    using Accord.Math;
    using System.Threading.Tasks;
    using Accord.Statistics;
    using System.Diagnostics;
    using Accord.MachineLearning;
    using Accord;

    public class KMeansSLIC 
    {
        private KMeansClusterCollection clusters;
        private int k;
        private int S = 0;
        private int noPixels;
        private int pixDim;

        /// <summary>
        ///   Gets the clusters found by K-means.
        /// </summary>
        /// 
        public KMeansClusterCollection Clusters
        {
            get { return clusters; }
        }

        /// <summary>
        ///   Gets the number of clusters.
        /// </summary>
        /// 
        public int K
        {
            get { return clusters.Count; }
        }

        /// <summary>
        ///   Gets the dimensionality of the data space.
        /// </summary>
        /// 
        public int Dimension
        {
            get { return clusters.Dimension; }
        }

      

        /// <summary>
        ///   Gets or sets whether covariance matrices for the clusters should 
        ///   be computed at the end of an iteration. Default is true.
        /// </summary>
        /// 
        public bool ComputeCovariances { get; set; }

        /// <summary>
        ///   Gets or sets whether the clustering distortion error (the
        ///   average distance between all data points and the cluster
        ///   centroids) should be computed at the end of the algorithm.
        ///   The result will be stored in <see cref="Error"/>. Default is true.
        /// </summary>
        /// 
        public bool ComputeError { get; set; }

        /// <summary>
        ///   Gets or sets the maximum number of iterations to
        ///   be performed by the method. If set to zero, no
        ///   iteration limit will be imposed. Default is 0.
        /// </summary>
        /// 
        public int MaxIterations { get; set; }

        /// <summary>
        ///   Gets or sets the relative convergence threshold
        ///   for stopping the algorithm. Default is 1e-5.
        /// </summary>
        /// 
        public double Tolerance { get; set; }

        /// <summary>
        ///   Gets the number of iterations performed in the
        ///   last call to this class' Compute methods.
        /// </summary>
        /// 
        public int Iterations { get; private set; }

        /// <summary>
        ///   Gets the cluster distortion error after the 
        ///   last call to this class' Compute methods.
        /// </summary>
        /// 
        public double Error { get; private set; }

 
        public int SpatialConsistency { get; set; }
        public int imageHeight { get; set; }
        public int imageWidth { get; set; }


        Stopwatch stopWatch = new Stopwatch();

        /// <summary>
        ///   Initializes a new instance of the KMeans algorithm
        /// </summary>
        /// 
        /// <param name="k">The number of clusters to divide the input data into.</param>    
        /// <param name="distance">The distance function to use. Default is to use the 
        /// 
        public KMeansSLIC(int k)
        {
            if (k <= 0)
                throw new ArgumentOutOfRangeException("k");

            this.Tolerance = 1e-5;
            this.ComputeCovariances = true;
            this.ComputeError = true;
            this.MaxIterations = 0;
            
            // Create the object-oriented structure to hold
            //  information about the k-means' clusters.
            this.clusters = new KMeansClusterCollection(k, Distance);
        }
      

        /// <summary>
        ///   Divides the input data into K clusters. 
        /// </summary>
        /// 
        /// <param name="data">The data where to compute the algorithm.</param>
        ///   
        public int[] Run(double[][] data)
        {
            // Initial argument checking
            if (data == null)
                throw new ArgumentNullException("data");

            if (data.Length < K)
                throw new ArgumentException("Not enough points. There should be more points than the number K of clusters.");

           
            int cols = data[0].Length;
            for (int i = 0; i < data.Length; i++)
                if (data[i].Length != cols)
                    throw new DimensionMismatchException("data", "The points matrix should be rectangular. The vector at position {} has a different length than previous ones.");

            int[] labels = Compute(data);
            
          //  ComputeInformation(data, labels);
            return labels;
        }

    
        private void ComputeInformation(double[][] data, int[] labels)
        {
            // Compute distortion and other metrics regarding the clustering
            if (ComputeCovariances)
            {
                // Compute cluster information (optional)
                Parallel.For(0, clusters.Count, i =>
                {
                    double[][] centroids = clusters.Centroids;

                    // Extract the data for the current cluster
                    double[][] sub = data.Submatrix(labels.Find(x => x == i));

                    if (sub.Length > 0)
                    {
                        // Compute the current cluster variance
                        clusters.Covariances[i] = sub.Covariance(centroids[i]);
                    }
                    else
                    {
                        // The cluster doesn't have any samples
                        clusters.Covariances[i] = new double[Dimension, Dimension];
                    }
                });
            }

            if (ComputeError)
            {
                Error = clusters.Distortion(data);
            }
        }


        double[][] InitializeCentroids(double[][] data)
        {
            double[][] retCentroids = new double[K][];

            k = K;
          
            double imageRatio = (double)imageWidth / imageHeight;
            int clusterRows = (int)(Math.Sqrt((double)k / imageRatio));
            int clusterCols = (int)(imageRatio * clusterRows);

            int horizDiv = imageWidth / clusterCols;
            int vertDiv = imageHeight / clusterRows;

            S = horizDiv;

            if (vertDiv > horizDiv)
                S = vertDiv;

            int[] idx = Utils.SampleVector(data.Length);

            for (int i = 0; i < clusterRows; i++)
            {
                for (int j = 0; j < clusterCols; j++)
                {
                    int clusterInd = i * clusterCols + j;
                    if (clusterInd >= k)
                        break;

                    int pixelRowNo = i * vertDiv + vertDiv / 2;
                    int pixelColNo = j * horizDiv + horizDiv / 2;
                    int pixInd = Utils.GetJaggedArrInd(pixelRowNo, pixelColNo, imageWidth);

                    retCentroids[clusterInd] = (double[])data[idx[clusterInd]].Clone();
                    retCentroids[clusterInd][0] = data[pixInd][0];
                    retCentroids[clusterInd][1] = data[pixInd][1];
                    retCentroids[clusterInd][2] = data[pixInd][2];
                    retCentroids[clusterInd][3] = pixelRowNo;
                    retCentroids[clusterInd][4] = pixelColNo;
                }
            }


            for (int m = 0; m < k; m++)
            {
                if (retCentroids[m] == null)
                {
                    retCentroids[m] = (double[])data[idx[m]].Clone();

                }
            }

            return retCentroids;
        }

        /// <summary>
        ///   Divides the input data into K clusters. 
        /// </summary>
        /// 
        /// <param name="data">The data where to compute the algorithm.</param>
        ///   
        protected virtual int[] Compute(double[][] data)
        {
            this.Iterations = 0;

            Clusters.Centroids = InitializeCentroids(data);

            stopWatch.Start();

            // Initial variables
            noPixels = data.Length;
            pixDim = data[0].Length;

            int[] labels = new int[noPixels];
            double[] minDistances = new double[noPixels];
            double[] count = new double[k];
            double[][] centroids = clusters.Centroids;
            double[][] newCentroids = new double[k][];
            for (int i = 0; i < newCentroids.Length; i++)
                newCentroids[i] = new double[pixDim];

            Object[] syncObjects = new Object[K];
            for (int i = 0; i < syncObjects.Length; i++)
                syncObjects[i] = new Object();

            Iterations = 0;

            bool shouldStop = false;          

            while (!shouldStop) // Main loop
            {
                Array.Clear(count, 0, count.Length);
                for (int i = 0; i < newCentroids.Length; i++)
                    Array.Clear(newCentroids[i], 0, newCentroids[i].Length);

                // First we will accumulate the data points
                // into their nearest clusters, storing this
                // information into the newClusters variable.

                for (int i = 0; i < minDistances.Length; i++)
                {
                    minDistances[i] = 1000000;
                }

                Parallel.For(0, centroids.Length, m =>
                {
                    double[] curCentroid = centroids[m];

                    int pixelRowNo = (int)curCentroid[3];
                    int pixelColNo = (int)curCentroid[4];

                    int startRow = pixelRowNo - S;
                    if (startRow < 0) startRow = 0;
                    int startCol = pixelColNo - S;
                    if (startCol < 0) startCol = 0;

                    int endRow = pixelRowNo + S;
                    if (endRow >= imageHeight) endRow = imageHeight - 1;
                    int endCol = pixelColNo + S;
                    if (endCol >= imageWidth) endCol = imageWidth - 1;

                    for (int i = startRow; i < endRow; i++)
                    {
                        for (int j = startCol; j < endCol; j++)
                        {
                            int jaggedArrInd = i * imageWidth + j;
                            double[] point = data[jaggedArrInd];

                            // double distance = Distance.Distance(point, curCentroid);
                            double distance = Distance(point, curCentroid);

                            if (distance < minDistances[jaggedArrInd])
                            {
                                minDistances[jaggedArrInd] = distance;
                                labels[jaggedArrInd] = m;
                            }

                        }
                    }

                    
                });

                Parallel.For(0, data.Length, i =>
                {
                    double[] point = data[i];

                    int c = labels[i];

                    double[] centroid = newCentroids[c];

                    lock (syncObjects[c])
                    {
                        count[c]++;

                        for (int j = 0; j < point.Length; j++)
                            centroid[j] += point[j];
                    }
                });

                
                Parallel.For(0, newCentroids.Length, i =>
                {
                    double sum = count[i];

                    if (sum > 0)
                    {
                        for (int j = 0; j < newCentroids[i].Length; j++)
                            newCentroids[i][j] /= sum;
                    }
                });

                
                // The algorithm stops when there is no further change in the
                //  centroids (relative difference is less than the threshold).
                shouldStop = converged(centroids, newCentroids);

                // go to next generation
                Parallel.For(0, centroids.Length, i =>
                {
                    for (int j = 0; j < centroids[i].Length; j++)
                        centroids[i][j] = newCentroids[i][j];
                });
            }

            stopWatch.Stop();
            Console.WriteLine("Main Loop: " + stopWatch.ElapsedMilliseconds);
            stopWatch.Restart();

            for (int i = 0; i < clusters.Centroids.Length; i++)
            {
                // Compute the proportion of samples in the cluster
                clusters.Proportions[i] = count[i] / data.Length;
            }

            return labels;
        }

      
       
        public double Distance(double[] x, double[] y)
        {
            double sum = 0;
            double sumColor = 0.0;
            double sumSpatial = 0.0;

            for (int i = 0; i < 3; i++)
            {
                double u = x[i] - y[i];
                sumColor += u * u;
            }

            for (int i = 3; i < 5; i++)
            {
                double u = x[i] - y[i];
                sumSpatial += u * u;
            }

            sum = Math.Sqrt(sumColor+sumSpatial *Math.Pow(SpatialConsistency / S, 2));


            return sum;
        }

        /// <summary>
        ///   Determines if the algorithm has converged by comparing the
        ///   centroids between two consecutive iterations.
        /// </summary>
        /// 
        /// <param name="centroids">The previous centroids.</param>
        /// <param name="newCentroids">The new centroids.</param>
        /// 
        /// <returns>Returns <see langword="true"/> if all centroids had a percentage change
        ///    less than <see param="threshold"/>. Returns <see langword="false"/> otherwise.</returns>
        ///    
        private bool converged(double[][] centroids, double[][] newCentroids)
        {
            Iterations++;

            if (MaxIterations > 0 && Iterations > MaxIterations)
                return true;

            for (int i = 0; i < centroids.Length; i++)
            {
                double[] centroid = centroids[i];
                double[] newCentroid = newCentroids[i];

                for (int j = 0; j < centroid.Length; j++)
                {
                    if ((System.Math.Abs((centroid[j] - newCentroid[j]) / centroid[j])) >= Tolerance)
                        return false;
                }
            }

            return true;
        }

    }
}



