using System;
using System.Collections.Generic;
using System.Linq;
using GUI.Model;

namespace GUI.Controller
{
    internal class GameUpdatesSearcher
    {
        private List<GameUpdate> _updates;

        public GameUpdatesSearcher(List<GameUpdate> updates)
        {
            _updates = updates;
        }

        public void Search(string text)
        {
            if (string.IsNullOrEmpty(text)) return;
            _updates = _updates
                .Where(update =>
                    (update.GameName != null && update.GameName.StartsWith(text, StringComparison.OrdinalIgnoreCase)) ||
                    (update.GameId != null && update.GameId.StartsWith(text, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        public List<GameUpdate> GetUpdates()
        {
            return _updates;
        }
    }
}