using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelDesigner
{
    [CreateAssetMenu(fileName = "AssetList", menuName = "LevelAssets")]
    public class SOLevelAssets : ScriptableObject
    {
        public PixelToPrefeb[] levelLayers;
        public Vector2 LevelGrid;
        public int GridOffset;


        public PixelToPrefeb[] getLayers()
        {
            return levelLayers;
        }
    }
}


