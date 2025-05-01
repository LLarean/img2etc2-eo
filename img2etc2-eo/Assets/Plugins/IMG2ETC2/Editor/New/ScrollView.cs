#if UNITY_EDITOR
using UnityEngine;

namespace LLarean.IMG2ETC2
{
    public record ScrollView
    {
        private readonly IScrollView _scrollView;
        private readonly TextureItems _textureItems;

        private Vector2 _scrollPosition;

        public ScrollView(IScrollView scrollView, TextureItems textureItems)
        {
            _textureItems = textureItems;
            _scrollView = scrollView;
        }
        
        public void Content()
        {
            _scrollView.Begin();
            
            foreach (var model in _textureItems.Content())
            {
                var itemInfo = GetItemInfo(model, _textureItems.Content().IndexOf(model) + 1);
                _scrollView.DrawItem(itemInfo);
            }
            
            _scrollView.End();
        }
        
        private string GetItemInfo(TextureItem textureItem, int imageNumber)
        {
            var texture2D = textureItem.Content();
            var textureResolution = new TextureResolution(texture2D);
            
            string color = GetStatusColor(textureResolution.CrunchStatus());
            string resolutionText = GetResolutionText(textureResolution.Current(), textureResolution.Previous());

            return $"<color={color}>{textureResolution.CrunchStatus()}</color> {imageNumber} - {textureItem.FilePath} {resolutionText}";
        }
        
        private string GetStatusColor(ResolutionStatus resolutionStatus)
        {
            return resolutionStatus switch
            {
                ResolutionStatus.Correct => "green",
                ResolutionStatus.Wrong => "yellow",
                _ => "white"
            };
        }
        
        private string GetResolutionText(string currentResolution, string previousResolution)
        {
            string resolutionText = $"Resolution: {currentResolution}";

            if (previousResolution == string.Empty)
            {
                resolutionText = $"{resolutionText} => {currentResolution}";
            }

            resolutionText = $"<color=white>{resolutionText}</color>";
            return resolutionText;
        }
        
        
    }
}
#endif