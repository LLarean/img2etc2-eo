namespace LLarean.IMG2ETC2
{
    using UnityEngine;
    using System.IO;
    
    public record TextureItem
    {
        private readonly string _filePath;

        public TextureItem(string filePath)
        {
            _filePath = filePath;
        }

        public Texture2D Texture()
        {
            var texture = new Texture2D(2, 2);
            texture.LoadImage(File.ReadAllBytes(_filePath));
            return texture;
        }
    }
}