namespace UVRasterizer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxRasterizedImage = new System.Windows.Forms.PictureBox();
            this.buttonLoadOBJ = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRasterizedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxRasterizedImage
            // 
            this.pictureBoxRasterizedImage.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxRasterizedImage.Name = "pictureBoxRasterizedImage";
            this.pictureBoxRasterizedImage.Size = new System.Drawing.Size(512, 512);
            this.pictureBoxRasterizedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRasterizedImage.TabIndex = 0;
            this.pictureBoxRasterizedImage.TabStop = false;
            // 
            // buttonLoadOBJ
            // 
            this.buttonLoadOBJ.Location = new System.Drawing.Point(530, 12);
            this.buttonLoadOBJ.Name = "buttonLoadOBJ";
            this.buttonLoadOBJ.Size = new System.Drawing.Size(140, 39);
            this.buttonLoadOBJ.TabIndex = 1;
            this.buttonLoadOBJ.Text = "Browse .OBJ";
            this.buttonLoadOBJ.UseVisualStyleBackColor = true;
            this.buttonLoadOBJ.Click += new System.EventHandler(this.buttonLoadOBJ_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 889);
            this.Controls.Add(this.buttonLoadOBJ);
            this.Controls.Add(this.pictureBoxRasterizedImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "UVRasterizer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRasterizedImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxRasterizedImage;
        private System.Windows.Forms.Button buttonLoadOBJ;
    }
}

