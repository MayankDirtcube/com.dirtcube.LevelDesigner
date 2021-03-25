using UnityEditor;
using Assets;

public class LevelDesingEditorWindow : ExtendedEditorWindow
{
    public static void showWindow(SOLevelAssets levelassets)
    {
        LevelDesingEditorWindow window = GetWindow<LevelDesingEditorWindow>("Level Designer");
        window.serializedObject = new SerializedObject(levelassets);
    }

    private void OnGUI()
    {
        //currentProperty = serializedObject.FindProperty("assets");
        DrawProperties(serializedObject.FindProperty("assets"),true);
    }
}
