using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(fileName = "AssetList", menuName = "LevelAssets")]
    public class SOLevelAssets : ScriptableObject
    {
        public Texture2D Map;
        public PixelToColor[] assets;
    }
}


