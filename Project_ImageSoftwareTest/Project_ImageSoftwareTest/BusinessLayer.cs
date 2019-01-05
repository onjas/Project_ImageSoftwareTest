using Project_ImageSoftwareTest.CLASS___INTERFACES;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ImageSoftwareTest
{
    public class BusinessLayer
    {
        private Bitmap originalBitmap;
        private Bitmap filteredBitmap;
        private readonly Interface_Image imageInterface;
        private readonly Interface_Filters filtersInterface;

        //Boolean to test if exception thrown or not
        public Boolean inputFileException = false;

        public BusinessLayer(Interface_Image imageInterface, Interface_Filters filtersInterface)
        {
            this.imageInterface = imageInterface;
            this.filtersInterface = filtersInterface;
        }

        public void setOriginalBitmap(string fileName)
        {
            try
            {
                originalBitmap = imageInterface.getImage(fileName);
            }
            catch(System.Exception e)
            {
                inputFileException = true;
                Console.WriteLine(e.Message);
            }
        }

        public Bitmap getOriginalBitmap()
        {
            return originalBitmap;
        }

        public Bitmap applyBlackWhiteFilter(Bitmap sourceBitmap)
        {
            filteredBitmap = filtersInterface.blackWhiteFilter(sourceBitmap);
            return filteredBitmap;
        }

        public Bitmap applyNightFilter(Bitmap sourceBitmap)
        {
            filteredBitmap = filtersInterface.nightFilter(sourceBitmap);
            return filteredBitmap;
        }

        public Bitmap getFilteredBitmap()
        {
            return filteredBitmap;
        }
    }
}
