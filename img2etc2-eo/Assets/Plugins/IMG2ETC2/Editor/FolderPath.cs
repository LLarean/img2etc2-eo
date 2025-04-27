#if UNITY_EDITOR
using System;
using System.IO;

namespace LLarean.IMG2ETC2
{
    public record FolderPath
    {
        private readonly string _value;

        public FolderPath(string value)
        {
            _value = value;
        }

        public string Value()
        {
            if (string.IsNullOrWhiteSpace(_value))
            {
                throw new ArgumentNullException(nameof(_value));
            }

            if (_value.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
            {
                throw new ArgumentException("Not valid path");
            }
            
            if (Directory.Exists(_value) == false)
            {
                throw new DirectoryNotFoundException($"Folder not found: {_value}");
            }
            
            return _value;
        }
    }
}
#endif