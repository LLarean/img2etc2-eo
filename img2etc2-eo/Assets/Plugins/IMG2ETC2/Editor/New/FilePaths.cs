#if UNITY_EDITOR
using System;
using System.IO;
using UnityEngine;

namespace LLarean.IMG2ETC2
{
    public record FilePaths
    {
        private readonly string _folderPath;
        private readonly SearchOption _searchOption;

        public FilePaths(string folderPath, SearchOption searchOption = SearchOption.AllDirectories)
        {
            _folderPath = folderPath;
            _searchOption = searchOption;
        }
        
        public string[] Content()
        {
            if (string.IsNullOrWhiteSpace(_folderPath))
            {
                throw new ArgumentNullException(nameof(_folderPath));
            }

            if (Directory.Exists(_folderPath) == false)
            {
                throw new DirectoryNotFoundException($"Folder not found: {_folderPath}");
            }

            if (_folderPath.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
            {
                throw new ArgumentException("Not valid path");
            }

            if (Enum.IsDefined(typeof(SearchOption), _searchOption) == false)
            {
                throw new ArgumentOutOfRangeException(nameof(_searchOption));
            }

            try
            {
                return Directory.GetFiles(_folderPath, "*.*", _searchOption);
            }
            catch (UnauthorizedAccessException)
            {
                Debug.LogError("No access");
                return Array.Empty<string>();
            }
            catch (PathTooLongException)
            {
                Debug.LogError("Path too long");
                return Array.Empty<string>();
            }
            catch (IOException ex)
            {
                Debug.LogError($"Error input/output: {ex.Message}");
                return Array.Empty<string>();
            }
        }
    }
}
#endif