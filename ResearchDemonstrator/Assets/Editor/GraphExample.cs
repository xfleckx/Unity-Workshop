using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using IAT.ResearchDemonstrator;

public class GraphExample : EditorWindow {

    [MenuItem("Window/Demo")]
    private static void showDemoWindow()
    {
        var window = CreateInstance<GraphExample>();
        
        window.Show();
    }

    private Demonstrator instance;

    private void OnEnable()
    {
        instance = FindObjectOfType<Demonstrator>();

    }

    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal(GUILayout.MinWidth(500));
        
        EditorGUILayout.BeginVertical(GUILayout.MinWidth(500), GUILayout.MinHeight(300));

        var rect = new Rect(position.position.x, position.position.y, 100, 100);

        RenderGraphsForChannels(rect);

        EditorGUILayout.EndVertical();

        EditorGUILayout.EndHorizontal();
    }

    public void OnInspectorUpdate()
    {
        SamplePositionOfBall();
        // This will only get called 10 times per second.
        Repaint();
    }

    private void SamplePositionOfBall()
    {
        if (instance)
        {

        }
    }

    private void RenderGraphsForChannels(Rect renderingArea)
    {
        int W = (int)renderingArea.width;
        int H = (int)renderingArea.height;
        
        int xPix = (int)renderingArea.x + (W - 1) - H;
        while(xPix < W)
        {
            if (xPix >= 0)
            {
                float y = Mathf.Sin(xPix + UnityEngine.Random.Range(0.2f, 0.3f));

                float y_01 = Mathf.InverseLerp(0, 1, y);

                int yPix = (int)(y_01 * H);
                Handles.DrawLine(new Vector3(xPix, yPix, 0), new Vector3(xPix, 1 - yPix , 0));

            }
            xPix++;
        }
        
            

    }
}
