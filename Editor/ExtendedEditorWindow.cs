using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class ExtendedEditorWindow : EditorWindow
{
    protected SerializedObject serializedObject;
    protected SerializedProperty serializedProperty;
    protected SerializedProperty currentProperty;


    protected void DrawProperties(SerializedProperty props,bool drawChildern)
    {
        string lastPropPath = string.Empty;
        foreach (SerializedProperty p in props)
        {
            if(p.isArray && p.propertyType == SerializedPropertyType.Generic)
            {
                EditorGUILayout.BeginHorizontal();
                p.isExpanded = EditorGUILayout.Foldout(p.isExpanded, p.displayName);
                EditorGUILayout.EndHorizontal();

                if (p.isExpanded)
                {
                    EditorGUI.indentLevel++;
                    EditorGUI.indentLevel--;
                    DrawProperties(p,drawChildern);
                }
            }
            else
            {
                if(!string.IsNullOrEmpty(lastPropPath) && p.propertyPath.Contains(lastPropPath))
                {
                    continue;
                }
                lastPropPath = p.propertyPath;
                EditorGUILayout.PropertyField(p, drawChildern);
            }
        }
    }
}
