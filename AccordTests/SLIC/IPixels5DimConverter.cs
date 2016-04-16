using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccordTests.SLIC
{
    interface IPixels5DimConverter
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
}
