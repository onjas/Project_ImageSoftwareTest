using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Project_ImageSoftwareTest
{
    public partial class MainForm : Form
    {
        private Bitmap originalBitmap = null;
        private Bitmap filteredBitmap = null;
        private Bitmap edgeDetectedBitmap = null;
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        private ImageFormat imageFormat = ImageFormat.Jpeg;
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

            if(picturePreview.Image != null)
            {
                filterCombobox.SelectedIndex = 0;
                edgeCombobox.SelectedIndex = 0;
                edgeCombobox.Enabled = false;
            }

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Call the method in the business layer which will call the method in the Image class that implements the interface
                    businessLayer.setOriginalBitmap(openFileDialog.FileName);
                    originalBitmap = Utils.CopyToSquareCanvas(businessLayer.getOriginalBitmap(), picturePreview.Width);
                    picturePreview.Image = originalBitmap;
                    picturePreview.SizeMode = PictureBoxSizeMode.Zoom;

                    filterCombobox.Enabled = true;
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
            //Check which bitmap we are going to save depending on the combobox
            Bitmap savedBitmap = null;

            if (edgeCombobox.SelectedItem.ToString().Equals("None"))
            {
                if (filterCombobox.SelectedItem.ToString().Equals("None"))
                {
                    savedBitmap = businessLayer.getOriginalBitmap();
                }
                else
                {
                    savedBitmap = businessLayer.getFilteredBitmap();
                }
            }
            else
            {
                savedBitmap = businessLayer.getEdgeDetectedBitmap();
            }

            saveFileDialog.Title = "Please specify a file name and choose the right directory";
            saveFileDialog.Filter = "Jpeg Images(*.jpg)|*.jpg|Png Images(*.png)|*.png|Bitmap Images(*.bmp)|*.bmp";

            if(saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    //Using the Business layer's method
                    businessLayer.saveImageInDirectory(saveFileDialog.FileName, savedBitmap);
                    savedBitmap = null;
                    MessageBox.Show("Image saved correctly !", "Save Method",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

            //We reset the whole forms' components so the User can apply new filters and edge detections on the selected image
            picturePreview.Image = originalBitmap;
            filterCombobox.SelectedIndex = 0;
            edgeCombobox.SelectedIndex = 0;
            edgeCombobox.Enabled = false;
        }


        //Event handler to apply filter
        private void FilterSelectedEventHandler(object sender, EventArgs e)
        {
            
            Bitmap previewBitmap = null;
            Bitmap resultBitmap = null;

            if (edgeCombobox.SelectedItem.ToString().Equals("None"))
            {
                previewBitmap = businessLayer.getOriginalBitmap();
            }
            else
            {
                previewBitmap = businessLayer.getEdgeDetectedBitmap();
            }

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

            //Enable the combo box of edge detection
            edgeCombobox.Enabled = true;
        }


        //Event handler to apply the Edge Detection
        private void EdgeDetectionSelectedEventHandler(object sender, EventArgs e)
        {
            Bitmap previewBitmap = null;
            Bitmap resultBitmap = null;

            //Test to use the right image to apply the Edge Detection
            //If the filter has not been selected by the user, the image to use will be the original one
            //Else, the edge detection will be applied on the image that has been already filtered
            if(filterCombobox.SelectedItem.ToString().Equals("None"))
            {
                previewBitmap = businessLayer.getOriginalBitmap();
            }
            else
            {
                previewBitmap = businessLayer.getFilteredBitmap();
            }

            switch (edgeCombobox.SelectedItem.ToString())
            {
                case "None":
                    resultBitmap = previewBitmap;
                    filterCombobox.Enabled = true;
                    break;
                case "Kirsch":
                    resultBitmap = businessLayer.applyKirschEdgeDetection(previewBitmap);
                    filterCombobox.Enabled = false;
                    break;
                case "Prewitt":
                    resultBitmap = businessLayer.applyPrewittEdgeDetection(previewBitmap);
                    filterCombobox.Enabled = false;
                    break;
            }

            edgeDetectedBitmap = Utils.CopyToSquareCanvas(resultBitmap, picturePreview.Width);
            picturePreview.Image = edgeDetectedBitmap;
            picturePreview.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
