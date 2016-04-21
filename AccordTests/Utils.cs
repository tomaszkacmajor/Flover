using AForge.Imaging;
using AForge.Imaging.Filters;
using System;
using System.Drawing;
using System.Globalization;
using System.Threading;

namespace AccordTests
{
    public static class Utils
    {
        public const int L_minVal = 0;
        public const int L_maxVal = 100;
        public const int A_minVal = -128;
        public const int A_maxVal = 128;
        public const int B_minVal = -128;
        public const int B_maxVal = 128;

        public const int RGB_minVal = 0;
        public const int RGB_maxVal = 256;

        public static string decimalSeparator = ",";
        public static string wrong_decimalSeparator = ".";

        public static double GetScaledValue(double value, int min, int max)
        {
            return (value - min) / (max - min);
        }

        public static double GetOrigValue(double value, int min, int max)
        {
            return value * (max - min) + min;
        }

        public static void InitSystemSeparators()
        {
            CultureInfo ci = Thread.CurrentThread.CurrentCulture;
            decimalSeparator = ci.NumberFormat.NumberDecimalSeparator;

            if (decimalSeparator == ".") wrong_decimalSeparator = ",";
            else if (decimalSeparator == ",") wrong_decimalSeparator = ".";
        }


        /// <summary>
        /// Zwraca wartość double niezależnie od separatora, rodzaj separator jest wykrywany
        /// </summary>
        /// <param name="str">łańcuch string - może być w notacji naukowej</param>
        /// <returns>skonwertowana liczba double</returns>
        public static double Str2Dbl(string str)
        {

            double p1d;
            double p2d = 0;

            bool parsed;

            string exponentialSymbol = "E";
            if (str.Contains("e")) exponentialSymbol = "e";

            if (str.Contains(exponentialSymbol))
            {
                Double.TryParse(str.Split(exponentialSymbol.ToCharArray())[0].Replace(wrong_decimalSeparator, decimalSeparator), out p1d);
                parsed = Double.TryParse(str.Split(exponentialSymbol.ToCharArray())[1].Replace(wrong_decimalSeparator, decimalSeparator), out p2d);

            }
            else
            {
                parsed = Double.TryParse(str.Replace(wrong_decimalSeparator, decimalSeparator), out p1d);
            }

            if (!parsed)
            {
                throw new ValueInvalidException(str);
            }

            if (str.Contains("E"))
                return p1d * Math.Pow(10, p2d);
            else return p1d;

        }

        public static int Str2Int(string str)
        {
            double val = Str2Dbl(str);

            double diff = Math.Abs(Math.Truncate(val) - val);
            if (diff > 0.0000001) throw new ValueNotIntegerException(str);

            return (int)val;

        }


        /// <summary>
        ///   Applies a function to every element of the array.
        /// </summary>
        ///// 
        //public static TResult[] Apply<TInput, TResult>(this TInput[] vector, Func<TInput, int, TResult> func)
        //{
        //    return Apply(vector, func, new TResult[vector.Length]);
        //}


        /// <summary>
        ///   Applies a function to every element of the array.
        /// </summary>
        /// 
        public static TResult[] Apply<TInput, TResult>(this TInput[] vector, Func<TInput, int, TResult> func)
        {
            TResult[] result = new TResult[vector.Length];

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

        public static Bitmap GetImageDownscaled(Bitmap loadedImage)
        {
            Bitmap retImage;

            int imageMaxSize = 500;
            int newHeight;
            int newWidth;
            if (loadedImage.Width > imageMaxSize || loadedImage.Height > imageMaxSize)
            {
                double imageRatio = (double)loadedImage.Width / loadedImage.Height;
                if (loadedImage.Width > loadedImage.Height)
                {
                    newWidth = imageMaxSize;
                    newHeight = (int)((double)imageMaxSize / imageRatio);
                }
                else
                {
                    newHeight = imageMaxSize;
                    newWidth = (int)((double)imageMaxSize * imageRatio);
                }

                UnmanagedImage unmanagedImage = UnmanagedImage.FromManagedImage(loadedImage);

                ResizeBicubic resizeFilter = new ResizeBicubic(newWidth, newHeight);
                UnmanagedImage tempImage = resizeFilter.Apply(unmanagedImage);

                retImage = tempImage.ToManagedImage();

            }
            else
            {
                retImage = loadedImage;
            }

            return retImage;
        }
    }

    public class ValueInvalidException : Exception
    {
        public ValueInvalidException()
        { }
        public ValueInvalidException(string message) : base(message) { }
        public ValueInvalidException(string message, Exception inner) : base(message, inner) { }
    }

    public class ValueNotIntegerException : Exception
    {
        public ValueNotIntegerException()
        { }
        public ValueNotIntegerException(string message) : base(message) { }
        public ValueNotIntegerException(string message, Exception inner) : base(message, inner) { }
    }

}
