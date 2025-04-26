using UnityEngine;

namespace LLarean.IMG2ETC2
{
    public record TextureResolution
    {
        private readonly Texture2D _texture2D;
        private readonly string _current;

        public TextureResolution(Texture2D texture2D)
        {
            _texture2D = texture2D;
        }
        
        public string Current() => $"({_texture2D.width}x{_texture2D.height})";

        public ResolutionStatus CrunchStatus()
        {
            if (_texture2D.width % 4 != 0) return ResolutionStatus.Wrong;
            if (_texture2D.height % 4 != 0) return ResolutionStatus.Wrong;
            return ResolutionStatus.Correct;
        }
    }
}