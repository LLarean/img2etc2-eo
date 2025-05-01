#if UNITY_EDITOR
namespace LLarean.IMG2ETC2
{
    public record ResolutionInfo
    {
        private readonly string _currentResolution;
        private readonly string _previousResolution;

        public ResolutionInfo(string currentResolution, string previousResolution)
        {
            _currentResolution = currentResolution;
            _previousResolution = previousResolution;
        }
        
        public string Value()
        {
            string resolutionText = "Resolution:";

            if (_currentResolution == _previousResolution)
            {
                resolutionText = $"{resolutionText} {_currentResolution}";
            }
            else
            {
                resolutionText = $"{resolutionText} {_previousResolution} => {_currentResolution}";
            }
            
            resolutionText = $"<color=white>{resolutionText}</color>";
            return resolutionText;
        }
    }
}
#endif