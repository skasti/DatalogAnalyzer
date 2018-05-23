using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using OpenLogAnalyzer.Extensions;
using OpenLogger;
using OpenLogger.Core;
using OpenLogger.Core.Debugging;

namespace OpenLogAnalyzer
{
    public partial class LogImportForm : Form, ILogger
    {
        private Thread _importThread;
        private string SourceFolder { get; }
        private RiderConfig Config { get; set; }
        public LogImportForm(string source)
        {
            SourceFolder = source;
            InitializeComponent();
        }

        public event EventHandler<List<string>> OnCompleted;

        private void LogImportForm_Load(object sender, EventArgs e)
        {
            Log.Instance = this;
            _importThread = new Thread(ImportJob);
            _importThread.Start();
        }

        private void ImportJob()
        {
            if (string.IsNullOrWhiteSpace(SourceFolder))
                return;

            var sourceConfigPath = Path.Combine(SourceFolder, "RiderConfig.json");

            if (File.Exists(sourceConfigPath))
            {
                try
                {
                    var configJson = File.ReadAllText(sourceConfigPath);
                    Config = JsonConvert.DeserializeObject<RiderConfig>(configJson);
                }
                catch (Exception e)
                {
                    Config = RiderConfig.Instance;
                }
            }
            else
            {
                Config = RiderConfig.Instance;
            }

            var importFiles = Directory.GetFiles(SourceFolder, "*.LOG");
            var libraryFiles = Directory.GetFiles(Paths.LogLibrary, "*.LOG");

            var newFiles = importFiles.Where(cF =>
            {
                var fileName = Path.GetFileName(cF);
                var libraryFile = Path.Combine(Paths.LogLibrary, fileName);

                if (libraryFiles.Contains(libraryFile))
                {
                    var libraryMetadata = LogFileMetadata.Load(libraryFile + ".meta");

                    return !libraryMetadata.MatchesConfig(Config);
                }

                return true;
            }).ToList();

            if (newFiles.Count < 1)
            {
                Invoke((MethodInvoker) Close);
                return;
            }

            Invoke((MethodInvoker) delegate
            {
                ProgressBar.Maximum = newFiles.Count;
                ProgressBar.Value = 0;
            });

            var importedFiles = new List<string>();

            foreach (var newFile in newFiles)
            {
                var fileName = Path.GetFileName(newFile);
                fileName  = fileName.Substring(0, fileName.IndexOf('.'));
                var fileNameDate = String.Join("-", fileName.Split('-').Take(2));
                var fileNameIndex = int.Parse(fileName.Substring(fileName.LastIndexOf('-') + 1));

                var newFileName = $"{fileNameDate}-{fileNameIndex}.LOG";

                var libraryFile = Path.Combine(Paths.LogLibrary, newFileName);

                Invoke((MethodInvoker) delegate
                {
                    StatusLabel.Text = $"Processing '{fileName}'";
                });

                while (File.Exists(libraryFile))
                {
                    fileNameIndex++;
                    newFileName = $"{fileNameDate}-{fileNameIndex}.LOG";
                    libraryFile = Path.Combine(Paths.LogLibrary, newFileName);
                }

                var logFile = LogFile.Load(newFile, TimeSpan.FromHours(2));

                if (logFile != null)
                {
                    logFile.Metadata.Rider = $"#{Config.RiderNumber} - {Config.RiderName}";
                    logFile.Metadata.Bike = Config.BikeName;
                    logFile.Save(libraryFile);
                }

                importedFiles.Add(libraryFile);

                Invoke((MethodInvoker) delegate
                {
                    ProgressBar.Value++;
                });
            }

            Invoke((MethodInvoker) delegate
            {
                OnCompleted?.Invoke(this, importedFiles);

                AbortButton.Visible = false;
                FinishedButton.Visible = true;

                if (AutoCloseCheckbox.Checked)
                    Close();
            });
        }

        private void FinishedButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to abort import?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            _importThread.Abort();
            Close();
        }

        public void Info(string format, params object[] parameters)
        {
            try
            {
                Invoke((MethodInvoker) delegate
                {
                    DebugTextBox.AppendText($"[INFO][{DateTime.Now.ToShortTimeString()}]", Color.Blue);
                    DebugTextBox.AppendText(string.Format(format, parameters), Color.Black, true);
                });
            }
            catch (Exception)
            {
                // Ignore exceptions
            }
        }

        public void Error(string format, params object[] parameters)
        {
            try
            {
                Invoke((MethodInvoker) delegate
                {
                    DebugTextBox.AppendText($"[ERROR][{DateTime.Now.ToShortTimeString()}]", Color.Crimson);
                    DebugTextBox.AppendText(string.Format(format, parameters), Color.Black, true);
                });
            }
            catch (Exception)
            {
                // Ignore exceptions
            }
        }
    }
}
