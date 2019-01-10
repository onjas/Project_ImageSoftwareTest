using Project_ImageSoftwareTest.CLASS___INTERFACES;
using System;
using System.Drawing;

namespace Project_ImageSoftwareTest
{
    public class BusinessLayer
    {
        //The three stages of the bitmap possible
        // --> Original // Filtered or not // EdgeDetected or not
        private Bitmap originalBitmap;
        private Bitmap filteredBitmap;
        private Bitmap edgeDetectedBitmap;

        private Bitmap savedBitmap;

        //Interfaces
        private readonly Interface_Image imageInterface;
        private readonly Interface_Filters filtersInterface;
        private readonly Interface_EdgeDetections edgeDetectionsInterface;

        //Boolean to test if exception thrown or not
        public Boolean inputFileException = false;
        public Boolean outputFileException = false;


        //Constructor
        //**************
        public BusinessLayer(Interface_Image imageInterface, Interface_Filters filtersInterface, Interface_EdgeDetections edgeDetectionsInterface)
        {
            this.imageInterface = imageInterface;
            this.filtersInterface = filtersInterface;
            this.edgeDetectionsInterface = edgeDetectionsInterface;
        }


        //Business Methods
        //********************

        //Method to set the OriginalBitmap displayed in the Image Box
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
        //Method to get the originalBitmap
        public Bitmap getOriginalBitmap()
        {
            return originalBitmap;
        }



        //Method to apply the Black & White filter
        public Bitmap applyBlackWhiteFilter(Bitmap sourceBitmap)
        {
            filteredBitmap = filtersInterface.blackWhiteFilter(sourceBitmap);
            return filteredBitmap;
        }
        //Method to apply the Night Filter
        public Bitmap applyNightFilter(Bitmap sourceBitmap)
        {
            filteredBitmap = filtersInterface.nightFilter(sourceBitmap);
            return filteredBitmap;
        }
        //Method to get the Filtered Bitmap
        public Bitmap getFilteredBitmap()
        {
            return filteredBitmap;
        }



        //Method to apply the Kirsch Filter - Edge Detection
        public Bitmap applyKirschEdgeDetection(Bitmap sourceBitmap)
        {
            edgeDetectedBitmap = edgeDetectionsInterface.kirschFilter(sourceBitmap);
            return edgeDetectedBitmap;
        }
        //Method to apply the Prewitt Filter - Edge Detection
        public Bitmap applyPrewittEdgeDetection(Bitmap sourceBitmap)
        {
            edgeDetectedBitmap = edgeDetectionsInterface.prewittFilter(sourceBitmap);
            return edgeDetectedBitmap;
        }
        //Method to get the EdgeDetected Bitmap
        public Bitmap getEdgeDetectedBitmap()
        {
            return edgeDetectedBitmap;
        }


        //Method to save the image
        public void saveImageInDirectory(string fileName, Bitmap bitmapToSave)
        {
            try
            {
                savedBitmap = imageInterface.saveImage(fileName, bitmapToSave);
            }
            catch(Exception e)
            {
                outputFileException = true;
                Console.WriteLine(e.Message);
            }
        }
        //Method to get the saved image
        public Bitmap getSavedImage()
        {
            return savedBitmap;
        }

    }
}
