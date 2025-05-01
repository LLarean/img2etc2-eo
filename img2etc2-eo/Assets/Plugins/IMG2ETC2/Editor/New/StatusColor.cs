#if UNITY_EDITOR
namespace LLarean.IMG2ETC2
{
    public record StatusColor
    {
        private readonly ResolutionStatus _resolutionStatus;

        public StatusColor(ResolutionStatus resolutionStatus)
        {
            _resolutionStatus = resolutionStatus;
        }
        
        public string Value()
        {
            return _resolutionStatus switch
            {
                ResolutionStatus.Correct => StatusColors.green.ToString(),
                ResolutionStatus.Wrong => StatusColors.yellow.ToString(),
                _ => StatusColors.white.ToString()
            };
        }
    }
}
#endif