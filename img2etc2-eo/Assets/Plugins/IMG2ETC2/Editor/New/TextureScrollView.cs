#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace LLarean.IMG2ETC2
{
    public record TextureScrollView : IScrollView
    {
        private Vector2 _scrollPosition;
        
        public void Begin()
        {
            GUILayout.Space(10);
            GUILayout.Label(GlobalStrings.ImagesIn, EditorStyles.boldLabel);
            _scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
        }

        public void End()
        {
            GUILayout.EndScrollView();
        }
    }
}
#endif