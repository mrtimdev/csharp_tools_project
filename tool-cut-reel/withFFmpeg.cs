using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using FFMpegCore;
using FFMpegCore.Enums;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using FFMpegCore.Exceptions;


namespace tool_cut_reel
{
    public partial class withFFmpeg : Form
    {
        private BackgroundWorker backgroundWorker;

        // private string ffmpegPath = @"C:\ffmpeg\ffmpeg.exe";
        public withFFmpeg()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            // Initialize ComboBox1 (already exists in your form designer)
            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox1.Items.AddRange(new string[]
            {
                "Rotate 90 degrees: -vf transpose=1",
                "Flip horizontally: -vf hflip",
                "Custom Brightness/Contrast/Saturation"
            });
            ComboBox1.SelectedIndex = 0;
            lblStatus.Text = "";
        }

        private async void btnEditVideo_Click(object sender, EventArgs e)
        {
            string[] inputFiles = txtInputFile.Lines;
            if (inputFiles?.Length == 0)
            {
                MessageBox.Show("Please specify at least one input file.");
                return;
            }

            string outputFolder = @"D:\TimDev\Tools\output\"; // Set the output folder path

            foreach (string inputFile in inputFiles)
            {
                string fileName = Path.GetFileName(inputFile);
                string outputFile = Path.Combine(outputFolder, fileName);
                if (File.Exists(outputFile))
                {
                    File.Delete(outputFile);
                }
                await EditVideo(inputFile, outputFile);
            }

            lblStatus.Text = "All videos edited.";
        }

        private async Task EditVideo(string inputFile, string outputFile)
        {
            string filterChain = BuildFilterChain();
            string ffmpegPath = @"C:\ffmpeg\ffmpeg.exe";
            try
            {
                await FFMpegArguments
                    .FromFileInput(inputFile)
                    .OutputToFile(outputFile, true, options => options
                        .WithVideoCodec(VideoCodec.LibX264)
                        .WithCustomArgument($"-vf \"{filterChain}\""))
                    .ProcessAsynchronously();

                lblStatus.Text = "Video editing completed.";
            }
            catch (FFMpegException ex)
            {
                lblStatus.Text = $"Error editing video: {ex.Message}";
                Console.WriteLine($"FFMpeg error: {ex.Message}");
                Console.WriteLine($"FFMpeg output: {ex.Data["ffmpeg-stderr"]}");
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Unexpected error: {ex.Message}";
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        private string BuildFilterChain()
        {
            string filterChain = string.Empty;

            if (float.TryParse(txtBrightness.Text, out float brightness))
            {
                filterChain += $"eq=brightness={brightness}";
            }
            if (float.TryParse(txtContrast.Text, out float contrast))
            {
                if (!string.IsNullOrEmpty(filterChain))
                    filterChain += ",";
                filterChain += $"eq=contrast={contrast}";
            }
            if (float.TryParse(txtSaturation.Text, out float saturation))
            {
                if (!string.IsNullOrEmpty(filterChain))
                    filterChain += ",";
                filterChain += $"eq=saturation={saturation}";
            }

            // Add flip options if checked
            if (checkBoxHflip.Checked)
            {
                if (!string.IsNullOrEmpty(filterChain))
                    filterChain += ",";
                filterChain += "hflip";
            }
            if (checkBoxVflip.Checked)
            {
                if (!string.IsNullOrEmpty(filterChain))
                    filterChain += ",";
                filterChain += "vflip";
            }

            return filterChain;
        }

        private void btnGetCheckBox_Click(object sender, EventArgs e)
        {
            string filterChain = string.Empty;
            if (checkBoxHflip.Checked)
            {
                filterChain += ",hflip";
            }
            if (checkBoxVflip.Checked)
            {
                filterChain += ",vflip";
            }
            MessageBox.Show("Get check ," + filterChain);
        }

        private void checkBoxHflip_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHflip.Checked)
            {
                checkBoxVflip.Checked = false;
            }
        }

        private void checkBoxVflip_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVflip.Checked)
            {
                checkBoxHflip.Checked = false;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mov;*.mkv|All Files|*.*";
                openFileDialog.Title = "Select Video Files";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        txtInputFile.AppendText(fileName + Environment.NewLine);
                    }
                }
            }
        }

        private void btnOpenOutputFolder_Click(object sender, EventArgs e)
        {
            string outputFolder = @"D:\TimDev\Tools\output\";
            if (Directory.Exists(outputFolder))
            {
                System.Diagnostics.Process.Start("explorer.exe", outputFolder);
            }
            else
            {
                lblStatus.Text = "Output folder does not exist.";
            }
        }
    }
}
