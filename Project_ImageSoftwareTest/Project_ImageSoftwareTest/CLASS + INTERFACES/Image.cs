using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_ImageSoftwareTest
{
    public class Image : Interface_Image
    {
        Bitmap originalBitmap = null;

        //Get image method defined in the interface
        //Called by the Business Layer to get the image from the file name when user selects the image in the Dialog window
        public Bitmap getImage(string fileName)
        {
            try
            {
                StreamReader stream = new StreamReader(fileName);
                originalBitmap = (Bitmap) Bitmap.FromStream(stream.BaseStream);
                stream.Close();

                return originalBitmap;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
