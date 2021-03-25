using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

namespace LevelDesigner
{
    public class AssetHandler
    {
        [OnOpenAsset()]
        public static bool OpenEditor(int instanceId, int line)
        {
            SOLevelAssets assets = EditorUtility.InstanceIDToObject(instanceId) as SOLevelAssets;
            if (assets != null)
            {
                LevelDesingEditorWindow.showWindow(assets);
                return true;
            }
            return false;
        }
    }

    [CustomEditor(typeof(SOLevelAssets))]
    public class LevelDataCustomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Level Designer"))
            {
                //LevelDesingEditorWindow.showWindow((SOLevelAssets)target);
                SOLevelAssets s = (SOLevelAssets)target;
                float w = s.LevelGrid.x * s.GridOffset * 3;
                float h = s.LevelGrid.y * s.GridOffset * 3;
                UPASession.CreateImage((int)w,(int)h);
               
            }
        }
    }
}

