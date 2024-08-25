using GUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using GUI.View;


namespace GUI.Controller
{
    internal class PS3UpdatesController
    {
        // Model
        private PS3UpdatesScrapper scrapper = new PS3UpdatesScrapper();
        // Formatter
        public Formatter formatter = new Formatter();
        // Downloader
        FileDownloader fileDownloader = new FileDownloader();


        internal List<GameUpdate> GetUpdates()
        {
            return scrapper.GetGamesUpdates();
        }

        internal bool Scrap()
        {
            return scrapper.Scrap();
        }

        internal List<GameUpdate> Search(string text)
        {
            GameUpdatesSearcher updatesFinder = new GameUpdatesSearcher(GetUpdates());
            updatesFinder.Search(text);
            return updatesFinder.GetUpdates();
        }
        public long GetFileSize(string url)
        {
            return fileDownloader.GetFileSize(url);
        }
        internal void DownloadFile(string dir, string downloadUrl)
        {
            fileDownloader.DownloadFile(dir, downloadUrl);
        }
        
        internal void addProgressChangedHandler(Action<int> onProgressChanged)
        {
            fileDownloader.ProgressChanged += onProgressChanged;
        }

        internal void addDownloadCompletedHandler(Action onDownloadCompleted)
        {
            fileDownloader.DownloadCompleted += onDownloadCompleted;
        }

        public string FormatFileSize(long fileSize)
        {
            return formatter.FormatFileSize(fileSize);
        }
    }
}