using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ImageSoftwareTest.CLASS___INTERFACES
{
    public interface Interface_EdgeDetections
    {
        Bitmap kirschFilter(Bitmap sourceBitmap, bool grayscale = true);
        Bitmap prewittFilter(Bitmap sourceBitmap, bool grayscale = true);
    }
}
