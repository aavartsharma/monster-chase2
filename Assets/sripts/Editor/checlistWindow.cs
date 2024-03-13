using UnityEngine;
using UnityEditor;
using System.IO;

public class checlistWindow : EditorWindow
{
    private bool g= true;
    [MenuItem("Window/CheckList")]
    public static void ShowWindow()
    {
        GetWindow<checlistWindow>("Check List");
    }
    void OnGUI()
    {
        GUILayout.Label("This is a lebal.",EditorStyles.boldLabel);
        g = EditorGUILayout.Toggle("sdfsdf",g);
    }
}
