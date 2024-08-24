using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Model
{
    internal class GameUpdate
    {
        public string gameID { get; set; }
        public string gameName { get; set; }
        public string version { get; set; }
        public string downloadUrl { get; set; }

        public GameUpdate(string gameID, string gameName, string version, string downloadUrl)
        {
            this.gameID = gameID;
            this.gameName = gameName;
            this.version = version;
            this.downloadUrl = downloadUrl;
        }

        public GameUpdate(List<string> data)
        {
            gameID = data[0];
            gameName = data[1];
            version = data[2];
            downloadUrl = data[3];
        }
    }
}