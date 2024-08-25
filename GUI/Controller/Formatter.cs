namespace GUI.Controller
{
    internal class Formatter
    {
        public string FormatFileSize(long fileSize)
        {
            // Convert file size to a human-readable format
            if (fileSize >= (1 << 30))
                return $"{fileSize / (1 << 30):0.##} GB";
            if (fileSize >= (1 << 20))
                return $"{fileSize / (1 << 20):0.##} MB";
            return fileSize >= (1 << 10) ? $"{fileSize / (1 << 10):0.##} KB" : $"{fileSize} bytes";
        }
    }
}