using System;
using System.Windows.Forms;
using GUI.Controller;

namespace GUI.View
{
    public partial class Ps3UpdatesDownloaderGui : Form
    {
        private readonly Ps3UpdatesController _controller;

        public Ps3UpdatesDownloaderGui()
        {
            InitializeComponent();
            _controller = new Ps3UpdatesController();
            _controller.AddProgressChangedHandler(OnProgressChanged);
            _controller.AddDownloadCompletedHandler(OnDownloadCompleted);
        }

        private void PS3GamesUpdater_Load(object sender, EventArgs e)
        {
            _controller.Scrap();
            dataGridView1.DataSource = _controller.GetUpdates();
            dataGridView1.Columns[3].Visible = false;
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            DownloadDirTextBox.Text = fbd.SelectedPath;
        }

        private void OnProgressChanged(int progressPercentage)
        {
            progressBar1.Value = progressPercentage;
        }

        private void OnDownloadCompleted()
        {
            MessageBox.Show(@"File Downloaded");
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _controller.Search(searchBox.Text);
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            var dir = DownloadDirTextBox.Text;
            long totalSizes = 0;
            var eachFileSize = string.Empty;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var downloadUrl = row.Cells[3].Value.ToString();
                var fileSize = _controller.GetFileSize(downloadUrl);
                totalSizes += fileSize;
                eachFileSize += $"Version {row.Cells[2].Value}: {_controller.FormatFileSize(fileSize)}\n";
            }

            var message =
                $"{eachFileSize} \nThe files eachFileSize is {_controller.FormatFileSize(totalSizes)}. Do you want to continue with the download?";
            var result = MessageBox.Show(message, "File Size Confirmation", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Check the result of the user's choice
            if (result != DialogResult.Yes) return;

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var downloadUrl = row.Cells[3].Value.ToString();
                _controller.DownloadFile(dir, downloadUrl);
            }
        }
    }
}