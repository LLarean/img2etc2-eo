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
                // GUIUtils.DrawImageModel(model, _textureItems.Content().IndexOf(model) + 1);
            }
            
            _scrollView.End();
        }
    }
}
#endif