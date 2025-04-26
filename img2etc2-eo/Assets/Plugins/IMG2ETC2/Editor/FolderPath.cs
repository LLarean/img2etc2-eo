#if UNITY_EDITOR
using System;
using System.IO;

namespace LLarean.IMG2ETC2
{
    public record FolderPath
    {
        private readonly string _folderPath;

        public FolderPath(string folderPath)
        {
            _folderPath = folderPath;
        }

        public string Value()
        {
            if (string.IsNullOrWhiteSpace(_folderPath))
            {
                throw new ArgumentNullException(nameof(_folderPath));
            }

            if (_folderPath.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
            {
                throw new ArgumentException("Not valid path");
            }
            
            if (Directory.Exists(_folderPath) == false)
            {
                throw new DirectoryNotFoundException($"Folder not found: {_folderPath}");
            }
            
            return _folderPath;
        }
    }
}
#endif