using System;

namespace Project_ImageSoftwareTest
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.picturePreview = new System.Windows.Forms.PictureBox();
            this.loadImageBtn = new System.Windows.Forms.Button();
            this.filterLabel = new System.Windows.Forms.Label();
            this.filterCombobox = new System.Windows.Forms.ComboBox();
            this.edgeLabel = new System.Windows.Forms.Label();
            this.edgeCombobox = new System.Windows.Forms.ComboBox();
            this.saveImageBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // picturePreview
            // 
            this.picturePreview.BackColor = System.Drawing.Color.Transparent;
            this.picturePreview.Location = new System.Drawing.Point(12, 12);
            this.picturePreview.Name = "picturePreview";
            this.picturePreview.Size = new System.Drawing.Size(1443, 796);
            this.picturePreview.TabIndex = 0;
            this.picturePreview.TabStop = false;
            // 
            // loadImageBtn
            // 
            this.loadImageBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.loadImageBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.loadImageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadImageBtn.Location = new System.Drawing.Point(12, 842);
            this.loadImageBtn.Name = "loadImageBtn";
            this.loadImageBtn.Size = new System.Drawing.Size(205, 130);
            this.loadImageBtn.TabIndex = 1;
            this.loadImageBtn.Text = "Load Image";
            this.loadImageBtn.UseVisualStyleBackColor = false;
            this.loadImageBtn.Click += new System.EventHandler(this.loadImageBtn_Click);
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterLabel.Location = new System.Drawing.Point(309, 842);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(168, 29);
            this.filterLabel.TabIndex = 2;
            this.filterLabel.Text = "Choose a filter";
            // 
            // filterCombobox
            // 
            this.filterCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterCombobox.FormattingEnabled = true;
            this.filterCombobox.Items.AddRange(new object[]
            {
                "None",
                "Black and White",
                "Night Filter"
            });
            this.filterCombobox.Location = new System.Drawing.Point(314, 894);
            this.filterCombobox.Name = "filterCombobox";
            this.filterCombobox.Size = new System.Drawing.Size(276, 34);
            this.filterCombobox.TabIndex = 3;
            this.filterCombobox.SelectedIndex = 0;
            this.filterCombobox.SelectedIndexChanged += new System.EventHandler(this.FilterSelectedEventHandler);
            // 
            // edgeLabel
            // 
            this.edgeLabel.AutoSize = true;
            this.edgeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edgeLabel.Location = new System.Drawing.Point(812, 842);
            this.edgeLabel.Name = "edgeLabel";
            this.edgeLabel.Size = new System.Drawing.Size(296, 29);
            this.edgeLabel.TabIndex = 4;
            this.edgeLabel.Text = "Choose an edge detection";
            // 
            // edgeCombobox
            // 
            this.edgeCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edgeCombobox.FormattingEnabled = true;
            this.edgeCombobox.Location = new System.Drawing.Point(817, 894);
            this.edgeCombobox.Name = "edgeCombobox";
            this.edgeCombobox.Size = new System.Drawing.Size(320, 34);
            this.edgeCombobox.TabIndex = 5;
            // 
            // saveImageBtn
            // 
            this.saveImageBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.saveImageBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.saveImageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveImageBtn.Location = new System.Drawing.Point(1250, 842);
            this.saveImageBtn.Name = "saveImageBtn";
            this.saveImageBtn.Size = new System.Drawing.Size(205, 130);
            this.saveImageBtn.TabIndex = 6;
            this.saveImageBtn.Text = "Save Image";
            this.saveImageBtn.UseVisualStyleBackColor = false;
            this.saveImageBtn.Click += new System.EventHandler(this.saveImageBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 997);
            this.Controls.Add(this.saveImageBtn);
            this.Controls.Add(this.edgeCombobox);
            this.Controls.Add(this.edgeLabel);
            this.Controls.Add(this.filterCombobox);
            this.Controls.Add(this.filterLabel);
            this.Controls.Add(this.loadImageBtn);
            this.Controls.Add(this.picturePreview);
            this.Name = "MainForm";
            this.Text = "Image Edge detection & Filtering";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picturePreview;
        private System.Windows.Forms.Button loadImageBtn;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.ComboBox filterCombobox;
        private System.Windows.Forms.Label edgeLabel;
        private System.Windows.Forms.ComboBox edgeCombobox;
        private System.Windows.Forms.Button saveImageBtn;
    }
}

