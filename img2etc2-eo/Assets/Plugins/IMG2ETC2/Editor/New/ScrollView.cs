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

            string statusColor = new StatusColor(textureResolution.CrunchStatus()).Value();
            string resolutionText = new ResolutionInfo(textureResolution.Current(), textureResolution.Previous()).Value();

            return $"<color={statusColor}>{textureResolution.CrunchStatus()}</color> {imageNumber} - {textureItem.FilePath} {resolutionText}";
        }
    }
}
#endif