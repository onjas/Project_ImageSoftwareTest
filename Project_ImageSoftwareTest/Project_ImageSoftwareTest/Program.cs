using Project_ImageSoftwareTest.CLASS___INTERFACES;
using System;
using System.Windows.Forms;

namespace Project_ImageSoftwareTest
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //Create the interfaces with the corresponding classes
            Interface_Image imageInterface = new Image();
            Interface_Filters filtersInterface = new Filters();
            Interface_EdgeDetections edgeDetectionsInterface = new EdgeDetections();

            //Create the Business Layer with the imageInterface
            BusinessLayer business = new BusinessLayer(imageInterface, filtersInterface,edgeDetectionsInterface);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Create the form with the Business layer as a parameter
            Application.Run(new MainForm(business));
        }
    }
}
