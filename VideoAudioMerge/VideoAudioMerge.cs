using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace VideoAudioMerge
{
    public partial class VideoAudioMerge : Form
    {
        AppState AppState = AppState.Idle;

        Task MergeTask;
        CancellationTokenSource CanellMergeTask;
        int WaitForCalcCanellOrEndTiomout_ms = 3000;

        Color StopColor = Color.FromArgb(255, 165, 165);
        Color StopBorderColor = Color.FromArgb(255, 120, 120);

        Color StartColor = Color.FromArgb(135, 240, 135);
        Color StartBorderColor = Color.FromArgb(0, 192, 0);

        Properties.Settings Settings = Properties.Settings.Default;

        public VideoAudioMerge()
        {
            InitializeComponent();
            this.MinimumSize = this.Size;
            SetButtonIdleState();

            Text += " v" + FileVersionInfo.GetVersionInfo(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                .FileVersion;

            txtOutput.AllowDrop = true;
            txtOutput.DragEnter += TxtOutput_DragEnter;
            txtOutput.DragDrop += TxtOutput_DragDrop;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            WaitForCommTastCanellOrEnd();

            base.OnClosing(e);
        }

        private void SetButtonIdleState()
        {
            btnBrowseVideoIn.Enabled = true;
            btnBrowseAudioIn.Enabled = true;
            btnMerge.Text = "Merge";
            btnMerge.BackColor = StartColor;
            btnMerge.BorderColor = StartBorderColor;
        }

        private void SetButtonBuisyState()
        {
            btnBrowseVideoIn.Enabled = false;
            btnBrowseAudioIn.Enabled = false;
            btnMerge.Text = "Cancel";
            btnMerge.BackColor = StopColor;
            btnMerge.BorderColor = StopBorderColor = Color.FromArgb(255, 120, 120);
            ;
        }

        private void Merge()
        {
            if (!File.Exists(txtVideoIn.Text))
            {
                MessageBox.Show(
                    this,
                    "VideoIn file does not exist!",
                    "Error:",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (!File.Exists(txtAudioIn.Text))
            {
                MessageBox.Show(
                    this,
                    "AudioIn file does not exist!",
                    "Error:",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            SetButtonBuisyState();

            textVideoOut.Text = "";

            AppState = AppState.Buisy;

            CanellMergeTask = new CancellationTokenSource();
            MergeTask = Task.Factory.StartNew((() =>
            {
                try
                {
                    string fileNameVideoIn = txtVideoIn.Text;
                    string fileNameAudioIn = txtAudioIn.Text;

                    string ext = Path.GetExtension(fileNameVideoIn);
                    string path = Path.GetDirectoryName(fileNameVideoIn);
                    string fileName = Path.GetFileNameWithoutExtension(fileNameVideoIn);
                    string fileNameVideoOut = string.Format("{0}\\{1} out{2}", path, fileName, ext);

                    int i = 0;
                    while(File.Exists(fileNameVideoOut))
                    {
                        i++;
                        fileNameVideoOut = string.Format("{0}\\{1} out({2}){3}", path, fileName, i, ext);
                    }

                    
                    //string procFileName = "cmd";
                    //string args = "/C \"echo y | ffmpeg -i \"video.mp4\" -i \"audio.mp3\" -map 0:v -map 1:a -codec copy -shortest \"out.mp4\"\"";

                    string procFileName = "ffmpeg";
                    string args = string.Format(
                        "-i \"{0}\" -i \"{1}\" -map 0:v -map 1:a -codec copy -shortest \"{2}\"",
                        fileNameVideoIn, fileNameAudioIn, fileNameVideoOut);

                    Process ffmpegProc = new Process();

                    ffmpegProc.StartInfo.FileName = procFileName;
                    ffmpegProc.StartInfo.Arguments = args;

                    //proc.StartInfo.RedirectStandardOutput = true;
                    //proc.StartInfo.RedirectStandardError = true;
                    //proc.StartInfo.UseShellExecute = false;
                    //proc.StartInfo.CreateNoWindow = false;

                    ffmpegProc.Start();

                    //string output = proc.StandardOutput.ReadToEnd();
                    //string error = proc.StandardError.ReadToEnd();

                    ffmpegProc.WaitForExit();

                    ffmpegProc.Dispose();

                    this.BeginInvoke(() =>
                    {
                        txtOutput.Clear();

                        if (File.Exists(fileNameVideoOut))
                        {
                            textVideoOut.Text = fileNameVideoOut;
                            textVideoOut.SelectionLength = txtAudioIn.Text.Length;
                            textVideoOut.ForeColor = Color.Blue;
                            fileSystemWatcher1.Path = Path.GetDirectoryName(fileNameVideoOut);
                            fileSystemWatcher1.EnableRaisingEvents = true;   
                        }
                    });
                }
                catch (Exception ex)
                {
                    this.BeginInvoke(() =>
                    {
                        txtOutput.Text = "Error";

                        MessageBox.Show(
                            this,
                            ex.Message,
                            "Error:",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    });
                }
                finally
                {
                    this.BeginInvoke(() =>
                    {
                        if (!CanellMergeTask.IsCancellationRequested)
                        {
                            txtOutput.WriteLine("Done!");
                        }
                        else
                        {
                            txtOutput.WriteLine("Canceled");
                        }
                        SetButtonIdleState();

                        AppState = AppState.Idle;
                    });                 
                }
            }),
            CanellMergeTask.Token,
            TaskCreationOptions.None,
            TaskScheduler.Default);
        }

        private void WaitForCommTastCanellOrEnd()
        {
            if (IsTaskBuisy(MergeTask))
            {
                if (CanellMergeTask != null)
                    CanellMergeTask.Cancel();

                Stopwatch taskTimoutStopwatch = Stopwatch.StartNew();

                // Wait for the invokes (BeginInvoke) of the main thread in CalcTask to complete
                while (IsTaskBuisy(MergeTask))
                {
                    // Pump message queue - Allow BeginInvokes from CalcTask to finish.
                    //Application.DoEvents();

                    if (taskTimoutStopwatch.ElapsedMilliseconds > WaitForCalcCanellOrEndTiomout_ms)
                    {
                        string errMsg = string.Format(
                            "Unable to stop CalcTask (thread).\r\nTimout: {0} ms.",
                            WaitForCalcCanellOrEndTiomout_ms);

                        ErrorLogger.Log(ErrorLogger.ErrorType.Custom, errMsg, DateTime.Now);

                        DialogResult dlgResult = MessageBox.Show(
                            this,
                            "An unexpected error accrued!\r\n" +
                            "Do you want to Continue?\r\n\r\n" +
                            "Yes: Application will attempt to Continue\r\n" +
                            "No: Application will attempt to close.\r\n",
                            "Unable to stop",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Error);

                        if (dlgResult == DialogResult.No)
                        {
                            errMsg = "Unable to stop CalcTask (thread).\r\nAttemting to close.";
                            ErrorLogger.Log(ErrorLogger.ErrorType.Custom, errMsg, DateTime.Now);

                            taskTimoutStopwatch.Stop();
                            Application.ExitThread();
                            return;
                        }
                        else
                        {
                            errMsg = "Unable to stop CalcTask (thread).\r\nAttemting to Continue.";
                            ErrorLogger.Log(ErrorLogger.ErrorType.Custom, errMsg, DateTime.Now);

                            taskTimoutStopwatch.Restart();
                        }
                    }

                    // Pump message queue - Allow BeginInvokes from CalcTask to finish.
                    //Application.DoEvents();

                    // Check a few times if CalcTask has ended. 
                    for (int i = 0; (i < 5) && (IsTaskBuisy(MergeTask)); i++)
                    {
                        // Let CalcTask work
                        Thread.Sleep(10);
                        // Pump message queue - Allow BeginInvokes from CalcTask to finish.
                        Application.DoEvents();
                        // Let CalcTask end.
                        Thread.Sleep(10);
                    }

                }

                if (CanellMergeTask != null)
                {
                    CanellMergeTask.Dispose();
                    CanellMergeTask = null;
                }

            }
        }

        private bool IsTaskBuisy(Task task)
        {
            return
                task != null &&
                (task.Status != TaskStatus.Canceled &&
                task.Status != TaskStatus.RanToCompletion
                && task.Status != TaskStatus.Faulted);
        }

        private static string[] GetFilesOnlyFromData(IDataObject data, params string[] fileFmt)
        {
            if (!data.GetDataPresent(DataFormats.FileDrop))
            {
                return null;
            }
            string[] files = (string[])data.GetData(DataFormats.FileDrop);

            files = files
                .Where(str => !string.IsNullOrEmpty(str) && File.Exists(str))
                .Where(str => fileFmt.Length == 0|| fileFmt.Any(fmt => str.EndsWith(fmt, StringComparison.OrdinalIgnoreCase)))
                .ToArray();

            return files;
        }

        private void SetFileNameToTextBox(TextBox txt, string fileName)
        {
            if (!string.IsNullOrEmpty(fileName) &&
                File.Exists(fileName))
            {
                txt.Text = fileName;
                txt.SelectionLength = txt.Text.Length;
                txt.ScrollToCaret();

                if (txt == txtVideoIn)
                {
                    Settings.BrowseVideoInParentDirectory = Path.GetDirectoryName(fileName);
                }
                else if (txt == txtAudioIn)
                {
                    Settings.BrowseAudioInParentDirectory = Path.GetDirectoryName(fileName);
                }

                Settings.Save();
            }
        }

        private void btnBrowseVideoIn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "MP4 Files | *.mp4";

            if (Directory.Exists(Settings.BrowseVideoInParentDirectory))
                openFileDialog.InitialDirectory = Settings.BrowseVideoInParentDirectory;

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                SetFileNameToTextBox(txtVideoIn ,openFileDialog.FileName);
            }
        }

        private void btnBrowseAudioIn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "MP3 Files | *.mp3";

            if (Directory.Exists(Settings.BrowseAudioInParentDirectory))
                openFileDialog.InitialDirectory = Settings.BrowseAudioInParentDirectory;

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                SetFileNameToTextBox(txtAudioIn, openFileDialog.FileName);
            }
        }

        private void btnBrowseVideoOut_Click(Object sender, EventArgs e)
        {
            if (File.Exists(textVideoOut.Text))
            {
                OpenFolder.FileOrFolder(textVideoOut.Text);
            }
        }

        private void btnCalcDiff_Click(object sender, EventArgs e)
        {
            if(AppState == AppState.Idle)
            {
                Merge();
            }
            else if(AppState == AppState.Buisy)
            {
                WaitForCommTastCanellOrEnd();
            }
        }

        private void fileSystemWatcher1_Deleted(Object sender, FileSystemEventArgs e)
        {
            if (textVideoOut.Text != "" && !File.Exists(textVideoOut.Text))
            {
                textVideoOut.ForeColor = Color.Gray;
            }
        }

        private void fileSystemWatcher1_Created(Object sender, FileSystemEventArgs e)
        {
            if (textVideoOut.Text != "" && File.Exists(textVideoOut.Text))
            {
                textVideoOut.ForeColor = Color.Blue;
            }          
        }

        private void txtVideoAudioIn_DragEnter(Object sender, DragEventArgs e)
        {
            if (AppState == AppState.Idle)
            {
                string[] files = GetFilesOnlyFromData(e.Data);
                if (files != null && files.Length > 0)
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void txtVideoAudioIn_DragDrop(Object sender, DragEventArgs e)
        {
            if (AppState == AppState.Idle)
            {
                string[] files = GetFilesOnlyFromData(e.Data);
                string[] videoFiles = GetFilesOnlyFromData(e.Data, ".mp4");
                string[] audioFiles = GetFilesOnlyFromData(e.Data, ".mp3");

                if (videoFiles.Length > 0 && audioFiles.Length > 0)
                {
                    SetFileNameToTextBox(txtVideoIn, videoFiles[0]);
                    SetFileNameToTextBox(txtAudioIn, audioFiles[0]);
                }
                else
                {
                    TextBox txt = sender as TextBox;
                    if (txt != null)
                    {
                        if (txt == txtVideoIn && videoFiles.Length > 0)
                        {
                            SetFileNameToTextBox(txt, videoFiles[0]);
                        }
                        else if (txt == txtAudioIn && audioFiles.Length > 0)
                        {
                            SetFileNameToTextBox(txt, audioFiles[0]);
                        }
                        else if(files.Length > 0)
                        {
                            SetFileNameToTextBox(txt, files[0]);
                        }

                    }
                }
            }
        }

        private void TxtOutput_DragEnter(object sender, DragEventArgs e)
        {
            string[] videoFiles = GetFilesOnlyFromData(e.Data, ".mp4");
            string[] audioFiles = GetFilesOnlyFromData(e.Data, ".mp3");

            if (videoFiles.Length > 0 && audioFiles.Length > 0)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void TxtOutput_DragDrop(Object sender, DragEventArgs e)
        {
            if (AppState == AppState.Idle)
            {
                string[] videoFiles = GetFilesOnlyFromData(e.Data, ".mp4");
                string[] audioFiles = GetFilesOnlyFromData(e.Data, ".mp3");

                if (videoFiles.Length > 0 && audioFiles.Length > 0)
                {
                    SetFileNameToTextBox(txtVideoIn, videoFiles[0]);
                    SetFileNameToTextBox(txtAudioIn, audioFiles[0]);

                    Merge();
                }
            }
        }
    }
}
