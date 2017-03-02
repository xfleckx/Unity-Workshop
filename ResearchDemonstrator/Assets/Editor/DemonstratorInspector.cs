using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace IAT.ResearchDemonstrator.EditorExtensions
{
    [CustomEditor(typeof(Demonstrator))]
    public class DemonstratorInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            var instance = target as Demonstrator;

            var instanceIsAPrefab = !isAPrefab(instance.gameObject);

            if (instanceIsAPrefab && EditorApplication.isPlaying)
            {
                if (GUILayout.Button("Bounce the ball"))
                {
                    instance.BounceTheBallNTimes();
                }

                EditorGUILayout.FloatField("Hits: ", instance.GetHitCount(), EditorStyles.boldLabel);

                // force the constant update of the inspector
                EditorUtility.SetDirty(target);
            }

            base.OnInspectorGUI();

        }

        private bool isAPrefab(GameObject instance)
        {
            return PrefabUtility.GetPrefabParent(instance) == null && PrefabUtility.GetPrefabObject(instance) != null;
        }
    }

}