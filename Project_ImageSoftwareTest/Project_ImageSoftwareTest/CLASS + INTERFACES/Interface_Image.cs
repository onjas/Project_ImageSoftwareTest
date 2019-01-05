using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ImageSoftwareTest
{
    public interface Interface_Image
    {
        Bitmap getImage(string fileName);
    }
}
