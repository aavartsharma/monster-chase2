using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

public class checlistWindow : EditorWindow
{
    private string textFieldText = "";
    private Vector2 scrollp = Vector2.zero;
    private struct checkil
    {
        public List<string> checkStr;
        public List<string> testStr;
        public List<bool> checkBoolen;
        public List<bool> testBoolen;
        public string remark;
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
        if(JsonObject.checkStr.Count != JsonObject.checkBoolen.Count)
        {
            Debug.LogError("JsonObject have unmatched <color=#8B0000>CHECK</color> string and  list make sure that they have same length");
        }
        if(JsonObject.testStr.Count != JsonObject.testBoolen.Count)
        {
            Debug.LogError("JsonObject have unmatched <color=#8B0000>TEST</color> string and  list make sure that they have same length");
        }
        GUILayout.Space(5);
        GUILayout.Label("Write The Text Here",EditorStyles.boldLabel);
        textFieldText = EditorGUILayout.TextField("text",textFieldText);

        EditorGUILayout.BeginHorizontal(); // button Horizontal
        if(GUILayout.Button("Add To Checklist"))
        {
            JsonObject.checkStr.Add(textFieldText);
            JsonObject.checkBoolen.Add(false);
        }
        if(GUILayout.Button("Add to Test"))
        {
            JsonObject.testStr.Add(textFieldText);
            JsonObject.testBoolen.Add(false);
        }
        if(GUILayout.Button("Add commit"))
        {
            JsonObject.remark = textFieldText;
        }
        if(GUILayout.Button("Clear All point"))
        {
            bool Delet = EditorUtility.DisplayDialog("Check List","Are you sure to delete all the checkpoints","Yes","No");
            if(Delet)
            {
                JsonObject.checkStr.Clear();
                JsonObject.checkBoolen.Clear();
                EditorUtility.DisplayDialog("Deleted", "All the checkpoints are Removed","Ok");
            }
            
        }
        EditorGUILayout.EndHorizontal();
        GUILayout.Label("",EditorStyles.boldLabel);
        scrollp = EditorGUILayout.BeginScrollView(scrollp,false,true);
        GUILayout.Label("Commite",EditorStyles.boldLabel);
        GUILayout.Label(JsonObject.remark);
        GUILayout.Label("",EditorStyles.boldLabel);
        GUILayout.Label("CheckPoints",EditorStyles.boldLabel);
        for(int i = 0; i < JsonObject.checkStr.Count;i++)
        {
            bool ischeck = JsonObject.checkBoolen[i];
            string label = (i+1).ToString() + ".) " +JsonObject.checkStr[i];
            EditorGUILayout.BeginHorizontal();
            ischeck = EditorGUILayout.Toggle(ischeck,GUILayout.Width(50));
            GUILayout.Label(label);
            EditorGUILayout.EndHorizontal();
            JsonObject.checkBoolen[i] = ischeck;
        }
        GUILayout.Label("",EditorStyles.boldLabel);
        GUILayout.Label("To Be Tested",EditorStyles.boldLabel);

        for(int i = 0; i < JsonObject.testStr.Count;i++)
        {
            bool ischeck = JsonObject.testBoolen[i];
            string label = (i+1).ToString() + ".) " +JsonObject.testStr[i];
            EditorGUILayout.BeginHorizontal();
            ischeck = EditorGUILayout.Toggle(ischeck,GUILayout.Width(50));
            GUILayout.Label(label);
            EditorGUILayout.EndHorizontal();
            JsonObject.testBoolen[i] = ischeck;
        }
        GUILayout.Label("",EditorStyles.boldLabel);
        
        string json = JsonUtility.ToJson(JsonObject);
        File.WriteAllText(Application.dataPath + "editorfile.json", json);
        EditorGUILayout.EndScrollView();
       
        
    }

}

