using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ImageSoftwareTest.CLASS___INTERFACES
{
    public class EdgeDetections : Interface_EdgeDetections
    {
        public Bitmap kirschFilter(Bitmap sourceBitmap, bool grayscale = true)
        {
            Bitmap resultBitmap = Utils.ConvolutionFilter(sourceBitmap, Utils.Kirsch3x3Horizontal, Utils.Kirsch3x3Vertical, 1.0, 0, true);
            return resultBitmap;
        }

        public Bitmap prewittFilter(Bitmap sourceBitmap, bool grayscale = true)
        {
            Bitmap resultBitmap = Utils.ConvolutionFilter(sourceBitmap, Utils.Prewitt3x3Horizontal, Utils.Prewitt3x3Vertical, 1.0, 0, true);
            return resultBitmap;
        }
    }
}
