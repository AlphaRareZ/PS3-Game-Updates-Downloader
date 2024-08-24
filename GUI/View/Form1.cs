using GUI.Model;
using GUI.Controller;
using System.Collections.Generic;
using System.Security.Policy;
using System.Windows.Forms;
using System.Threading.Tasks;
using System;

namespace GUI
{
    public partial class PS3UpdatesDownloaderGUI : Form
    {
        PS3UpdatesController controller;
        public PS3UpdatesDownloaderGUI()
        {
            InitializeComponent();
            controller = new PS3UpdatesController(this);
            controller.ProgressChanged += OnProgressChanged;
            controller.DownloadCompleted += OnDownloadCompleted;
        }

        private void PS3GamesUpdater_Load(object sender, System.EventArgs e)
        {
            controller.Scrap();
            dataGridView1.DataSource = controller.GetUpdates();
            dataGridView1.Columns[3].Visible = false;
        }

        private void SearchButton_Click(object sender, System.EventArgs e)
        {
            dataGridView1.DataSource =  controller.Search(searchBox.Text);
        }
        private void RefreshDatabaseButton_Click(object sender, System.EventArgs e)
        {

            dataGridView1.DataSource = controller.GetUpdates();
        }

        private void DownloadButton_Click(object sender, System.EventArgs e)
        {
            string dir = DownloadDirTextBox.Text;
            long totalSizes = 0;
            string sizes = string.Empty;
            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var downloadURL = row.Cells[3].Value.ToString();
                long fileSize = controller.GetFileSize(downloadURL);
                sizes += $"Version {row.Cells[2].Value.ToString()}: {controller.FormatFileSize(fileSize)}\n";
                totalSizes += fileSize;
            }

            DialogResult result = MessageBox.Show(
            $"{sizes} \nThe files sizes is {controller.FormatFileSize(totalSizes)}. Do you want to continue with the download?",
            "File Size Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            // Check the result of the user's choice
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    var downloadURL = row.Cells[3].Value.ToString();
                    controller.DownloadFile(dir, downloadURL);
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
    }
}
