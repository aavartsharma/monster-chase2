using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

public class checlistWindow : EditorWindow
{
    private string textFieldText = "";
    private struct checkil
    {
        public List<string> str;
        public List<bool> boolen;
    }
    

    [MenuItem("myWindow/CheckList")]
    public static void ShowWindow()
    {
        GetWindow<checlistWindow>("Check List");
    }
    void OnGUI()
    {
        string jsonListString = File.ReadAllText(Application.dataPath + "editorfile.json");
        checkil JsonObject = JsonUtility.FromJson<checkil>(jsonListString);
        
        GUILayout.Label("Write The Text Here",EditorStyles.boldLabel);
        textFieldText = EditorGUILayout.TextField("text",textFieldText);

        if(GUILayout.Button("Save"))
        {
            JsonObject.str.Add(textFieldText);
            JsonObject.boolen.Add(false);
        }
        if(GUILayout.Button("Clear All point"))
        {
            JsonObject.str.Clear();
            JsonObject.boolen.Clear();
        }
        GUILayout.Label("",EditorStyles.boldLabel);
        GUILayout.Label("This Are The Text",EditorStyles.boldLabel);
        for(int i = 0; i < JsonObject.str.Count;i++)
        {
            bool ischeck = JsonObject.boolen[i];
            string label = JsonObject.str[i].ToUpper();
            ischeck = EditorGUILayout.Toggle(JsonObject.str[i],ischeck);
            JsonObject.boolen[i] = ischeck;

        }

        string jsson = JsonUtility.ToJson(JsonObject);
        File.WriteAllText(Application.dataPath + "editorfile.json", jsson);
       
        
    }

}

