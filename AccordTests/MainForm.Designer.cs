﻿namespace AccordTests
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.spatialConsTrackBar = new System.Windows.Forms.TrackBar();
            this.spatialConsistencyLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.noSegmentsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.applyEdgesChkBox = new System.Windows.Forms.CheckBox();
            this.randomColorSegmentsChkBox = new System.Windows.Forms.CheckBox();
            this.SegmentFGBGBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LearnErrLabel = new System.Windows.Forms.Label();
            this.FGBGErrorLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.TestErrLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spatialConsTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // workingImagePictureBox
            // 
            this.workingImagePictureBox.Location = new System.Drawing.Point(168, 14);
            this.workingImagePictureBox.Name = "workingImagePictureBox";
            this.workingImagePictureBox.Size = new System.Drawing.Size(739, 554);
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
            this.meanShiftBtn.Location = new System.Drawing.Point(6, 19);
            this.meanShiftBtn.Name = "meanShiftBtn";
            this.meanShiftBtn.Size = new System.Drawing.Size(117, 26);
            this.meanShiftBtn.TabIndex = 7;
            this.meanShiftBtn.Text = "MeanShift";
            this.meanShiftBtn.UseVisualStyleBackColor = true;
            this.meanShiftBtn.Click += new System.EventHandler(this.meanShiftBtn_Click);
            // 
            // resultImagePictureBox
            // 
            this.resultImagePictureBox.Location = new System.Drawing.Point(913, 14);
            this.resultImagePictureBox.Name = "resultImagePictureBox";
            this.resultImagePictureBox.Size = new System.Drawing.Size(739, 554);
            this.resultImagePictureBox.TabIndex = 8;
            this.resultImagePictureBox.TabStop = false;
            // 
            // meanShiftSigmaTrackBar
            // 
            this.meanShiftSigmaTrackBar.Location = new System.Drawing.Point(6, 51);
            this.meanShiftSigmaTrackBar.Maximum = 1000;
            this.meanShiftSigmaTrackBar.Name = "meanShiftSigmaTrackBar";
            this.meanShiftSigmaTrackBar.Size = new System.Drawing.Size(117, 45);
            this.meanShiftSigmaTrackBar.TabIndex = 9;
            this.meanShiftSigmaTrackBar.Value = 2;
            // 
            // kMeansBtn
            // 
            this.kMeansBtn.Location = new System.Drawing.Point(6, 89);
            this.kMeansBtn.Name = "kMeansBtn";
            this.kMeansBtn.Size = new System.Drawing.Size(117, 26);
            this.kMeansBtn.TabIndex = 10;
            this.kMeansBtn.Text = "K-means";
            this.kMeansBtn.UseVisualStyleBackColor = true;
            this.kMeansBtn.Click += new System.EventHandler(this.kMeansBtn_Click);
            // 
            // kMeansKTrackBar
            // 
            this.kMeansKTrackBar.Location = new System.Drawing.Point(6, 121);
            this.kMeansKTrackBar.Maximum = 200;
            this.kMeansKTrackBar.Name = "kMeansKTrackBar";
            this.kMeansKTrackBar.Size = new System.Drawing.Size(117, 45);
            this.kMeansKTrackBar.TabIndex = 11;
            this.kMeansKTrackBar.Value = 50;
            // 
            // SLICBtn
            // 
            this.SLICBtn.Location = new System.Drawing.Point(17, 119);
            this.SLICBtn.Name = "SLICBtn";
            this.SLICBtn.Size = new System.Drawing.Size(210, 26);
            this.SLICBtn.TabIndex = 13;
            this.SLICBtn.Text = "Segment";
            this.SLICBtn.UseVisualStyleBackColor = true;
            this.SLICBtn.Click += new System.EventHandler(this.SLICBtn_Click);
            // 
            // SLICTrackBar
            // 
            this.SLICTrackBar.LargeChange = 50;
            this.SLICTrackBar.Location = new System.Drawing.Point(142, 10);
            this.SLICTrackBar.Maximum = 300;
            this.SLICTrackBar.Name = "SLICTrackBar";
            this.SLICTrackBar.Size = new System.Drawing.Size(85, 45);
            this.SLICTrackBar.TabIndex = 14;
            this.SLICTrackBar.Value = 200;
            this.SLICTrackBar.Scroll += new System.EventHandler(this.SLICTrackBar_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.kMeansBtn);
            this.groupBox1.Controls.Add(this.meanShiftBtn);
            this.groupBox1.Controls.Add(this.meanShiftSigmaTrackBar);
            this.groupBox1.Controls.Add(this.kMeansKTrackBar);
            this.groupBox1.Location = new System.Drawing.Point(12, 386);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 172);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Segmentation";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.spatialConsTrackBar);
            this.groupBox2.Controls.Add(this.spatialConsistencyLabel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.SLICBtn);
            this.groupBox2.Controls.Add(this.noSegmentsLabel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.applyEdgesChkBox);
            this.groupBox2.Controls.Add(this.randomColorSegmentsChkBox);
            this.groupBox2.Controls.Add(this.SLICTrackBar);
            this.groupBox2.Location = new System.Drawing.Point(12, 564);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 157);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SLIC";
            // 
            // spatialConsTrackBar
            // 
            this.spatialConsTrackBar.LargeChange = 10;
            this.spatialConsTrackBar.Location = new System.Drawing.Point(141, 42);
            this.spatialConsTrackBar.Maximum = 60;
            this.spatialConsTrackBar.Minimum = 1;
            this.spatialConsTrackBar.Name = "spatialConsTrackBar";
            this.spatialConsTrackBar.Size = new System.Drawing.Size(87, 45);
            this.spatialConsTrackBar.TabIndex = 18;
            this.spatialConsTrackBar.Value = 50;
            this.spatialConsTrackBar.Scroll += new System.EventHandler(this.spatialConsTrackBar_Scroll);
            // 
            // spatialConsistencyLabel
            // 
            this.spatialConsistencyLabel.AutoSize = true;
            this.spatialConsistencyLabel.Location = new System.Drawing.Point(122, 53);
            this.spatialConsistencyLabel.Name = "spatialConsistencyLabel";
            this.spatialConsistencyLabel.Size = new System.Drawing.Size(19, 13);
            this.spatialConsistencyLabel.TabIndex = 22;
            this.spatialConsistencyLabel.Text = "50";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Spatial consistency:";
            // 
            // noSegmentsLabel
            // 
            this.noSegmentsLabel.AutoSize = true;
            this.noSegmentsLabel.Location = new System.Drawing.Point(112, 25);
            this.noSegmentsLabel.Name = "noSegmentsLabel";
            this.noSegmentsLabel.Size = new System.Drawing.Size(25, 13);
            this.noSegmentsLabel.TabIndex = 20;
            this.noSegmentsLabel.Text = "200";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "No. segments:";
            // 
            // applyEdgesChkBox
            // 
            this.applyEdgesChkBox.AutoSize = true;
            this.applyEdgesChkBox.Location = new System.Drawing.Point(17, 78);
            this.applyEdgesChkBox.Name = "applyEdgesChkBox";
            this.applyEdgesChkBox.Size = new System.Drawing.Size(85, 17);
            this.applyEdgesChkBox.TabIndex = 16;
            this.applyEdgesChkBox.Text = "Apply Edges";
            this.applyEdgesChkBox.UseVisualStyleBackColor = true;
            // 
            // randomColorSegmentsChkBox
            // 
            this.randomColorSegmentsChkBox.AutoSize = true;
            this.randomColorSegmentsChkBox.Location = new System.Drawing.Point(17, 96);
            this.randomColorSegmentsChkBox.Name = "randomColorSegmentsChkBox";
            this.randomColorSegmentsChkBox.Size = new System.Drawing.Size(143, 17);
            this.randomColorSegmentsChkBox.TabIndex = 17;
            this.randomColorSegmentsChkBox.Text = "Random Color Segments";
            this.randomColorSegmentsChkBox.UseVisualStyleBackColor = true;
            // 
            // SegmentFGBGBtn
            // 
            this.SegmentFGBGBtn.Location = new System.Drawing.Point(262, 574);
            this.SegmentFGBGBtn.Name = "SegmentFGBGBtn";
            this.SegmentFGBGBtn.Size = new System.Drawing.Size(103, 27);
            this.SegmentFGBGBtn.TabIndex = 28;
            this.SegmentFGBGBtn.Text = "Segment FG/BG";
            this.SegmentFGBGBtn.UseVisualStyleBackColor = true;
            this.SegmentFGBGBtn.Click += new System.EventHandler(this.SegmentFGBGBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(460, 574);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 27);
            this.button1.TabIndex = 29;
            this.button1.Text = "Load pictures...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(460, 603);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 26);
            this.button2.TabIndex = 30;
            this.button2.Text = "Segment All";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(460, 630);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 27);
            this.button4.TabIndex = 32;
            this.button4.Text = "Train All";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(457, 660);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Learn Err.";
            // 
            // LearnErrLabel
            // 
            this.LearnErrLabel.AutoSize = true;
            this.LearnErrLabel.Location = new System.Drawing.Point(516, 660);
            this.LearnErrLabel.Name = "LearnErrLabel";
            this.LearnErrLabel.Size = new System.Drawing.Size(13, 13);
            this.LearnErrLabel.TabIndex = 33;
            this.LearnErrLabel.Text = "_";
            // 
            // FGBGErrorLabel
            // 
            this.FGBGErrorLabel.AutoSize = true;
            this.FGBGErrorLabel.Location = new System.Drawing.Point(318, 609);
            this.FGBGErrorLabel.Name = "FGBGErrorLabel";
            this.FGBGErrorLabel.Size = new System.Drawing.Size(13, 13);
            this.FGBGErrorLabel.TabIndex = 35;
            this.FGBGErrorLabel.Text = "_";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 609);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Err.";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(583, 574);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(117, 27);
            this.button5.TabIndex = 36;
            this.button5.Text = "Load test pictures...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(583, 603);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(117, 26);
            this.button7.TabIndex = 38;
            this.button7.Text = "Test";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // TestErrLabel
            // 
            this.TestErrLabel.AutoSize = true;
            this.TestErrLabel.Location = new System.Drawing.Point(652, 637);
            this.TestErrLabel.Name = "TestErrLabel";
            this.TestErrLabel.Size = new System.Drawing.Size(13, 13);
            this.TestErrLabel.TabIndex = 40;
            this.TestErrLabel.Text = "_";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(593, 637);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Test Err.";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(790, 574);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 26);
            this.button3.TabIndex = 41;
            this.button3.Text = "Save Features";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(790, 602);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(117, 26);
            this.button6.TabIndex = 42;
            this.button6.Text = "Load Features";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1656, 736);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.TestErrLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.FGBGErrorLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LearnErrLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SegmentFGBGBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.resultImagePictureBox);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spatialConsTrackBar)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar spatialConsTrackBar;
        private System.Windows.Forms.Label spatialConsistencyLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label noSegmentsLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox applyEdgesChkBox;
        private System.Windows.Forms.CheckBox randomColorSegmentsChkBox;
        private System.Windows.Forms.Button SegmentFGBGBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LearnErrLabel;
        private System.Windows.Forms.Label FGBGErrorLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label TestErrLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button3;
    }
}

