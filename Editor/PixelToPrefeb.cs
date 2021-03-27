using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelDesigner
{
    [System.Serializable]
    public class PixelToPrefeb
    {
        public Color color;
        public GameObject Prefeb;
        [HideInInspector]
        public List<Vector2> postions;

        public void add(Vector2 pos)
        {
            postions.Add(pos);
        }
        public void clear()
        {
            postions.Clear();
        }
    }
}

