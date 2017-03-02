using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class SettingsExample {
     
    [InitializeOnLoadMethod]
    static void SetupProjectSettings()
    {
        Debug.Log("Project Settings Setup!");

        if(EditorSettings.serializationMode != SerializationMode.ForceText)
        {
            //if(EditorUtility.DisplayDialog("Expected Option", "Setting Asset Serialization to Text", "Yes", "no")) { 
                EditorSettings.serializationMode = SerializationMode.ForceText;
            //}
        }
    }
}
