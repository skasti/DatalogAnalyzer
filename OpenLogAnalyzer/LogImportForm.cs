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
using OpenLogAnalyzer.Extensions;
using OpenLogger;
using OpenLogger.Core;
using OpenLogger.Core.Debugging;

namespace OpenLogAnalyzer
{
    public partial class LogImportForm : Form, ILogger
    {
        private Thread _importThread;
        public LogImportForm()
        {
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
            if (Paths.DataLoggerCard == null)
                return;

            var cardFiles = Directory.GetFiles(Paths.DataLoggerCard, "*.LOG");
            var libraryFiles = Directory.GetFiles(Paths.LogLibrary, "*.LOG");

            var newFiles = cardFiles.Where(cF =>
            {
                var fileName = Path.GetFileName(cF);
                var libraryFile = Path.Combine(Paths.LogLibrary, fileName);

                return !libraryFiles.Contains(libraryFile);
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

            var config = AnalyzerConfig.Instance;

            var importedFiles = new List<string>();

            foreach (var newFile in newFiles)
            {
                var fileName = Path.GetFileName(newFile);
                var libraryFile = Path.Combine(Paths.LogLibrary, fileName);

                Invoke((MethodInvoker) delegate
                {
                    StatusLabel.Text = $"Processing '{fileName}'";
                });

                if (libraryFiles.Contains(libraryFile))
                {
                    Invoke((MethodInvoker) delegate
                    {
                        ProgressBar.Value++;
                    });
                    continue;
                }

                var logFile = LogFile.Load(newFile, TimeSpan.FromHours(2));

                if (logFile != null)
                {
                    logFile.Metadata.Rider = $"#{config.RiderNumber} - {config.RiderName}";
                    logFile.Metadata.Bike = config.BikeName;
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
