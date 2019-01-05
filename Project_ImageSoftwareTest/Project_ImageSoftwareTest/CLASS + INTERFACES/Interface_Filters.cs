using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ImageSoftwareTest.CLASS___INTERFACES
{
    public interface Interface_Filters
    {
        Bitmap nightFilter(Bitmap source);
        Bitmap blackWhiteFilter(Bitmap source);
    }
}
