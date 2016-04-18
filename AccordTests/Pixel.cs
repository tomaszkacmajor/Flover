using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccordTests
{
    class Pixel
    {
        public Pixel(MyRGB color, int x, int y)
        {
            Color = color;
            Point = new Point(x, y);
        }

        public MyRGB Color { get; set; }
        public Point Point { get; set; }
               
        public int SegmentInd { get; set; }

        public MaskTypes  MaskType { get; set; }

        public int Alpha { get; set; }
    }

  

    struct MyRGB
    {
        public MyRGB(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
    }
}
