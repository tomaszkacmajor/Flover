using System;

namespace AccordTests
{
    public static class Utils
    {
        public static double GetScaledValue(double value, int min, int max)
        {
            return (value - min) / (max - min);
        }

        public static double GetOrigValue(double value, int min, int max)
        {
            return value * (max - min) + min;
        }

        /// <summary>
        ///   Applies a function to every element of the array.
        /// </summary>
        /// 
        public static TResult[] Apply<TInput, TResult>(this TInput[] vector, Func<TInput, int, TResult> func)
        {
            return Apply(vector, func, new TResult[vector.Length]);
        }


        /// <summary>
        ///   Applies a function to every element of the array.
        /// </summary>
        /// 
        public static TResult[] Apply<TInput, TResult>(this TInput[] vector, Func<TInput, int, TResult> func, TResult[] result)
        {
            for (int i = 0; i < vector.Length; i++)
                result[i] = func(vector[i], i);
            return result;
        }

        /// <summary>
        ///   Returns a vector containing indices (0, 1, 2, ..., n - 1) in random 
        ///   order. The vector grows up to to <paramref name="size"/>, but does not
        ///   include <c>size</c> among its values.
        /// </summary>
        ///
        /// <param name="size">The size of the sample vector to be generated.</param>
        /// 
        /// <example>
        /// <code>
        ///   var a = Vector.Sample(3);  // a possible output is { 2, 1, 0 };
        ///   var b = Vector.Sample(10); // a possible output is { 5, 4, 2, 0, 1, 3, 7, 9, 8, 6 };
        ///   
        ///   foreach (var i in Vector.Sample(5))
        ///   {
        ///      // ...
        ///   }
        /// </code>
        /// </example>
        /// 
        public static int[] SampleVector(int size)
        {
            var random = new Random();

            var idx = Range(size);
            var x = new double[idx.Length];
            for (int i = 0; i < x.Length; i++)
                x[i] = random.NextDouble();

            Array.Sort(x, idx);

            return idx;
        }

        /// <summary>
        ///   Creates a range vector.
        /// </summary>
        /// 
        public static int[] Range(int n)
        {
            int[] r = new int[(int)n];
            for (int i = 0; i < r.Length; i++)
                r[i] = (int)i;
            return r;
        }


        public static  int GetJaggedArrInd(int row, int col, int width)
        {
            if (row < 0 || col < 0)
                return -1;

            return row * width + col;
        }


    }
}
