using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GraphExample : EditorWindow {

    [MenuItem("Window/Demo")]
    private static void showDemoWindow()
    {
        var window = CreateInstance<GraphExample>();
        
        window.Show();
    }


    Camera meshCam;

    private void OnEnable()
    {
        meshCam = new GameObject("DemoCam").AddComponent<Camera>();
    }


    private void OnGUI()
    {
        if(Event.current.type == EventType.Repaint)
        {
            meshCam.cameraType = CameraType.SceneView;
            meshCam.Render();
        }
    }

    public void OnInspectorUpdate()
    {
        // This will only get called 10 times per second.
        Repaint();
    }

    private void OnDisable()
    {
        DestroyImmediate(meshCam.gameObject);
    }
}
