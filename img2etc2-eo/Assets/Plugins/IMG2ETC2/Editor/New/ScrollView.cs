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
                DrawImageModel(model, _textureItems.Content().IndexOf(model) + 1);
                // GUIUtils.DrawImageModel(model, _textureItems.Content().IndexOf(model) + 1);
            }
            
            _scrollView.End();
        }
        
        public static void DrawImageModel(TextureItem textureItem, int imageNumber)
        {
            var texture2D = textureItem.Content();
            var textureResolution = new TextureResolution(texture2D);
            // string color = GetStatusColor(imageModel.ResolutionStatus);
            // string resolutionText = GetResolutionText(imageModel.CurrentResolution, imageModel.PreviousResolution);

            GUILayout.Label(
                $"{textureResolution.CrunchStatus()} {imageNumber} - {textureItem.FilePath} {textureResolution.Current()}",
                new GUIStyle { richText = true }
            );
        }
        
        
    }
}
#endif