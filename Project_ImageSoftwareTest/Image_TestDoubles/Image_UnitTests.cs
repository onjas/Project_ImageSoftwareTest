using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_ImageSoftwareTest;
using NSubstitute;
using System.Drawing;
using Project_ImageSoftwareTest.CLASS___INTERFACES;

namespace Image_TestDoubles
{
    [TestClass]
    public class Image_UnitTests
    {

        //Standard test of the input method file (image) with a new empty bitmap
        [TestMethod]
        public void InputFileStandard()
        {
            //Create interfaces used in Business layer
            var imageInterface = Substitute.For<Interface_Image>();
            var filterInterface = Substitute.For<Interface_Filters>();

            BusinessLayer business = new BusinessLayer(imageInterface,filterInterface);
            imageInterface.getImage("nameOfFile").Returns<Bitmap>(new Bitmap(500, 500));
            business.setOriginalBitmap("nameOfFile");
            
            Assert.IsNotNull(business.getOriginalBitmap());
        }

        //Exception test of the input method file (image), throws an exception and check with Assert using a boolean variable
        [TestMethod]
        public void InputFile_ExceptionThrown()
        {
            //Create interfaces used in Business layer
            var imageInterface = Substitute.For<Interface_Image>();
            var filterInterface = Substitute.For<Interface_Filters>();


            imageInterface
                .When(x => x.getImage(Arg.Any<string>()))
                .Do(x => { throw new System.Exception(); });

            BusinessLayer business = new BusinessLayer(imageInterface, filterInterface);
            business.setOriginalBitmap("qwertz");

            Assert.AreEqual(business.inputFileException, true);
        }


        //Test the black and white filter
        [TestMethod]
        public void BlackWhiteFilter()
        {
            //Create interfaces used in Business layer
            var imageInterface = Substitute.For<Interface_Image>();
            var filterInterface = Substitute.For<Interface_Filters>();

            Bitmap bitmap = new Bitmap(100, 100);
            Bitmap resultInterf = null;

            BusinessLayer business = new BusinessLayer(imageInterface, filterInterface);
            resultInterf = filterInterface.blackWhiteFilter(bitmap);
            business.applyBlackWhiteFilter(bitmap);

            Assert.AreEqual(resultInterf,business.getFilteredBitmap());
        }

        //Test the night filter
        [TestMethod]
        public void NightFilter()
        {
            //Create interfaces used in Business layer
            var imageInterface = Substitute.For<Interface_Image>();
            var filterInterface = Substitute.For<Interface_Filters>();

            Bitmap bitmap = new Bitmap(100, 100);
            Bitmap resultInterf = null;

            BusinessLayer business = new BusinessLayer(imageInterface, filterInterface);
            resultInterf = filterInterface.nightFilter(bitmap);
            business.applyNightFilter(bitmap);

            Assert.AreEqual(resultInterf, business.getFilteredBitmap());
        }

    }
}
