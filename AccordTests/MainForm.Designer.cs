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
            this.ValidationErrLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.noVectorsTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.noValidationVecTxtBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ComplexityTxtBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.KernelSigmaTxtBox = new System.Windows.Forms.TextBox();
            this.saveModelBtn = new System.Windows.Forms.Button();
            this.LoadModelBtn = new System.Windows.Forms.Button();
            this.CalcGMMBtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.NoTestingVectorsTxtBox = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.TestingErrLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
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
            this.button1.Location = new System.Drawing.Point(408, 575);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 27);
            this.button1.TabIndex = 29;
            this.button1.Text = "Load pictures...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(408, 604);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 26);
            this.button2.TabIndex = 30;
            this.button2.Text = "Segment All";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(816, 625);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 25);
            this.button4.TabIndex = 32;
            this.button4.Text = "Train All";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(816, 653);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Learn Err.";
            // 
            // LearnErrLabel
            // 
            this.LearnErrLabel.AutoSize = true;
            this.LearnErrLabel.Location = new System.Drawing.Point(900, 653);
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
            this.button5.Location = new System.Drawing.Point(1075, 571);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(117, 27);
            this.button5.TabIndex = 36;
            this.button5.Text = "Load test pictures...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1075, 599);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(117, 26);
            this.button7.TabIndex = 38;
            this.button7.Text = "Test";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // ValidationErrLabel
            // 
            this.ValidationErrLabel.AutoSize = true;
            this.ValidationErrLabel.Location = new System.Drawing.Point(900, 671);
            this.ValidationErrLabel.Name = "ValidationErrLabel";
            this.ValidationErrLabel.Size = new System.Drawing.Size(13, 13);
            this.ValidationErrLabel.TabIndex = 40;
            this.ValidationErrLabel.Text = "_";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(816, 671);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Validation Err.";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(408, 634);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 26);
            this.button3.TabIndex = 41;
            this.button3.Text = "Save Features";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(545, 575);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(133, 26);
            this.button6.TabIndex = 42;
            this.button6.Text = "Load and Split data";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // noVectorsTxtBox
            // 
            this.noVectorsTxtBox.Location = new System.Drawing.Point(632, 604);
            this.noVectorsTxtBox.Name = "noVectorsTxtBox";
            this.noVectorsTxtBox.Size = new System.Drawing.Size(46, 20);
            this.noVectorsTxtBox.TabIndex = 43;
            this.noVectorsTxtBox.Text = "2000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(548, 604);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "No. vectors";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(533, 627);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "No. validation vec";
            // 
            // noValidationVecTxtBox
            // 
            this.noValidationVecTxtBox.Location = new System.Drawing.Point(632, 627);
            this.noValidationVecTxtBox.Name = "noValidationVecTxtBox";
            this.noValidationVecTxtBox.Size = new System.Drawing.Size(46, 20);
            this.noValidationVecTxtBox.TabIndex = 45;
            this.noValidationVecTxtBox.Text = "1000";
            this.noValidationVecTxtBox.TextChanged += new System.EventHandler(this.noTestingVecTxtBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(816, 598);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Complexity";
            // 
            // ComplexityTxtBox
            // 
            this.ComplexityTxtBox.Location = new System.Drawing.Point(900, 598);
            this.ComplexityTxtBox.Name = "ComplexityTxtBox";
            this.ComplexityTxtBox.Size = new System.Drawing.Size(46, 20);
            this.ComplexityTxtBox.TabIndex = 49;
            this.ComplexityTxtBox.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(816, 575);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "Kernel Gamma";
            // 
            // KernelSigmaTxtBox
            // 
            this.KernelSigmaTxtBox.Location = new System.Drawing.Point(900, 575);
            this.KernelSigmaTxtBox.Name = "KernelSigmaTxtBox";
            this.KernelSigmaTxtBox.Size = new System.Drawing.Size(46, 20);
            this.KernelSigmaTxtBox.TabIndex = 47;
            this.KernelSigmaTxtBox.Text = "0.08";
            // 
            // saveModelBtn
            // 
            this.saveModelBtn.Location = new System.Drawing.Point(952, 571);
            this.saveModelBtn.Name = "saveModelBtn";
            this.saveModelBtn.Size = new System.Drawing.Size(117, 27);
            this.saveModelBtn.TabIndex = 51;
            this.saveModelBtn.Text = "Save Model";
            this.saveModelBtn.UseVisualStyleBackColor = true;
            this.saveModelBtn.Click += new System.EventHandler(this.saveModelBtn_Click);
            // 
            // LoadModelBtn
            // 
            this.LoadModelBtn.Location = new System.Drawing.Point(952, 599);
            this.LoadModelBtn.Name = "LoadModelBtn";
            this.LoadModelBtn.Size = new System.Drawing.Size(117, 27);
            this.LoadModelBtn.TabIndex = 52;
            this.LoadModelBtn.Text = "Load Model";
            this.LoadModelBtn.UseVisualStyleBackColor = true;
            this.LoadModelBtn.Click += new System.EventHandler(this.LoadModelBtn_Click);
            // 
            // CalcGMMBtn
            // 
            this.CalcGMMBtn.Location = new System.Drawing.Point(262, 694);
            this.CalcGMMBtn.Name = "CalcGMMBtn";
            this.CalcGMMBtn.Size = new System.Drawing.Size(126, 27);
            this.CalcGMMBtn.TabIndex = 53;
            this.CalcGMMBtn.Text = "Calc GMM";
            this.CalcGMMBtn.UseVisualStyleBackColor = true;
            this.CalcGMMBtn.Click += new System.EventHandler(this.CalcGMMBtn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(533, 648);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "No. testing vec";
            // 
            // NoTestingVectorsTxtBox
            // 
            this.NoTestingVectorsTxtBox.Location = new System.Drawing.Point(632, 648);
            this.NoTestingVectorsTxtBox.Name = "NoTestingVectorsTxtBox";
            this.NoTestingVectorsTxtBox.Size = new System.Drawing.Size(46, 20);
            this.NoTestingVectorsTxtBox.TabIndex = 54;
            this.NoTestingVectorsTxtBox.Text = "1000";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(684, 575);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(126, 26);
            this.button8.TabIndex = 56;
            this.button8.Text = "Load learn vectors";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(684, 603);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(126, 26);
            this.button9.TabIndex = 57;
            this.button9.Text = "Load validation vectors";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(684, 629);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(126, 26);
            this.button10.TabIndex = 58;
            this.button10.Text = "Load testing vectors";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(819, 710);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(127, 33);
            this.button11.TabIndex = 59;
            this.button11.Text = "GridSearch SVM";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(262, 721);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(126, 26);
            this.button12.TabIndex = 60;
            this.button12.Text = "Eliminate similar vectors";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // TestingErrLabel
            // 
            this.TestingErrLabel.AutoSize = true;
            this.TestingErrLabel.Location = new System.Drawing.Point(900, 688);
            this.TestingErrLabel.Name = "TestingErrLabel";
            this.TestingErrLabel.Size = new System.Drawing.Size(13, 13);
            this.TestingErrLabel.TabIndex = 62;
            this.TestingErrLabel.Text = "_";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(816, 688);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 61;
            this.label12.Text = "Testing Err.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1656, 759);
            this.Controls.Add(this.TestingErrLabel);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.NoTestingVectorsTxtBox);
            this.Controls.Add(this.CalcGMMBtn);
            this.Controls.Add(this.LoadModelBtn);
            this.Controls.Add(this.saveModelBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ComplexityTxtBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.KernelSigmaTxtBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.noValidationVecTxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.noVectorsTxtBox);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ValidationErrLabel);
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
            this.Load += new System.EventHandler(this.MainForm_Load);
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
        private System.Windows.Forms.Label ValidationErrLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox noVectorsTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox noValidationVecTxtBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ComplexityTxtBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox KernelSigmaTxtBox;
        private System.Windows.Forms.Button saveModelBtn;
        private System.Windows.Forms.Button LoadModelBtn;
        private System.Windows.Forms.Button CalcGMMBtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox NoTestingVectorsTxtBox;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Label TestingErrLabel;
        private System.Windows.Forms.Label label12;
    }
}

