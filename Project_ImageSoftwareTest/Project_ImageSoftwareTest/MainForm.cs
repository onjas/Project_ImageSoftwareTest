using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_ImageSoftwareTest
{
    public partial class MainForm : Form
    {
        private Bitmap originalBitmap = null;
        private Bitmap filteredBitmap = null;
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private BusinessLayer businessLayer;


        public MainForm(BusinessLayer business)
        {
            this.businessLayer = business;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e){}



        //Event handler for the loading of the image
        private void loadImageBtn_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Select an image please";

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Call the method in the business layer which will call the method in the Image class that implements the interface
                    businessLayer.setOriginalBitmap(openFileDialog.FileName);
                    originalBitmap = Utils.CopyToSquareCanvas(businessLayer.getOriginalBitmap(), picturePreview.Width);
                    picturePreview.Image = originalBitmap;
                    picturePreview.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message,"Erreur",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }


        //Event handler to save the image
        private void saveImageBtn_Click(object sender, EventArgs e)
        {
            //To implement
        }


        //Event handler to apply filter
        private void FilterSelectedEventHandler(object sender, EventArgs e)
        {
            Bitmap previewBitmap = businessLayer.getOriginalBitmap();
            Bitmap resultBitmap = null;

            switch (filterCombobox.SelectedItem.ToString())
            {
                case "None":
                    resultBitmap = previewBitmap;
                    break;
                case "Night Filter":
                    resultBitmap = businessLayer.applyNightFilter(previewBitmap);
                    break;
                case "Black and White":
                    resultBitmap = businessLayer.applyBlackWhiteFilter(previewBitmap);
                    break;
            }

            filteredBitmap = Utils.CopyToSquareCanvas(resultBitmap, picturePreview.Width);
            picturePreview.Image = filteredBitmap;
            picturePreview.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
