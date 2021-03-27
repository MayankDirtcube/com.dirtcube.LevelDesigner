using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelDesigner
{

    [CreateAssetMenu(fileName = "AssetList", menuName = "LevelAssets")]
    public class SOLevelAssets : ScriptableObject
    {
        //[SerializeField]
        //public class Layers
        //{
        //    public PixelToPrefeb[] assets;
        //}

        public PixelToPrefeb[] levelAssets;
        public PixelToPrefeb[] floorTills;
        public Vector2 LevelGrid;
        public int GridOffset;

        public UPAImage LevelMap;

        public PixelToPrefeb[] GetLevelAssets()
        {
            return levelAssets;
        }

        public PixelToPrefeb[] GetFloorAssets()
        {
            return levelAssets;
        }
    }
}


