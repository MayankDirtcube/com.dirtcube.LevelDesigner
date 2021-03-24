using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MainWindow : EditorWindow
{
    [MenuItem("Window/Level Designer")]
    public static void ShowWindow()
    {
        GetWindow<MainWindow>("Level Desinger");
    }

    private void OnGUI()
    {
        GUILayout.Label("Level Desinger",EditorStyles.boldLabel);
        
    }
}
