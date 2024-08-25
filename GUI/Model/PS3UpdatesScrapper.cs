using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace GUI.Model
{
    internal class Ps3UpdatesScrapper : IScrapper
    {
        private const string Url = "https://ps3.aldostools.org/updates.html";

        private readonly List<GameUpdate> _gamesUpdates = new List<GameUpdate>();

        public bool Scrap()
        {
            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8
            };
            var doc = web.Load(Url);

            // Get all <tbody> elements
            var tbodyNodes = doc.DocumentNode.SelectNodes("//tbody");

            if (tbodyNodes == null) return false;
            foreach (var tbody in tbodyNodes)
            {
                // Get all <tr> elements within this <tbody>
                var trNodes = tbody.SelectNodes(".//tr");

                if (trNodes == null) continue;
                foreach (var tr in trNodes)
                {
                    // Get all <td> elements within this <tr>
                    var tdNodes = tr.SelectNodes(".//td");

                    if (tdNodes == null) continue;
                    var data = tdNodes.Select(td => td.InnerText.Trim()).Select(innerText =>
                        Encoding.UTF8.GetString(Encoding.Default.GetBytes(innerText))).ToList();
                    _gamesUpdates.Add(new GameUpdate(data));
                }
            }

            return true;
        }

        public List<GameUpdate> GetGamesUpdates()
        {
            return _gamesUpdates;
        }
    }
}