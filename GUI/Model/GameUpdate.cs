using System.Collections.Generic;

namespace GUI.Model
{
    internal class GameUpdate
    {
        public string GameId { get; set; }
        public string GameName { get; set; }
        public string Version { get; set; }
        public string DownloadUrl { get; set; }

        public GameUpdate(string gameId, string gameName, string version, string downloadUrl)
        {
            GameId = gameId;
            GameName = gameName;
            Version = version;
            DownloadUrl = downloadUrl;
        }

        public GameUpdate(List<string> data)
        {
            GameId = data[0];
            GameName = data[1];
            Version = data[2];
            DownloadUrl = data[3];
        }
    }
}