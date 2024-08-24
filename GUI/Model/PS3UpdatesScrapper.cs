using System;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
namespace GUI.Model
{
    internal class PS3UpdatesScrapper:Scrapper
    {
        private readonly string url = "https://ps3.aldostools.org/updates.html";

        private List<GameUpdate> gamesUpdates = new List<GameUpdate>();
        public bool Scrap()
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);

            // Get all <tbody> elements
            var tbodyNodes = doc.DocumentNode.SelectNodes("//tbody");

            if (tbodyNodes != null)
            {
                foreach (var tbody in tbodyNodes)
                {
                    // Get all <tr> elements within this <tbody>
                    var trNodes = tbody.SelectNodes(".//tr");

                    if (trNodes != null)
                    {
                        foreach (var tr in trNodes)
                        {
                            // Get all <td> elements within this <tr>
                            var tdNodes = tr.SelectNodes(".//td");

                            if (tdNodes != null)
                            {
                                List<string> data = new List<string>();
                                foreach (var td in tdNodes)
                                {
                                    data.Add(td.InnerText.Trim());
                                }
                                gamesUpdates.Add(new GameUpdate(data));
                            }

                        }
                    }
                }
            }
            return true;
        }
        public List<GameUpdate> getGamesUpdates()
        {
            return gamesUpdates;
        }
    }
}
