#if UNITY_EDITOR
using System.Collections.Generic;

namespace LLarean.IMG2ETC2
{
    public record TextureItems
    {
        private readonly FilePaths _filePaths;

        public TextureItems(FilePaths filePaths)
        {
            _filePaths = filePaths;
        }

        public List<TextureItem> Content()
        {
            List<TextureItem> textureItems = new List<TextureItem>();

            foreach (string filePath in _filePaths.Content())
            {
                string normalizedPath = filePath.Replace("\\", "/");
                
                if (GetFileExtensionSupportStatus(normalizedPath) == true)
                {
                    TextureItem textureItem = new TextureItem(normalizedPath);
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