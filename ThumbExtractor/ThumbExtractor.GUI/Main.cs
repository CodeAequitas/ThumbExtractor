using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ThumbExtractor.Engine;

namespace ThumbExtractor.GUI
{
    public partial class Main : Form
    {
        private readonly Core _core = new Core();
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private bool _started;
        
        public Main()
        {
            InitializeComponent();

            _core.OnStatusUpdate += OnStatusUpdate;
            _core.OnStatusFinished += OnStatusFinished;
            _started = false;
        }

        private void OnStatusFinished(object sender, EventArgs eventArgs)
        {
            _started = false;
            Invoke((MethodInvoker) delegate
            {
                btn_start.Text = "START";
            });
        }

        private void OnStatusUpdate(object sender, string s)
        {
            AppendStatus(s);
        }

        private void AppendStatus(string text)
        {
            Invoke((MethodInvoker) delegate
            {
                text_status.AppendText(text + Environment.NewLine);
            });
        }

        private void btn_browse_db_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "Thumbnail Database (.db)|*.db",
                FilterIndex = 1,
                Title = "Please select a Thumbnail Database file"
            };

            if (dlg.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dlg.FileName))
                text_thumbfile.Text = dlg.FileName;
        }

        private void btn_browse_outdir_Click(object sender, EventArgs e)
        {
            var dlg = new FolderBrowserDialog
            {
                Description = "Please select an output folder for extracted images",
                SelectedPath = Path.Combine(Environment.CurrentDirectory),
                ShowNewFolderButton = true
            };

            if (dlg.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dlg.SelectedPath))
                text_outdir.Text = dlg.SelectedPath;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (!_started)
            {
                if (string.IsNullOrEmpty(text_thumbfile.Text) || !File.Exists(text_thumbfile.Text))
                {
                    MessageBox.Show("Please select a thumbnail database to extract images from",
                        "Missing Thumbnail database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(text_outdir.Text) || !Directory.Exists(text_outdir.Text))
                    text_outdir.Text = Path.Combine(Environment.CurrentDirectory, "Output");

                if (!Directory.Exists(text_outdir.Text))
                    Directory.CreateDirectory(text_outdir.Text);

                _started = true;
                btn_start.Text = "STOP";
                _core.Process(new Options
                {
                    ConsoleTarget = false,
                    OutputDirectory = text_outdir.Text,
                    ThumbDB = text_thumbfile.Text
                }, _cancellationTokenSource.Token);
            }
            else
            {
                _cancellationTokenSource.Cancel();
            }
        }
    }
}
