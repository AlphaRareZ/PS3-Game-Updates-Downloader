using GUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GUI.Controller
{
    internal class PS3UpdatesController
    {
        // View
        private PS3UpdatesDownloaderGUI view;
        // Model
        private PS3UpdatesScrapper scrapper = new PS3UpdatesScrapper();

        public event Action<int> ProgressChanged;
        public event Action DownloadCompleted;

        private string downloadDirectory;

        public PS3UpdatesController(PS3UpdatesDownloaderGUI view)
        {
            this.view = view;
        }
        
        public void SetDownloadDirectory(string downloadDirectory)
        {
            this.downloadDirectory = downloadDirectory;
        }
        public List<GameUpdate> GetUpdates()
        {
            return scrapper.getGamesUpdates();
        }
        public bool Scrap()
        {
            return scrapper.Scrap();
        }
        internal List<GameUpdate> Search(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                // Handle empty or null search name
                return new List<GameUpdate>();
            }

            // Retrieve the list of updates once
            var allUpdates = GetUpdates();

            // Filter the list based on the name
            var filterByName = allUpdates
                .Where(update => update.gameName != null && update.gameName.StartsWith(text, StringComparison.OrdinalIgnoreCase))
                .ToList();

            var filterByID = allUpdates
                .Where(update => update.gameID != null && update.gameID.StartsWith(text, StringComparison.OrdinalIgnoreCase))
                .ToList();

            filterByName.AddRange(filterByID);

            // Bind the filtered list to the DataGridView
            return filterByName;
        }

        
        internal void DownloadFile(string dir, string url)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Changed);

            //Extract file name from url
            string filename = Path.GetFileName(new Uri(url).AbsolutePath);
            string filePath = Path.Combine(dir,filename);
            webClient.DownloadFileAsync(new Uri(url), filePath);
        }

        private void Changed(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressChanged?.Invoke(e.ProgressPercentage);
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            DownloadCompleted?.Invoke();
        }
        public long GetFileSize(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "HEAD"; // Use HEAD method to get only the headers

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                long fileSize = response.ContentLength;
                return fileSize;
            }
        }

        public string FormatFileSize(long fileSize)
        {
            // Convert file size to a human-readable format
            if (fileSize >= (1 << 30))
                return $"{fileSize / (1 << 30):0.##} GB";
            else if (fileSize >= (1 << 20))
                return $"{fileSize / (1 << 20):0.##} MB";
            else if (fileSize >= (1 << 10))
                return $"{fileSize / (1 << 10):0.##} KB";
            else
                return $"{fileSize} bytes";
        }
    }
}
