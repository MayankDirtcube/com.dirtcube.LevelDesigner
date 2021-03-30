using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System;

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

            //Level Map Preview
            SOLevelAssets s = (SOLevelAssets)target;

            //PriveiwMap(s.LevelMap);

            if (GUILayout.Button("Level Designer"))
            {
                 s = (SOLevelAssets)target;
                //LevelDesingEditorWindow.showWindow(s);
                float w = s.LevelGrid.x;// * s.GridOffset * 3;
                float h = s.LevelGrid.y;//* s.GridOffset * 3;

                if (s.LevelMap != null)
                {
                    UPASession.OpenImageByAsset(s.LevelMap);
                    //s.LevelMap.Init((int)w, (int)h, s);
                    EditorUtility.SetDirty(s.LevelMap);
                    UPAEditorWindow.CurrentImg = s.LevelMap;
                    EditorPrefs.SetString("currentImgPath", AssetDatabase.GetAssetPath(s.LevelMap));

                    if (UPAEditorWindow.window != null)
                        UPAEditorWindow.window.Repaint();
                    else
                        UPAEditorWindow.Init(s);

                    s.LevelMap.gridSpacing = 10 - Mathf.Abs(s.LevelMap.width - s.LevelMap.height) / 100f;
                }
                else
                {
                    
                    UPASession.CreateImage((int)w, (int)h, s);
                }               
               
            }
        }

        public void PriveiwMap(UPAImage img)
        {
            Rect texPos = GetRect(img);
            Texture2D bg = new Texture2D(1, 1);
            bg.SetPixel(0, 0, Color.clear);
            bg.Apply();
            EditorGUI.DrawTextureTransparent(texPos, bg);
            DestroyImmediate(bg);

            //Calculate the final image from the layers list
            Texture2D _result = UPADrawer.CalculateBlendedTex(img.layers);

            //Draw the image
            _result.SetPixel(1, 1, Color.black);
            //GUI.DrawTexture(texPos, _result);
            EditorGUI.DrawPreviewTexture(texPos,_result);
            

            // Draw a grid above the image (y axis first)
            //for (int x = 0; x <= img.width; x += 1)
            //{
            //    float posX = texPos.xMin + ((float)texPos.width / (float)img.width) * x - 0.2f;
            //    EditorGUI.DrawRect(new Rect(posX, texPos.yMin, 1, texPos.height), UPADrawer.gridBGColor);
            //}
            //// Then x axis
            //for (int y = 0; y <= img.height; y += 1)
            //{
            //    float posY = texPos.yMin + ((float)texPos.height / (float)img.height) * y - 0.2f;
            //    EditorGUI.DrawRect(new Rect(texPos.xMin, posY, texPos.width, 1), UPADrawer.gridBGColor);
            //}
        }

        private Rect GetRect(UPAImage img)
        {
            float ratio = (float)img.height / (float)img.width;
            float w = img.gridSpacing * 30;
            float h = ratio * img.gridSpacing * 30;
            return new Rect(0, 0, w, h);
        }
    }
}

