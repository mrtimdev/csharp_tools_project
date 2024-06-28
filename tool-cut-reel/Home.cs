using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace tool_cut_reel
{
    public partial class Home : Form
    {
        private BackgroundWorker backgroundWorker;
        private ProgressBar progressBar;
        private string ffmpegPath = @"C:\ffmpeg\ffmpeg.exe";

        public Home()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            progressBar = new ProgressBar
            {
                Minimum = 0,
                Maximum = 100,
                Value = 0
            };

            selectFolder.Enabled = false;
            lblStatus.Text = "";
            labelShowMessage.Text = "";

            backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mov;*.mkv|All Files|*.*";
                openFileDialog.Title = "Select Video Files";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (var fileName in openFileDialog.FileNames)
                    {
                        txtInputFile.AppendText(fileName + Environment.NewLine);
                    }
                }
            }
        }

        private void btnEditVideo_Click(object sender, EventArgs e)
        {
            var inputFiles = txtInputFile.Lines;
            if (inputFiles.Length == 0)
            {
                MessageBox.Show("Please specify at least one input file.");
                return;
            }
            if (string.IsNullOrEmpty(selectFolder.Text))
            {
                MessageBox.Show("Please specify your folder for save file.");
                return;
            }
            selectSavePath.Enabled = false;
            var outputFolder = selectFolder.Text;

            if (!backgroundWorker.IsBusy)
            {
                progressBar.Value = 0;
                backgroundWorker.RunWorkerAsync(new { inputFiles, outputFolder });
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var data = (dynamic)e.Argument;
            var inputFiles = data.inputFiles;
            var outputFolder = data.outputFolder;

            int fileIndex = 0;
            foreach (var inputFile in inputFiles)
            {
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                var fileName = Path.GetFileName(inputFile);
                var outputFile = Path.Combine(outputFolder, fileName);
                if (File.Exists(outputFile))
                {
                    File.Delete(outputFile);
                }
                EditVideo(inputFile, outputFile, fileIndex + 1, inputFiles.Length);
                RemoveProcessedFile(inputFile, fileName);
                fileIndex++;
            }
        }

        private void RemoveProcessedFile(string processedFile, string fileName)
        {
            // Invoke to update the UI control on the main thread
            if (txtInputFile.InvokeRequired)
            {
                txtInputFile.Invoke(new MethodInvoker(() => RemoveProcessedFile(processedFile, fileName)));
            }
            else
            {
                var lines = txtInputFile.Lines.ToList();
                lines.Remove(processedFile);
                txtInputFile.Lines = lines.ToArray();
                labelShowMessage.Text = $"Completed: {fileName}";
            }
        }

        private void EditVideo(string inputFile, string outputFile, int currentFileIndex, int totalFiles)
        {
            var filterChain = GenerateFilterChain();
            var arguments = string.IsNullOrEmpty(filterChain) ? $"-i \"{inputFile}\" \"{outputFile}\"" : $"-i \"{inputFile}\" -vf \"{filterChain}\" \"{outputFile}\"";

            using (var process = new Process
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
            })
            {
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
                        ParseProgress(e.Data, currentFileIndex, totalFiles, inputFile);
                        Console.WriteLine("ERROR: " + e.Data);
                    }
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                while (!process.HasExited)
                {
                    if (backgroundWorker.CancellationPending)
                    {
                        process.Kill();
                        break;
                    }
                }
                process.WaitForExit();
            }
        }

        private string GenerateFilterChain()
        {
            var filterChain = string.Empty;

            if (float.TryParse(txtBrightness.Text, out var brightness))
            {
                filterChain = $"eq=brightness={brightness}";
            }
            if (float.TryParse(txtContrast.Text, out var contrast))
            {
                filterChain += string.IsNullOrEmpty(filterChain) ? $"eq=contrast={contrast}" : $":contrast={contrast}";
            }
            if (float.TryParse(txtSaturation.Text, out var saturation))
            {
                filterChain += string.IsNullOrEmpty(filterChain) ? $"eq=saturation={saturation}" : $":saturation={saturation}";
            }
            if (checkBoxHflip.Checked)
            {
                filterChain += string.IsNullOrEmpty(filterChain) ? "hflip" : ",hflip";
            }
            if (checkBoxVflip.Checked)
            {
                filterChain += string.IsNullOrEmpty(filterChain) ? "vflip" : ",vflip";
            }

            return filterChain;
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progressValue = e.ProgressPercentage;
            if (progressValue > progressBar.Maximum)
            {
                progressValue = progressBar.Maximum;
            }
            else if (progressValue < progressBar.Minimum)
            {
                progressValue = progressBar.Minimum;
            }

            progressBar.Value = progressValue;
            lblStatus.Text = $"Editing... {progressValue}%";
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            selectSavePath.Enabled = true;
            lblStatus.Text = e.Cancelled ? "Operation cancelled." : "All videos edited.";
            labelShowMessage.Text = "";
        }

        private void btnGetCheckBox_Click(object sender, EventArgs e)
        {
            var filterChain = string.Empty;
            if (checkBoxHflip.Checked) filterChain += ",hflip";
            if (checkBoxVflip.Checked) filterChain += ",vflip";
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
            var outputFolder = selectFolder.Text;
            if (Directory.Exists(outputFolder))
            {
                Process.Start("explorer.exe", outputFolder);
            }
            else
            {
                lblStatus.Text = "Output folder does not exist.";
            }
        }

        private void selectSavePath_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog { Description = "Select Output Folder" })
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    selectFolder.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }



        private void ParseProgress(string data, int currentFileIndex, int totalFiles, string inputFile)
        {
            if (string.IsNullOrEmpty(data))
            {
                return;
            }

            if (data.StartsWith("frame="))
            {
                string[] timeData = data.Split(new string[] { "time=" }, StringSplitOptions.None);
                if (timeData.Length < 2) return;

                string time = timeData[1].Split(' ')[0];

                if (TimeSpan.TryParse(time, out TimeSpan currentTime))
                {
                    using (var ffmpegInfo = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = ffmpegPath,
                            Arguments = $"-i \"{inputFile}\"",
                            RedirectStandardError = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        }
                    })
                    {
                        ffmpegInfo.Start();
                        string output = ffmpegInfo.StandardError.ReadToEnd();
                        ffmpegInfo.WaitForExit();

                        string[] durationData = output.Split(new string[] { "Duration: " }, StringSplitOptions.None);
                        if (durationData.Length < 2) return;

                        string durationString = durationData[1].Split(',')[0];

                        if (TimeSpan.TryParse(durationString, out TimeSpan duration))
                        {
                            double progress = ((currentFileIndex * 100.0) + ((currentTime.TotalSeconds / duration.TotalSeconds) * 100.0)) / totalFiles;
                            int progressPercentage = (int)Math.Min(100, progress);
                            backgroundWorker.ReportProgress(progressPercentage);
                        }
                    }
                }
            }
        }

    }
}
