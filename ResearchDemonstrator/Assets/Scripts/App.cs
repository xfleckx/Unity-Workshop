using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour {

    private void OnGUI()
    { 
        if(AppStartUp.options == null)
        {
            GUILayout.Label("RuntimeLoad not done");
            return;
        }


        GUILayout.Label(AppStartUp.options.aMessage);
    }
}
