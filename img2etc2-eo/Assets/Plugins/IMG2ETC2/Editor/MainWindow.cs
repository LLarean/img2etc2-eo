#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LLarean.IMG2ETC2
{
    public class MainWindow : EditorWindow
    {
        private readonly ImageLoader _imageLoader = new();
        private readonly ImageProcessor _imageProcessor = new();
        
        private List<ImageModel> _imageModels = new();
        
        private FolderPath _folderPath  = new(Application.dataPath);
        
        private bool _includeSubfolders = true;
        private Vector2 _scrollPosition;
        private TextureItems _textureItems;

        [MenuItem("Tools/IMG2ETC22")]
        private static void ShowWindow()
        {
            GetWindow<MainWindow>("IMG2ETC2");
        }

        private void OnEnable()
        {
            _folderPath = new FolderPath(Application.dataPath);
        }

        private void OnGUI()
        {
            DrawFolderSettings();
            DrawActionButtons();
            new ScrollView(_imageModels).Content();
        }

        private void DrawFolderSettings()
        {
            EditorGUILayout.TextField(GlobalStrings.FolderPath, _folderPath.Value());
            
            EditorGUI.BeginChangeCheck();
            _includeSubfolders = EditorGUILayout.Toggle(GlobalStrings.IncludeSubfolders, _includeSubfolders);
            
            if (EditorGUI.EndChangeCheck())
            {
                LoadImages();
            }
            
            if (GUILayout.Button(GlobalStrings.SelectFolder) == true)
            {
                SelectFolder();
            }

            if (Event.current.keyCode == KeyCode.Return)
            {
                var folderPath = EditorGUILayout.TextField(GlobalStrings.FolderPath, _folderPath.Value());
                _folderPath = new FolderPath(folderPath);
            }
        }

        private void DrawActionButtons()
        {
            if (_imageModels.Count == 0) return;
            
            GUILayout.Space(10);

            if (GUILayout.Button(GlobalStrings.ResizeImages) == true)
            {
                _imageProcessor.ResizeImages(_imageModels);
            }
        }

        private void SelectFolder()
        {
            var folderPath = EditorUtility.OpenFolderPanel(GlobalStrings.SelectFolder, _folderPath.Value(), "");
            
            if (string.IsNullOrEmpty(folderPath) == false)
            {
                _folderPath = new FolderPath(folderPath);
                LoadImages();
            }
        }

        private void LoadImages()
        {
            _textureItems = new TextureItems(_folderPath.Value(), _includeSubfolders);
            _imageModels = _imageLoader.LoadImages(_folderPath.Value(), _includeSubfolders);
        }
    }
}
#endif