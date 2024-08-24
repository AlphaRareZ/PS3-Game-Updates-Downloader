using System;
using System.Windows.Forms;
using GUI.Controller;

namespace GUI.View
{
    public partial class PS3UpdatesDownloaderGUI : Form
    {
        private readonly PS3UpdatesController _controller;

        public PS3UpdatesDownloaderGUI()
        {
            InitializeComponent();
            _controller = new PS3UpdatesController();
            _controller.ProgressChanged += OnProgressChanged;
            _controller.DownloadCompleted += OnDownloadCompleted;

        }

        private void PS3GamesUpdater_Load(object sender, EventArgs e)
        {
            _controller.Scrap();
            dataGridView1.DataSource = _controller.GetUpdates();
            dataGridView1.Columns[3].Visible = false;
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            string dir = DownloadDirTextBox.Text;
            long totalSizes = 0;
            string sizes = string.Empty;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var downloadUrl = row.Cells[3].Value.ToString();
                long fileSize = _controller.GetFileSize(downloadUrl);
                sizes += $"Version {row.Cells[2].Value.ToString()}: {_controller.formatter.FormatFileSize(fileSize)}\n";
                totalSizes += fileSize;
            }

            string message =
                $"{sizes} \nThe files sizes is {_controller.formatter.FormatFileSize(totalSizes)}. Do you want to continue with the download?";
            DialogResult result = MessageBox.Show(message, "File Size Confirmation", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Check the result of the user's choice
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    var downloadUrl = row.Cells[3].Value.ToString();
                    _controller.DownloadFile(dir, downloadUrl);
                }
            }
        }

        private void BrowseButton_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            DownloadDirTextBox.Text = fbd.SelectedPath;
        }

        private void OnProgressChanged(int progressPercentage)
        {
            progressBar1.Value = progressPercentage;
        }

        private void OnDownloadCompleted()
        {
            MessageBox.Show("File Downloaded");
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _controller.Search(searchBox.Text);
        }
    }
}