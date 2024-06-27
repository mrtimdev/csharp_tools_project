namespace tool_cut_reel
{
    partial class withFFmpeg
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
            lblStatus = new Label();
            btnGetCheckBox = new Button();
            checkBoxVflip = new CheckBox();
            checkBoxHflip = new CheckBox();
            label2 = new Label();
            txtSaturation = new TextBox();
            label1 = new Label();
            txtContrast = new TextBox();
            Brightness = new Label();
            txtBrightness = new TextBox();
            ComboBox1 = new ComboBox();
            btnBrowse = new Button();
            txtInputFile = new TextBox();
            btnEditVideo = new Button();
            btnOpenOutputFolder = new Button();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(50, 366);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 20);
            lblStatus.TabIndex = 29;
            lblStatus.Text = "label3";
            // 
            // btnGetCheckBox
            // 
            btnGetCheckBox.Location = new Point(560, 287);
            btnGetCheckBox.Name = "btnGetCheckBox";
            btnGetCheckBox.Size = new Size(146, 34);
            btnGetCheckBox.TabIndex = 28;
            btnGetCheckBox.Text = "Get CheckBox";
            btnGetCheckBox.UseVisualStyleBackColor = true;
            btnGetCheckBox.Click += btnGetCheckBox_Click;
            // 
            // checkBoxVflip
            // 
            checkBoxVflip.AutoSize = true;
            checkBoxVflip.Cursor = Cursors.Hand;
            checkBoxVflip.Location = new Point(615, 107);
            checkBoxVflip.Name = "checkBoxVflip";
            checkBoxVflip.Size = new Size(119, 24);
            checkBoxVflip.TabIndex = 27;
            checkBoxVflip.Text = "Flip Vertically";
            checkBoxVflip.UseVisualStyleBackColor = true;
            // 
            // checkBoxHflip
            // 
            checkBoxHflip.AutoSize = true;
            checkBoxHflip.Cursor = Cursors.Hand;
            checkBoxHflip.Location = new Point(615, 65);
            checkBoxHflip.Name = "checkBoxHflip";
            checkBoxHflip.Size = new Size(140, 24);
            checkBoxHflip.TabIndex = 26;
            checkBoxHflip.Text = "Flip Horizontally";
            checkBoxHflip.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 146);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 25;
            label2.Text = "Saturation";
            // 
            // txtSaturation
            // 
            txtSaturation.Location = new Point(140, 143);
            txtSaturation.Name = "txtSaturation";
            txtSaturation.Size = new Size(120, 27);
            txtSaturation.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 111);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 23;
            label1.Text = "Contrast";
            // 
            // txtContrast
            // 
            txtContrast.Location = new Point(140, 108);
            txtContrast.Name = "txtContrast";
            txtContrast.Size = new Size(120, 27);
            txtContrast.TabIndex = 22;
            // 
            // Brightness
            // 
            Brightness.AutoSize = true;
            Brightness.Location = new Point(46, 78);
            Brightness.Name = "Brightness";
            Brightness.Size = new Size(77, 20);
            Brightness.TabIndex = 21;
            Brightness.Text = "Brightness";
            // 
            // txtBrightness
            // 
            txtBrightness.Location = new Point(140, 75);
            txtBrightness.Name = "txtBrightness";
            txtBrightness.Size = new Size(120, 27);
            txtBrightness.TabIndex = 20;
            // 
            // ComboBox1
            // 
            ComboBox1.FormattingEnabled = true;
            ComboBox1.Location = new Point(46, 196);
            ComboBox1.Name = "ComboBox1";
            ComboBox1.Size = new Size(265, 28);
            ComboBox1.TabIndex = 19;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(53, 287);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(146, 34);
            btnBrowse.TabIndex = 18;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // txtInputFile
            // 
            txtInputFile.Location = new Point(53, 242);
            txtInputFile.Name = "txtInputFile";
            txtInputFile.Size = new Size(146, 27);
            txtInputFile.TabIndex = 17;
            // 
            // btnEditVideo
            // 
            btnEditVideo.Location = new Point(240, 287);
            btnEditVideo.Name = "btnEditVideo";
            btnEditVideo.Size = new Size(146, 34);
            btnEditVideo.TabIndex = 16;
            btnEditVideo.Text = "Edit Video";
            btnEditVideo.UseVisualStyleBackColor = true;
            btnEditVideo.Click += btnEditVideo_Click;
            // 
            // btnOpenOutputFolder
            // 
            btnOpenOutputFolder.Location = new Point(246, 354);
            btnOpenOutputFolder.Name = "btnOpenOutputFolder";
            btnOpenOutputFolder.Size = new Size(138, 34);
            btnOpenOutputFolder.TabIndex = 30;
            btnOpenOutputFolder.Text = "Open Folder Edited";
            btnOpenOutputFolder.UseVisualStyleBackColor = true;
            btnOpenOutputFolder.Click += btnOpenOutputFolder_Click;
            // 
            // withFFmpeg
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOpenOutputFolder);
            Controls.Add(lblStatus);
            Controls.Add(btnGetCheckBox);
            Controls.Add(checkBoxVflip);
            Controls.Add(checkBoxHflip);
            Controls.Add(label2);
            Controls.Add(txtSaturation);
            Controls.Add(label1);
            Controls.Add(txtContrast);
            Controls.Add(Brightness);
            Controls.Add(txtBrightness);
            Controls.Add(ComboBox1);
            Controls.Add(btnBrowse);
            Controls.Add(txtInputFile);
            Controls.Add(btnEditVideo);
            Name = "withFFmpeg";
            Text = "FFmpeg";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStatus;
        private Button btnGetCheckBox;
        private CheckBox checkBoxVflip;
        private CheckBox checkBoxHflip;
        private Label label2;
        private TextBox txtSaturation;
        private Label label1;
        private TextBox txtContrast;
        private Label Brightness;
        private TextBox txtBrightness;
        private ComboBox ComboBox1;
        private Button btnBrowse;
        private TextBox txtInputFile;
        private Button btnEditVideo;
        private Button btnOpenOutputFolder;
    }
}