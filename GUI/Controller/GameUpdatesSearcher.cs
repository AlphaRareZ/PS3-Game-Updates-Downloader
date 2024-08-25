using GUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GUI.Controller
{
    internal class GameUpdatesSearcher
    {
        private List<GameUpdate> updates;
        public GameUpdatesSearcher(List<GameUpdate> updates)
        {
            this.updates = updates;
        }

        public void Search(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                // Handle empty or null search name
                return;
            }

            // Retrieve the list of updates once

            var filteredUpdates = updates
            .Where(update =>
        (update.gameName != null && update.gameName.StartsWith(text, StringComparison.OrdinalIgnoreCase)) ||
        (update.gameID != null && update.gameID.StartsWith(text, StringComparison.OrdinalIgnoreCase)))
    .ToList();

            // Bind the filtered list to the DataGridView
            updates = filteredUpdates;
        }
        public List<GameUpdate> GetUpdates() { return updates; }
    }
}
