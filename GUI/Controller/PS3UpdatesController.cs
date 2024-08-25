using System;
using System.Collections.Generic;
using GUI.Model;

namespace GUI.Controller
{
    internal class Ps3UpdatesController
    {
        // Model
        private readonly Ps3UpdatesScrapper _scrapper = new Ps3UpdatesScrapper();

        // Formatter
        private readonly Formatter _formatter = new Formatter();

        // Downloader
        private readonly FileDownloader _fileDownloader = new FileDownloader();


        internal List<GameUpdate> GetUpdates()
        {
            return _scrapper.GetGamesUpdates();
        }

        internal bool Scrap()
        {
            return _scrapper.Scrap();
        }

        internal List<GameUpdate> Search(string text)
        {
            var updatesFinder = new GameUpdatesSearcher(GetUpdates());
            updatesFinder.Search(text);
            return updatesFinder.GetUpdates();
        }

        public long GetFileSize(string url)
        {
            return _fileDownloader.GetFileSize(url);
        }

        internal void DownloadFile(string dir, string downloadUrl)
        {
            _fileDownloader.DownloadFile(dir, downloadUrl);
        }

        internal void AddProgressChangedHandler(Action<int> onProgressChanged)
        {
            _fileDownloader.ProgressChanged += onProgressChanged;
        }

        internal void AddDownloadCompletedHandler(Action onDownloadCompleted)
        {
            _fileDownloader.DownloadCompleted += onDownloadCompleted;
        }

        public string FormatFileSize(long fileSize)
        {
            return _formatter.FormatFileSize(fileSize);
        }
    }
}