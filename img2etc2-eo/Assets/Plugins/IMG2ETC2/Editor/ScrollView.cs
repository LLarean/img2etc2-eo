#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LLarean.IMG2ETC2
{
    public record ScrollView
    {
        private readonly List<ImageModel> _imageModels;

        private Vector2 _scrollPosition;

        public ScrollView(List<ImageModel> imageModels)
        {
            _imageModels = imageModels;
        }
        
        public void Content()
        {
            if (_imageModels.Count == 0) return;
            
            GUILayout.Space(10);
            GUILayout.Label(GlobalStrings.ImagesIn, EditorStyles.boldLabel);
            _scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
            
            foreach (var model in _imageModels)
            {
                GUIUtils.DrawImageModel(model, _imageModels.IndexOf(model) + 1);
            }
            
            GUILayout.EndScrollView();
        }
    }
}
#endif