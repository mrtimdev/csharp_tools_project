using System.ComponentModel;

namespace tool_cut_reel
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnEditVideo = new Button();
            txtInputFile = new TextBox();
            btnBrowse = new Button();
            txtBrightness = new TextBox();
            Brightness = new Label();
            label1 = new Label();
            txtContrast = new TextBox();
            label2 = new Label();
            txtSaturation = new TextBox();
            checkBoxHflip = new CheckBox();
            checkBoxVflip = new CheckBox();
            lblStatus = new Label();
            btnCancelEdit = new Button();
            lblProgressValue = new Label();
            openEditedFolder = new Button();
            selectSavePath = new Button();
            selectFolder = new Label();
            SuspendLayout();
            // 
            // btnEditVideo
            // 
            btnEditVideo.BackColor = Color.Green;
            btnEditVideo.ForeColor = SystemColors.ControlLightLight;
            btnEditVideo.Location = new Point(164, 396);
            btnEditVideo.Name = "btnEditVideo";
            btnEditVideo.Size = new Size(146, 34);
            btnEditVideo.TabIndex = 0;
            btnEditVideo.Text = "Edit Video";
            btnEditVideo.UseVisualStyleBackColor = false;
            btnEditVideo.Click += btnEditVideo_Click;
            // 
            // txtInputFile
            // 
            txtInputFile.Location = new Point(12, 363);
            txtInputFile.Name = "txtInputFile";
            txtInputFile.Size = new Size(146, 27);
            txtInputFile.TabIndex = 1;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.FromArgb(0, 192, 192);
            btnBrowse.ForeColor = SystemColors.ControlLightLight;
            btnBrowse.Location = new Point(12, 396);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(146, 34);
            btnBrowse.TabIndex = 4;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // txtBrightness
            // 
            txtBrightness.Location = new Point(113, 87);
            txtBrightness.Name = "txtBrightness";
            txtBrightness.Size = new Size(120, 27);
            txtBrightness.TabIndex = 6;
            // 
            // Brightness
            // 
            Brightness.AutoSize = true;
            Brightness.Location = new Point(19, 90);
            Brightness.Name = "Brightness";
            Brightness.Size = new Size(77, 20);
            Brightness.TabIndex = 7;
            Brightness.Text = "Brightness";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 123);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 9;
            label1.Text = "Contrast";
            // 
            // txtContrast
            // 
            txtContrast.Location = new Point(113, 120);
            txtContrast.Name = "txtContrast";
            txtContrast.Size = new Size(120, 27);
            txtContrast.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 158);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 11;
            label2.Text = "Saturation";
            // 
            // txtSaturation
            // 
            txtSaturation.Location = new Point(113, 155);
            txtSaturation.Name = "txtSaturation";
            txtSaturation.Size = new Size(120, 27);
            txtSaturation.TabIndex = 10;
            // 
            // checkBoxHflip
            // 
            checkBoxHflip.AutoSize = true;
            checkBoxHflip.Cursor = Cursors.Hand;
            checkBoxHflip.Location = new Point(588, 77);
            checkBoxHflip.Name = "checkBoxHflip";
            checkBoxHflip.Size = new Size(140, 24);
            checkBoxHflip.TabIndex = 12;
            checkBoxHflip.Text = "Flip Horizontally";
            checkBoxHflip.UseVisualStyleBackColor = true;
            checkBoxHflip.CheckedChanged += checkBoxHflip_CheckedChanged;
            // 
            // checkBoxVflip
            // 
            checkBoxVflip.AutoSize = true;
            checkBoxVflip.Cursor = Cursors.Hand;
            checkBoxVflip.Location = new Point(588, 119);
            checkBoxVflip.Name = "checkBoxVflip";
            checkBoxVflip.Size = new Size(119, 24);
            checkBoxVflip.TabIndex = 13;
            checkBoxVflip.Text = "Flip Vertically";
            checkBoxVflip.UseVisualStyleBackColor = true;
            checkBoxVflip.CheckedChanged += checkBoxVflip_CheckedChanged;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(12, 328);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 20);
            lblStatus.TabIndex = 15;
            // 
            // btnCancelEdit
            // 
            btnCancelEdit.BackColor = Color.Firebrick;
            btnCancelEdit.ForeColor = SystemColors.ControlLightLight;
            btnCancelEdit.Location = new Point(316, 396);
            btnCancelEdit.Name = "btnCancelEdit";
            btnCancelEdit.Size = new Size(164, 34);
            btnCancelEdit.TabIndex = 17;
            btnCancelEdit.Text = "Cancel Edit";
            btnCancelEdit.UseVisualStyleBackColor = false;
            btnCancelEdit.Click += btnCancelEdit_Click;
            // 
            // lblProgressValue
            // 
            lblProgressValue.AutoSize = true;
            lblProgressValue.Location = new Point(182, 216);
            lblProgressValue.Name = "lblProgressValue";
            lblProgressValue.Size = new Size(79, 20);
            lblProgressValue.TabIndex = 18;
            lblProgressValue.Text = "Processing";
            // 
            // openEditedFolder
            // 
            openEditedFolder.BackColor = Color.SteelBlue;
            openEditedFolder.ForeColor = SystemColors.ControlLightLight;
            openEditedFolder.Location = new Point(624, 396);
            openEditedFolder.Name = "openEditedFolder";
            openEditedFolder.Size = new Size(164, 34);
            openEditedFolder.TabIndex = 20;
            openEditedFolder.Text = "Open Edited";
            openEditedFolder.UseVisualStyleBackColor = false;
            openEditedFolder.Click += openEditedFolder_Click;
            // 
            // selectSavePath
            // 
            selectSavePath.BackColor = Color.Green;
            selectSavePath.ForeColor = SystemColors.ControlLightLight;
            selectSavePath.Location = new Point(307, 253);
            selectSavePath.Name = "selectSavePath";
            selectSavePath.Size = new Size(146, 34);
            selectSavePath.TabIndex = 21;
            selectSavePath.Text = "Save Path";
            selectSavePath.UseVisualStyleBackColor = false;
            selectSavePath.Click += selectSavePath_Click;
            // 
            // selectFolder
            // 
            selectFolder.AutoSize = true;
            selectFolder.Location = new Point(307, 230);
            selectFolder.Name = "selectFolder";
            selectFolder.Size = new Size(0, 20);
            selectFolder.TabIndex = 22;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1219, 437);
            Controls.Add(selectFolder);
            Controls.Add(selectSavePath);
            Controls.Add(openEditedFolder);
            Controls.Add(lblProgressValue);
            Controls.Add(btnCancelEdit);
            Controls.Add(lblStatus);
            Controls.Add(checkBoxVflip);
            Controls.Add(checkBoxHflip);
            Controls.Add(label2);
            Controls.Add(txtSaturation);
            Controls.Add(label1);
            Controls.Add(txtContrast);
            Controls.Add(Brightness);
            Controls.Add(txtBrightness);
            Controls.Add(btnBrowse);
            Controls.Add(txtInputFile);
            Controls.Add(btnEditVideo);
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tim Dev v1.1.0";
            WindowState = FormWindowState.Minimized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEditVideo;
        private TextBox txtInputFile;
        private Button btnBrowse;
        private TextBox txtBrightness;
        private Label Brightness;
        private Label label1;
        private TextBox txtContrast;
        private Label label2;
        private TextBox txtSaturation;
        private CheckBox checkBoxHflip;
        private CheckBox checkBoxVflip;
        private Label lblStatus;
        private Button btnCancelEdit;
        private Label lblProgressValue;
        private Button openEditedFolder;
        private Button selectSavePath;
        private Label selectFolder;
    }
}
