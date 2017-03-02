using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

namespace IAT.ResearchDemonstrator
{
    public class Measurement : MonoBehaviour
    {
        public float TargetHeight;

        public Demonstrator demo;

        private void Start()
        {
            demo = FindObjectOfType<Demonstrator>();

            Assert.IsNotNull(demo, "Instance of Demonstrator prefab not found in scene");
        }


    }
}

