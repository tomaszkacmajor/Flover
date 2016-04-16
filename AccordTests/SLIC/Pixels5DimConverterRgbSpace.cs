using System.Drawing;

namespace AccordTests.SLIC
{
    class Pixels5DimConverterRgbSpace : IPixels5DimConverter
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
}
