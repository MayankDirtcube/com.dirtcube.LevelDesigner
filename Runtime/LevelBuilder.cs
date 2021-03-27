using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelDesigner;

public class LevelBuilder : MonoBehaviour
{
    public SOLevelAssets[] ListOfLevels;
    void Start()
    {
        foreach(SOLevelAssets level in ListOfLevels)
        {
            LevelGenrater(level);
        }
    }

    private void LevelGenrater(SOLevelAssets level)
    {
        GameObject top = new GameObject(level.name);
        top.transform.parent = transform;
        AssetSpwaner(level.levelAssets,top.transform);
        AssetSpwaner(level.floorTills,top.transform);

    }

    private void AssetSpwaner(PixelToPrefeb[] assetlist, Transform Currentparent)
    {
        GameObject t = new GameObject(assetlist.ToString());
        t.transform.parent = Currentparent;

        foreach (PixelToPrefeb n in assetlist)
        {
            foreach (Vector2 pos in n.postions)
            {
                Vector3 postion = new Vector3(pos.x, 0, pos.y);
                GameObject.Instantiate(n.Prefeb, postion, Quaternion.identity, t.transform);
            }
        }
    }
}
