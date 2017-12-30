using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
public class WWWTestingWindow : EditorWindow
{

    WWWManager wwwManager = null;
    string myString = "";
    string url = "http://192.168.0.199:8000/";

    [MenuItem("Window/Server Testing")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(WWWTestingWindow));
    }

    private void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        url = EditorGUILayout.TextField("URL", url);

        if (GUILayout.Button("Find WWW Manager"))
            FindWWWManager();

        if (GUILayout.Button("Connect"))
            Connect();


    }

    void FindWWWManager()
    {
        wwwManager = GameObject.FindGameObjectWithTag("System").GetComponent<WWWManager>();
        Debug.Log("wwwManager = null: " + wwwManager == null);
    }

    void Connect()
    {
        if (wwwManager != null)
            wwwManager.Connect();
    }


   

}
#endif
