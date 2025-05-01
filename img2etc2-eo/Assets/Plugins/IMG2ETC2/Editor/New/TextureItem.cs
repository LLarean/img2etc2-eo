#if UNITY_EDITOR
using UnityEngine;
using System.IO;

namespace LLarean.IMG2ETC2
{
    public record TextureItem
    {
        private readonly string _filePath;

        public TextureItem(string filePath)
        {
            _filePath = filePath;
        }

        public string FilePath => _filePath;

        public Texture2D Content()
        {
            var texture = new Texture2D(2, 2);
            texture.LoadImage(File.ReadAllBytes(_filePath));
            return texture;
        }
    }
}
#endif