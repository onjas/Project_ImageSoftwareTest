using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_ImageSoftwareTest;
using NSubstitute;
using System.Drawing;
using Project_ImageSoftwareTest.CLASS___INTERFACES;
using Image_TestDoubles.Properties;

namespace Image_TestDoubles
{
    [TestClass]
    public class Image_UnitTests
    {
        //Create interfaces used in Business layer
        Interface_Image imageInterface = Substitute.For<Interface_Image>();
        Interface_Filters filterInterface = Substitute.For<Interface_Filters>();
        Interface_EdgeDetections edgeDetectionInterface = Substitute.For<Interface_EdgeDetections>();

        //Standard test of the input method file (image) with a new empty bitmap
        [TestMethod]
        public void InputFileStandard()
        {
            BusinessLayer business = new BusinessLayer(imageInterface,filterInterface,edgeDetectionInterface);
            imageInterface.getImage("nameOfFile").Returns<Bitmap>(new Bitmap(500, 500));
            business.setOriginalBitmap("nameOfFile");
            
            Assert.IsNotNull(business.getOriginalBitmap());
        }

        //Exception test of the input method file (image), throws an exception and check with Assert using a boolean variable
        [TestMethod]
        public void InputFile_ExceptionThrown()
        {
            imageInterface
                .When(x => x.getImage(Arg.Any<string>()))
                .Do(x => { throw new System.Exception(); });

            BusinessLayer business = new BusinessLayer(imageInterface, filterInterface, edgeDetectionInterface);
            business.setOriginalBitmap("qwertz");

            Assert.AreEqual(true,business.inputFileException);
        }


        //Test the black and white filter
        [TestMethod]
        public void BlackWhiteFilter()
        {
            //Get a real image to test the method instead of using a new empty bitmap !
            Bitmap bitmap = Resources.No_filter;
            Bitmap resultInterf = null;

            BusinessLayer business = new BusinessLayer(imageInterface, filterInterface, edgeDetectionInterface);
            resultInterf = filterInterface.blackWhiteFilter(bitmap);
            business.applyBlackWhiteFilter(bitmap);

            Assert.AreEqual(business.getFilteredBitmap(), resultInterf);
        }


        //Test the night filter
        [TestMethod]
        public void NightFilter()
        {
            //Get a real image to test the method instead of using a new empty bitmap !
            Bitmap bitmap = Resources.No_filter;
            Bitmap resultInterf = null;

            BusinessLayer business = new BusinessLayer(imageInterface, filterInterface, edgeDetectionInterface);
            resultInterf = filterInterface.nightFilter(bitmap);
            business.applyNightFilter(bitmap);

            Assert.AreEqual(business.getFilteredBitmap(),resultInterf);
        }


        //Test the Kirsch Filter - Edge Detection
        [TestMethod]
        public void KirschFilter()
        {
            //Get a real image to test the method instead of using a new empty bitmap !
            Bitmap bitmap = Resources.No_filter;
            Bitmap resultInterf = null;

            BusinessLayer business = new BusinessLayer(imageInterface, filterInterface, edgeDetectionInterface);
            resultInterf = edgeDetectionInterface.kirschFilter(bitmap);
            business.applyKirschEdgeDetection(bitmap);

            Assert.AreEqual(business.getEdgeDetectedBitmap(), resultInterf);
        }


        //Test the Prewitt Filter - Edge Detection
        [TestMethod]
        public void PrewittFilter()
        {
            //Get a real image to test the method instead of using a new empty bitmap !
            Bitmap bitmap = Resources.No_filter;
            Bitmap resultInterf = null;

            BusinessLayer business = new BusinessLayer(imageInterface, filterInterface, edgeDetectionInterface);
            resultInterf = edgeDetectionInterface.prewittFilter(bitmap);
            business.applyPrewittEdgeDetection(bitmap);

            Assert.AreEqual(business.getEdgeDetectedBitmap(), resultInterf);
        }




        //Test the output file method (saving)
        [TestMethod]
        public void OutputFileMethod()
        {
            Bitmap bitmap = new Bitmap(300, 300);
            BusinessLayer business = new BusinessLayer(imageInterface, filterInterface, edgeDetectionInterface);
            imageInterface.saveImage("TestMethod_UnitTest", bitmap).Returns<Bitmap>(bitmap);
            business.saveImageInDirectory("TestMethod_UnitTest", bitmap);

            Assert.IsNotNull(business.getSavedImage());
        }

        //Raise an exception in the Output file method (saving)
        [TestMethod]
        public void OutputFileMethod_ExceptionThrown()
        {
            imageInterface
                .When(x => x.saveImage(Arg.Any<string>(),Arg.Any<Bitmap>()))
                .Do(x => { throw new System.Exception(); });

            BusinessLayer business = new BusinessLayer(imageInterface, filterInterface, edgeDetectionInterface);
            business.saveImageInDirectory("asdf",new Bitmap(100,100));

            Assert.AreEqual(true,business.outputFileException);
        }

    }
}
