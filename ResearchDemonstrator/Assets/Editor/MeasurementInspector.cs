using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace IAT.ResearchDemonstrator.EditorExtensions
{
    public class MeasurementInspector : Editor
    {

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
    }
}
