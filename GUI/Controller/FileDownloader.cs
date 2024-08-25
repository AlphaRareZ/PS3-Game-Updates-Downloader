using System;
using System.ComponentModel;
using System.IO;
using System.Net;

namespace GUI.Controller
{
    internal class FileDownloader
    {
        public event Action<int> ProgressChanged;
        public event Action DownloadCompleted;

        internal void DownloadFile(string dir, string url)
        {
            var webClient = new WebClient();
            webClient.DownloadFileCompleted += Completed;
            webClient.DownloadProgressChanged += Changed;

            //Extract file name from url
            var filename = Path.GetFileName(new Uri(url).AbsolutePath);
            var filePath = Path.Combine(dir, filename);
            //Download File Asynchronously
            webClient.DownloadFileAsync(new Uri(url), filePath);
        }

        public long GetFileSize(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "HEAD"; // Use HEAD method to get only the headers
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var fileSize = response.ContentLength;
                return fileSize;
            }
        }

        private void Changed(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressChanged?.Invoke(e.ProgressPercentage);
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            DownloadCompleted?.Invoke();
        }
    }
}