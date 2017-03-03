using IAT.ResearchDemonstrator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class App : MonoBehaviour {

    private const bool doPrettyPrint = true;
     
    public void SaveResultFile(MeasurementResultCollection result)
    {
        var path = Path.Combine(Environment.CurrentDirectory, "result.json");
        var file = new FileInfo(path);
        
        using (var writter = new StreamWriter(file.FullName))
        {
            var wellFormattedJsonString = JsonUtility.ToJson(result, doPrettyPrint);

            writter.Write(wellFormattedJsonString);
        }
    }

    private void OnGUI()
    { 
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 18;
         
         // Set color for selected and unselected buttons
         style.normal.textColor = Color.red;

        if(AppStartUp.options == null)
        {
            GUILayout.Label("RuntimeLoad not done");
            return;
        }


        GUILayout.Label(AppStartUp.options.aMessage);
    }
}
