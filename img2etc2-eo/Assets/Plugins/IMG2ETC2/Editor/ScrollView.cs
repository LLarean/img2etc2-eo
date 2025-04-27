#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace LLarean.IMG2ETC2
{
    public record ScrollView
    {
        private readonly TextureItems _textureItems;

        private Vector2 _scrollPosition;

        public ScrollView(TextureItems textureItems)
        {
            _textureItems = textureItems;
        }
        
        public void Content()
        {
            GUILayout.Space(10);
            GUILayout.Label(GlobalStrings.ImagesIn, EditorStyles.boldLabel);
            _scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
            
            foreach (var model in _textureItems.Content())
            {
                // GUIUtils.DrawImageModel(model, _textureItems.Content().IndexOf(model) + 1);
            }
            
            GUILayout.EndScrollView();
        }
    }
}
#endif