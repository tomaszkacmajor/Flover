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
            ((System.ComponentModel.ISupportInitialize)(this.workingImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastDetectCornersThreshTrackBar)).BeginInit();
            this.fastCornerDetectionGroupBox.SuspendLayout();
            this.harrisCornerDetectionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.harrisDetectCornersThreshTrackBar)).BeginInit();
            this.surfCornerDetectionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.surfDetectCornersThreshTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // workingImagePictureBox
            // 
            this.workingImagePictureBox.Location = new System.Drawing.Point(168, 14);
            this.workingImagePictureBox.Name = "workingImagePictureBox";
            this.workingImagePictureBox.Size = new System.Drawing.Size(707, 530);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 583);
            this.Controls.Add(this.surfCornerDetectionGroupBox);
            this.Controls.Add(this.harrisCornerDetectionGroupBox);
            this.Controls.Add(this.fastCornerDetectionGroupBox);
            this.Controls.Add(this.loadPictureBtn);
            this.Controls.Add(this.workingImagePictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
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
            this.ResumeLayout(false);

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
    }
}

