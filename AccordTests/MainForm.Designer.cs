namespace AccordTests
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.workingImagePictureBox = new System.Windows.Forms.PictureBox();
            this.loadPictureBtn = new System.Windows.Forms.Button();
            this.fastDetectCornersBtn = new System.Windows.Forms.Button();
            this.fastDetectCornersThreshTrackBar = new System.Windows.Forms.TrackBar();
            this.fastCornerDetectionGroupBox = new System.Windows.Forms.GroupBox();
            this.harrisCornerDetectionGroupBox = new System.Windows.Forms.GroupBox();
            this.harrisDetectCornersBtn = new System.Windows.Forms.Button();
            this.harrisDetectCornersThreshTrackBar = new System.Windows.Forms.TrackBar();
            this.surfCornerDetectionGroupBox = new System.Windows.Forms.GroupBox();
            this.surfDetectCornersBtn = new System.Windows.Forms.Button();
            this.surfDetectCornersThreshTrackBar = new System.Windows.Forms.TrackBar();
            this.meanShiftBtn = new System.Windows.Forms.Button();
            this.resultImagePictureBox = new System.Windows.Forms.PictureBox();
            this.meanShiftSigmaTrackBar = new System.Windows.Forms.TrackBar();
            this.kMeansBtn = new System.Windows.Forms.Button();
            this.kMeansKTrackBar = new System.Windows.Forms.TrackBar();
            this.SLICBtn = new System.Windows.Forms.Button();
            this.SLICTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.workingImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastDetectCornersThreshTrackBar)).BeginInit();
            this.fastCornerDetectionGroupBox.SuspendLayout();
            this.harrisCornerDetectionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.harrisDetectCornersThreshTrackBar)).BeginInit();
            this.surfCornerDetectionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.surfDetectCornersThreshTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meanShiftSigmaTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kMeansKTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLICTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // workingImagePictureBox
            // 
            this.workingImagePictureBox.Location = new System.Drawing.Point(168, 14);
            this.workingImagePictureBox.Name = "workingImagePictureBox";
            this.workingImagePictureBox.Size = new System.Drawing.Size(463, 398);
            this.workingImagePictureBox.TabIndex = 0;
            this.workingImagePictureBox.TabStop = false;
            // 
            // loadPictureBtn
            // 
            this.loadPictureBtn.Location = new System.Drawing.Point(21, 14);
            this.loadPictureBtn.Name = "loadPictureBtn";
            this.loadPictureBtn.Size = new System.Drawing.Size(117, 27);
            this.loadPictureBtn.TabIndex = 1;
            this.loadPictureBtn.Text = "Load picture...";
            this.loadPictureBtn.UseVisualStyleBackColor = true;
            this.loadPictureBtn.Click += new System.EventHandler(this.loadPictureBtn_Click);
            // 
            // fastDetectCornersBtn
            // 
            this.fastDetectCornersBtn.Location = new System.Drawing.Point(9, 24);
            this.fastDetectCornersBtn.Name = "fastDetectCornersBtn";
            this.fastDetectCornersBtn.Size = new System.Drawing.Size(117, 27);
            this.fastDetectCornersBtn.TabIndex = 2;
            this.fastDetectCornersBtn.Text = "Detect Corners";
            this.fastDetectCornersBtn.UseVisualStyleBackColor = true;
            this.fastDetectCornersBtn.Click += new System.EventHandler(this.detectCornersBtn_Click);
            // 
            // fastDetectCornersThreshTrackBar
            // 
            this.fastDetectCornersThreshTrackBar.Location = new System.Drawing.Point(9, 57);
            this.fastDetectCornersThreshTrackBar.Maximum = 100;
            this.fastDetectCornersThreshTrackBar.Name = "fastDetectCornersThreshTrackBar";
            this.fastDetectCornersThreshTrackBar.Size = new System.Drawing.Size(117, 45);
            this.fastDetectCornersThreshTrackBar.TabIndex = 3;
            this.fastDetectCornersThreshTrackBar.Value = 40;
            // 
            // fastCornerDetectionGroupBox
            // 
            this.fastCornerDetectionGroupBox.Controls.Add(this.fastDetectCornersBtn);
            this.fastCornerDetectionGroupBox.Controls.Add(this.fastDetectCornersThreshTrackBar);
            this.fastCornerDetectionGroupBox.Location = new System.Drawing.Point(12, 53);
            this.fastCornerDetectionGroupBox.Name = "fastCornerDetectionGroupBox";
            this.fastCornerDetectionGroupBox.Size = new System.Drawing.Size(136, 105);
            this.fastCornerDetectionGroupBox.TabIndex = 4;
            this.fastCornerDetectionGroupBox.TabStop = false;
            this.fastCornerDetectionGroupBox.Text = "FAST Corner Detection";
            // 
            // harrisCornerDetectionGroupBox
            // 
            this.harrisCornerDetectionGroupBox.Controls.Add(this.harrisDetectCornersBtn);
            this.harrisCornerDetectionGroupBox.Controls.Add(this.harrisDetectCornersThreshTrackBar);
            this.harrisCornerDetectionGroupBox.Location = new System.Drawing.Point(12, 164);
            this.harrisCornerDetectionGroupBox.Name = "harrisCornerDetectionGroupBox";
            this.harrisCornerDetectionGroupBox.Size = new System.Drawing.Size(136, 105);
            this.harrisCornerDetectionGroupBox.TabIndex = 5;
            this.harrisCornerDetectionGroupBox.TabStop = false;
            this.harrisCornerDetectionGroupBox.Text = "Harris Corner Detection";
            // 
            // harrisDetectCornersBtn
            // 
            this.harrisDetectCornersBtn.Location = new System.Drawing.Point(9, 24);
            this.harrisDetectCornersBtn.Name = "harrisDetectCornersBtn";
            this.harrisDetectCornersBtn.Size = new System.Drawing.Size(117, 27);
            this.harrisDetectCornersBtn.TabIndex = 2;
            this.harrisDetectCornersBtn.Text = "Detect Corners";
            this.harrisDetectCornersBtn.UseVisualStyleBackColor = true;
            this.harrisDetectCornersBtn.Click += new System.EventHandler(this.harrisDetectCornersBtn_Click);
            // 
            // harrisDetectCornersThreshTrackBar
            // 
            this.harrisDetectCornersThreshTrackBar.Location = new System.Drawing.Point(9, 57);
            this.harrisDetectCornersThreshTrackBar.Maximum = 100000;
            this.harrisDetectCornersThreshTrackBar.Name = "harrisDetectCornersThreshTrackBar";
            this.harrisDetectCornersThreshTrackBar.Size = new System.Drawing.Size(117, 45);
            this.harrisDetectCornersThreshTrackBar.TabIndex = 3;
            this.harrisDetectCornersThreshTrackBar.Value = 20000;
            // 
            // surfCornerDetectionGroupBox
            // 
            this.surfCornerDetectionGroupBox.Controls.Add(this.surfDetectCornersBtn);
            this.surfCornerDetectionGroupBox.Controls.Add(this.surfDetectCornersThreshTrackBar);
            this.surfCornerDetectionGroupBox.Location = new System.Drawing.Point(12, 275);
            this.surfCornerDetectionGroupBox.Name = "surfCornerDetectionGroupBox";
            this.surfCornerDetectionGroupBox.Size = new System.Drawing.Size(136, 105);
            this.surfCornerDetectionGroupBox.TabIndex = 6;
            this.surfCornerDetectionGroupBox.TabStop = false;
            this.surfCornerDetectionGroupBox.Text = "SURF  Corner Detection";
            // 
            // surfDetectCornersBtn
            // 
            this.surfDetectCornersBtn.Location = new System.Drawing.Point(9, 24);
            this.surfDetectCornersBtn.Name = "surfDetectCornersBtn";
            this.surfDetectCornersBtn.Size = new System.Drawing.Size(117, 27);
            this.surfDetectCornersBtn.TabIndex = 2;
            this.surfDetectCornersBtn.Text = "Detect Corners";
            this.surfDetectCornersBtn.UseVisualStyleBackColor = true;
            this.surfDetectCornersBtn.Click += new System.EventHandler(this.surfDetectCornersBtn_Click);
            // 
            // surfDetectCornersThreshTrackBar
            // 
            this.surfDetectCornersThreshTrackBar.Location = new System.Drawing.Point(9, 57);
            this.surfDetectCornersThreshTrackBar.Name = "surfDetectCornersThreshTrackBar";
            this.surfDetectCornersThreshTrackBar.Size = new System.Drawing.Size(117, 45);
            this.surfDetectCornersThreshTrackBar.TabIndex = 3;
            this.surfDetectCornersThreshTrackBar.Value = 2;
            // 
            // meanShiftBtn
            // 
            this.meanShiftBtn.Location = new System.Drawing.Point(21, 386);
            this.meanShiftBtn.Name = "meanShiftBtn";
            this.meanShiftBtn.Size = new System.Drawing.Size(117, 26);
            this.meanShiftBtn.TabIndex = 7;
            this.meanShiftBtn.Text = "MeanShift";
            this.meanShiftBtn.UseVisualStyleBackColor = true;
            this.meanShiftBtn.Click += new System.EventHandler(this.meanShiftBtn_Click);
            // 
            // resultImagePictureBox
            // 
            this.resultImagePictureBox.Location = new System.Drawing.Point(655, 14);
            this.resultImagePictureBox.Name = "resultImagePictureBox";
            this.resultImagePictureBox.Size = new System.Drawing.Size(463, 398);
            this.resultImagePictureBox.TabIndex = 8;
            this.resultImagePictureBox.TabStop = false;
            // 
            // meanShiftSigmaTrackBar
            // 
            this.meanShiftSigmaTrackBar.Location = new System.Drawing.Point(21, 418);
            this.meanShiftSigmaTrackBar.Maximum = 1000;
            this.meanShiftSigmaTrackBar.Name = "meanShiftSigmaTrackBar";
            this.meanShiftSigmaTrackBar.Size = new System.Drawing.Size(117, 45);
            this.meanShiftSigmaTrackBar.TabIndex = 9;
            this.meanShiftSigmaTrackBar.Value = 2;
            // 
            // kMeansBtn
            // 
            this.kMeansBtn.Location = new System.Drawing.Point(21, 456);
            this.kMeansBtn.Name = "kMeansBtn";
            this.kMeansBtn.Size = new System.Drawing.Size(117, 26);
            this.kMeansBtn.TabIndex = 10;
            this.kMeansBtn.Text = "K-means";
            this.kMeansBtn.UseVisualStyleBackColor = true;
            this.kMeansBtn.Click += new System.EventHandler(this.kMeansBtn_Click);
            // 
            // kMeansKTrackBar
            // 
            this.kMeansKTrackBar.Location = new System.Drawing.Point(21, 488);
            this.kMeansKTrackBar.Maximum = 200;
            this.kMeansKTrackBar.Name = "kMeansKTrackBar";
            this.kMeansKTrackBar.Size = new System.Drawing.Size(117, 45);
            this.kMeansKTrackBar.TabIndex = 11;
            this.kMeansKTrackBar.Value = 50;
            // 
            // SLICBtn
            // 
            this.SLICBtn.Location = new System.Drawing.Point(21, 524);
            this.SLICBtn.Name = "SLICBtn";
            this.SLICBtn.Size = new System.Drawing.Size(117, 26);
            this.SLICBtn.TabIndex = 13;
            this.SLICBtn.Text = "SLIC";
            this.SLICBtn.UseVisualStyleBackColor = true;
            this.SLICBtn.Click += new System.EventHandler(this.SLICBtn_Click);
            // 
            // SLICTrackBar
            // 
            this.SLICTrackBar.LargeChange = 50;
            this.SLICTrackBar.Location = new System.Drawing.Point(21, 556);
            this.SLICTrackBar.Maximum = 200;
            this.SLICTrackBar.Name = "SLICTrackBar";
            this.SLICTrackBar.Size = new System.Drawing.Size(117, 45);
            this.SLICTrackBar.TabIndex = 14;
            this.SLICTrackBar.Value = 50;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 607);
            this.Controls.Add(this.SLICTrackBar);
            this.Controls.Add(this.SLICBtn);
            this.Controls.Add(this.kMeansKTrackBar);
            this.Controls.Add(this.kMeansBtn);
            this.Controls.Add(this.meanShiftSigmaTrackBar);
            this.Controls.Add(this.resultImagePictureBox);
            this.Controls.Add(this.meanShiftBtn);
            this.Controls.Add(this.surfCornerDetectionGroupBox);
            this.Controls.Add(this.harrisCornerDetectionGroupBox);
            this.Controls.Add(this.fastCornerDetectionGroupBox);
            this.Controls.Add(this.loadPictureBtn);
            this.Controls.Add(this.workingImagePictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.workingImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastDetectCornersThreshTrackBar)).EndInit();
            this.fastCornerDetectionGroupBox.ResumeLayout(false);
            this.fastCornerDetectionGroupBox.PerformLayout();
            this.harrisCornerDetectionGroupBox.ResumeLayout(false);
            this.harrisCornerDetectionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.harrisDetectCornersThreshTrackBar)).EndInit();
            this.surfCornerDetectionGroupBox.ResumeLayout(false);
            this.surfCornerDetectionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.surfDetectCornersThreshTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meanShiftSigmaTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kMeansKTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLICTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox workingImagePictureBox;
        private System.Windows.Forms.Button loadPictureBtn;
        private System.Windows.Forms.Button fastDetectCornersBtn;
        private System.Windows.Forms.TrackBar fastDetectCornersThreshTrackBar;
        private System.Windows.Forms.GroupBox fastCornerDetectionGroupBox;
        private System.Windows.Forms.GroupBox harrisCornerDetectionGroupBox;
        private System.Windows.Forms.Button harrisDetectCornersBtn;
        private System.Windows.Forms.TrackBar harrisDetectCornersThreshTrackBar;
        private System.Windows.Forms.GroupBox surfCornerDetectionGroupBox;
        private System.Windows.Forms.Button surfDetectCornersBtn;
        private System.Windows.Forms.TrackBar surfDetectCornersThreshTrackBar;
        private System.Windows.Forms.Button meanShiftBtn;
        private System.Windows.Forms.PictureBox resultImagePictureBox;
        private System.Windows.Forms.TrackBar meanShiftSigmaTrackBar;
        private System.Windows.Forms.Button kMeansBtn;
        private System.Windows.Forms.TrackBar kMeansKTrackBar;
        private System.Windows.Forms.Button SLICBtn;
        private System.Windows.Forms.TrackBar SLICTrackBar;
    }
}

