using System.Drawing;

namespace Project_ImageSoftwareTest
{
    public interface Interface_Image
    {
        Bitmap getImage(string fileName);
        Bitmap saveImage(string fileName, Bitmap savedBitmap);
    }
}
