using System.Drawing;

namespace Project_ImageSoftwareTest.CLASS___INTERFACES
{
    public interface Interface_EdgeDetections
    {
        Bitmap kirschFilter(Bitmap sourceBitmap, bool grayscale = true);
        Bitmap prewittFilter(Bitmap sourceBitmap, bool grayscale = true);
    }
}
