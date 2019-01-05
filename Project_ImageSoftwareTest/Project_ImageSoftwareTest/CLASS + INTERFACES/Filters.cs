using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ImageSoftwareTest.CLASS___INTERFACES
{
    public class Filters : Interface_Filters
    {
        private Bitmap resultBitmap = null;

        //Apply the Black & White filter
        public Bitmap blackWhiteFilter(Bitmap source)
        {
            resultBitmap = new Bitmap(source.Width, source.Height);

            int rgb;
            Color c;

            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    c = source.GetPixel(x, y);
                    rgb = (int)((c.R + c.G + c.B) / 3);
                    resultBitmap.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            }
            return resultBitmap;
        }

        //Apply the Night filter
        public Bitmap nightFilter(Bitmap source)
        {
            resultBitmap = new Bitmap(source.Width, source.Height);

            for(int i = 0; i < source.Width; i++)
            {
                for(int x = 0; x < source.Height; x++)
                {
                    Color c = source.GetPixel(i, x);
                    Color cLayer = Color.FromArgb(c.A / 1, c.R / 1, c.G / 25, c.B / 1);
                    resultBitmap.SetPixel(i, x, cLayer);
                }
            }
            return resultBitmap;
        }
    }
}
