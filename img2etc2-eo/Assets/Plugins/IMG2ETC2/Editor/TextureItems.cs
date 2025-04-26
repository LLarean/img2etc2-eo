#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;

namespace LLarean.IMG2ETC2
{
    public record TextureItems
    {
        private readonly string _folderPath;
        private readonly bool _includeSubfolders;

        public TextureItems(string folderPath, bool includeSubfolders)
        {
            _folderPath = folderPath;
            _includeSubfolders = includeSubfolders;
        }

        public List<TextureItem> Content()
        {
            List<TextureItem> textureItems = new List<TextureItem>();
            
            SearchOption searchOption = _includeSubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            string[] filePaths = Directory.GetFiles(_folderPath, "*.*", searchOption);

            foreach (string filePath in filePaths)
            {
                string normalizedPath = filePath.Replace("\\", "/");
                
                if (GetFileExtensionSupportStatus(normalizedPath) == true)
                {
                    TextureItem textureItem = new TextureItem(normalizedPath);
                    // ImageModel imageModel = ImageUtils.GetModel(normalizedPath);
                    textureItems.Add(textureItem);
                }
            }

            return textureItems;
        }

        private bool GetFileExtensionSupportStatus(string path)
        {
            return path.EndsWith(".png") || path.EndsWith(".jpg") || path.EndsWith(".jpeg");
        }
    }
}
#endif