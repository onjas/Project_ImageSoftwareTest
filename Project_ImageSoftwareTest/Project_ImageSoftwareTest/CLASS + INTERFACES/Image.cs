using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Project_ImageSoftwareTest
{
    public class Image : Interface_Image
    {
        Bitmap originalBitmap = null;
        Bitmap savedBitmap = null;
        ImageFormat imageFormat = ImageFormat.Jpeg;

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

        //Save image method defined in the interface
        //Called by the business layer to save the bitmap with his filename provided by the save dialog window
        public Bitmap saveImage(string fileName, Bitmap savedBitmap)
        {
            this.savedBitmap = savedBitmap;

            try
            {
                string fileExtension = Path.GetExtension(fileName).ToUpper();

                if (fileExtension == "BMP")
                {
                    imageFormat = ImageFormat.Bmp;
                }
                else if (fileExtension == "PNG")
                {
                    imageFormat = ImageFormat.Png;
                }

                StreamWriter stream = new StreamWriter(fileName, false);
                savedBitmap.Save(stream.BaseStream, imageFormat);
                stream.Flush();
                stream.Close();

                return savedBitmap;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
