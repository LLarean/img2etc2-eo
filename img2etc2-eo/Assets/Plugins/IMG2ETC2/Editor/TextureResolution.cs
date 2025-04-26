using UnityEngine;

namespace LLarean.IMG2ETC2
{
    public record TextureResolution
    {
        private readonly Texture2D _texture2D;
        private readonly string _previous = string.Empty;

        public TextureResolution(Texture2D texture2D)
        {
            _texture2D = texture2D;
        }

        public TextureResolution(Texture2D texture2D, string previous) : this(texture2D)
        {
            _previous = previous;
        }
        
        public string Current() => $"{_texture2D.width}x{_texture2D.height}";
        
        public string Previous() => _previous == string.Empty ? Current() : _previous;

        public ResolutionStatus CrunchStatus()
        {
            if (_texture2D.width % 4 != 0) return ResolutionStatus.Wrong;
            if (_texture2D.height % 4 != 0) return ResolutionStatus.Wrong;
            return ResolutionStatus.Correct;
        }
    }
}