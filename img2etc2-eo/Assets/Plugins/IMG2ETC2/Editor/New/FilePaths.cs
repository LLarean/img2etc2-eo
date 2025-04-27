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