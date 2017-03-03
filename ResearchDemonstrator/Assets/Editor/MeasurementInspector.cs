using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace IAT.ResearchDemonstrator.EditorExtensions
{
    [CustomEditor(typeof(Measurement))]
    public class MeasurementInspector : Editor
    {

        public override void OnInspectorGUI()
        {
            var instance = target as Measurement;

            base.OnInspectorGUI();

            if (EditorApplication.isPlaying && GUILayout.Button("Measure"))
            {
                instance.BeginMeasurement();
            }

            if (EditorApplication.isPlaying && GUILayout.Button("Finalize"))
            {
                instance.FinalizeMeasurement();
            }
        }

        #region GIZMO DEMO

        [DrawGizmo(GizmoType.Active | GizmoType.NotInSelectionHierarchy | GizmoType.InSelectionHierarchy)]
        public static void OnDrawGizmos(Measurement instance, GizmoType type)
        {
            if (instance.demo == null)
                return;

            var floor = instance.demo.gameObject.transform.FindChild("Floor");

            var targetHeightPosition = floor.transform.up + Vector3.up * instance.TargetHeight;

            Handles.Label(targetHeightPosition, "Target Height: " + instance.TargetHeight, EditorStyles.boldLabel);

            Handles.DrawWireDisc(targetHeightPosition, floor.transform.up, 2);
        }

        #endregion
    }
}
