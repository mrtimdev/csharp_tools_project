using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace tool_cut_reel
{
    public partial class Home : Form
    {
        private BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ProgressBar progressBar;

        private string ffmpegPath = @"C:\ffmpeg\ffmpeg.exe";

        public Home()
        {
            InitializeComponent();
            //InitializeBackgroundWorker();
            InitializeControls();
        }

        private void InitializeControls()
        {
            // Initialize ComboBox1 (already exists in your form designer)
            selectFolder.Enabled = false;
            lblStatus.Text = "";
        }

        /*private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true; // Enable cancellation support

            backgroundWorker.DoWork += (sender, e) =>
            {

                dynamic args = e.Argument;
                string inputFile = args.InputFile;
                string outputFile = args.OutputFile;
                string arguments = args.Arguments;

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = ffmpegPath,
                        Arguments = arguments,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                process.OutputDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        Console.WriteLine(e.Data);
                    }
                };

                process.ErrorDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        Console.WriteLine("ERROR: " + e.Data);
                    }
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                process.WaitForExit();
            };

            if (backgroundWorker.IsBusy)
            {
                MessageBox.Show("Background IsBusy-.");
            }

            backgroundWorker.ProgressChanged += (sender, e) =>
            {
                progressBar.Value = e.ProgressPercentage;
                lblProgressValue.Text = $"{e.ProgressPercentage}%"; // Update the label with progress
                
            };

            backgroundWorker.RunWorkerCompleted += (sender, e) =>
            {
                if (e.Cancelled)
                {
                    lblStatus.Text = "Operation cancelled.";
                }
                else if (e.Error != null)
                {
                    lblStatus.Text = "Error occurred: " + e.Error.Message;
                }
                else
                {
                    lblStatus.Text = "All videos edited.";
                    MessageBox.Show("Background proccessing--.");
                }
            };
        } */

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

        private void btnEditVideo_Click(object sender, EventArgs e)
        {
            string[] inputFiles = txtInputFile.Lines;
            if (inputFiles?.Length == 0)
            {
                MessageBox.Show("Please specify at least one input file.");
                return;
            }
            if(string.IsNullOrEmpty(selectFolder.Text))
            {
                MessageBox.Show("Please specify your folder for save file.");
                return;
            }
            selectSavePath.Enabled = false;
            string outputFolder = @$"{selectFolder.Text}";
            //InitializeBackgroundWorker();
            foreach (string inputFile in inputFiles)
            {
                if (backgroundWorker.CancellationPending)
                {
                    lblStatus.Text = "Operation cancelled.";
                    return;
                }

                string fileName = Path.GetFileName(inputFile);
                string outputFile = Path.Combine(outputFolder, fileName);
                if (File.Exists(outputFile))
                {
                    File.Delete(outputFile);
                }
                EditVideo(inputFile, outputFile);
            }
            txtInputFile.Text = string.Empty;
            selectSavePath.Enabled = true;
            lblStatus.Text = "All videos edited.";
        }

        private void EditVideo(string inputFile, string outputFile)
        {
            
            string arguments = string.Empty;
            string filterChain = string.Empty;
            string flipValue = string.Empty;
            List<string> filterChainComponents = new List<string>();
            List<string> flipValues = new List<string>();

            if (float.TryParse(txtBrightness.Text, out float brightness))
            {
                filterChain = $"eq=brightness={brightness}";
            }
            if (float.TryParse(txtContrast.Text, out float contrast))
            {
                if (!string.IsNullOrEmpty(filterChain))
                    filterChain += $":contrast={contrast}";
                else
                    filterChain += $"eq=contrast={contrast}";
            }
            if (float.TryParse(txtSaturation.Text, out float saturation))
            {
                if (!string.IsNullOrEmpty(filterChain))
                    filterChain += $":saturation={saturation}";
                else
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

            if (string.IsNullOrEmpty(filterChain))
            {
                arguments = $"-i {inputFile} {outputFile}";
            }
            else
            {
                arguments = $"-i {inputFile} -vf {filterChain} {outputFile}";
            }


            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ffmpegPath,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.OutputDataReceived += (sender, e) =>
            {
                MessageBox.Show("Background OutputDataReceived.");
                if (e.Data != null)
                {
                    // Log output if needed
                    Console.WriteLine(e.Data);
                    
                }
            };

            process.ErrorDataReceived += (sender, e) =>
            {
                if (e.Data != null)
                {
                    // Log errors if needed
                    Console.WriteLine("ERROR: " + e.Data);
                }
            };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            process.WaitForExit();

            lblStatus.Text = "Video editing completed.";
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



        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            selectSavePath.Enabled = true;
            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
                lblStatus.Text = "Cancelling...";
            }
        }

        

        private void openEditedFolder_Click(object sender, EventArgs e)
        {
            string outputFolder = selectFolder.Text;
            if (Directory.Exists(outputFolder))
            {
                System.Diagnostics.Process.Start("explorer.exe", outputFolder);
            }
            else
            {
                lblStatus.Text = "Output folder does not exist.";
            }
        }

        private void selectSavePath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select Output Folder";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    selectFolder.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }
    }
}
