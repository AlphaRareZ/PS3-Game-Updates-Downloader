using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Controller
{
    internal class FileDownloader
    {
        public event Action<int> ProgressChanged;
        public event Action DownloadCompleted;
        internal void DownloadFile(string dir, string url)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Changed);

            //Extract file name from url
            string filename = Path.GetFileName(new Uri(url).AbsolutePath);
            string filePath = Path.Combine(dir, filename);
            //Download File Asynchronously
            webClient.DownloadFileAsync(new Uri(url), filePath);
        }
        public long GetFileSize(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "HEAD"; // Use HEAD method to get only the headers

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
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
