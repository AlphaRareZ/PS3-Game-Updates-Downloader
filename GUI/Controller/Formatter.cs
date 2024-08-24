using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Controller
{
    internal class Formatter
    {
        public string FormatFileSize(long fileSize)
        {
            // Convert file size to a human-readable format
            if (fileSize >= (1 << 30))
                return $"{fileSize / (1 << 30):0.##} GB";
            else if (fileSize >= (1 << 20))
                return $"{fileSize / (1 << 20):0.##} MB";
            else if (fileSize >= (1 << 10))
                return $"{fileSize / (1 << 10):0.##} KB";
            else
                return $"{fileSize} bytes";
        }
    }
}
