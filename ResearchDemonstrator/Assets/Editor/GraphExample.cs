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
        var window = EditorWindow.GetWindow<GraphExample>();
        
        window.Show();
    }

    private Demonstrator instance;
    private Measurement measurement;

    private BounceParameter parameter;
    private float targetHeight = 5;
    private void OnEnable()
    {
        instance = FindObjectOfType<Demonstrator>();

        measurement = FindObjectOfType<Measurement>();

        if (EditorApplication.isPlaying)
            parameter = instance.GetBall().param;



    }

    private Queue<float> samples = new Queue<float>();

    private void Update()
    {
        if (EditorApplication.isPlaying) { 
            SamplePositionOfBall();
            Repaint();
        }
    }

    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal(GUILayout.Height(300));
        
        var rectB = EditorGUILayout.BeginVertical(GUILayout.MinWidth(200), GUILayout.MinHeight(300));

        if (EditorApplication.isPlaying && GUILayout.Button("Bounce the ball"))
        {
            instance.BounceTheBallNTimes();
        }

        EditorGUILayout.EndVertical();


        if (parameter != null)
            parameter.bounceEnergy = GUILayout.VerticalSlider(parameter.bounceEnergy, 500, 0);

        var rectA = EditorGUILayout.BeginVertical(GUILayout.MinWidth(200), GUILayout.MinHeight(300));

        EditorGUILayout.LabelField("Ball Height:");

        if(Event.current.type == EventType.Repaint)
        {

            EditorGUI.DrawRect(rectA, Color.black);
            RenderGraphsForChannels(rectA);
        }
        

        EditorGUILayout.EndVertical();
        

        EditorGUILayout.EndHorizontal();
    }

    public void OnInspectorUpdate()
    {
        // This will only get called 10 times per second.
        Repaint();
    }

    private void SamplePositionOfBall()
    {
        if (instance)
        {
            var currentBallHeight = instance.GetBall().transform.position.y;

            if(samples.Count >= 200)
            {
                samples.Dequeue();
                samples.Enqueue(currentBallHeight);

            }else
            {
                samples.Enqueue(currentBallHeight);
            }
        }
    }

    private void RenderGraphsForChannels(Rect renderingArea)
    {
        int W = (int)renderingArea.width;
        int H = (int)renderingArea.height;
        
        int xPix = (int)renderingArea.x;
        var rightBorder = xPix + (W - 1);

        foreach (var sample in samples)
        {

            float y_01 = Mathf.InverseLerp(0, measurement.TargetHeight, sample);
            int yPix = (int)renderingArea.y + (int)(y_01 * H);

            var lineStart = new Vector3(xPix, H, 0);
            var lineEnd = new Vector3(xPix, yPix, 0);

            Handles.DrawLine(lineStart, lineEnd);

            xPix++;
        }


    }
}
