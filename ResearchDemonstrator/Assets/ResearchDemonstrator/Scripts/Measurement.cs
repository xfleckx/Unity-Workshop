using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace IAT.ResearchDemonstrator
{
    public class Measurement : MonoBehaviour
    {
        public float TargetHeight;

        public Demonstrator demo;

        private bool doSampling;

        private MeasurementResultCollection results;

        public MeasurementFinished OnFinalized;

        private void Start()
        {
            demo = FindObjectOfType<Demonstrator>();

            Assert.IsNotNull(demo, "Instance of Demonstrator prefab not found in scene");
        }

        public void BeginMeasurement()
        {
            results = new MeasurementResultCollection();
            doSampling = true;
            StartCoroutine(sampleContinuously());
        }

        IEnumerator sampleContinuously()
        {
            while (doSampling)
            {
                yield return new WaitForSecondsRealtime(0.2f);

                var sample = new MeasurementResult()
                {
                    ts = Time.timeSinceLevelLoad,
                    value = demo.GetBall().transform.position.y
                };

                results.results.Add(sample);
            }

            if (OnFinalized.GetPersistentEventCount() > 0)
                OnFinalized.Invoke(results);

        }

        public void FinalizeMeasurement()
        {
            doSampling = false;
        }
    }

    [Serializable]
    public class MeasurementResult
    {
        public float ts;
        public float value;
    }

    [Serializable]
    public class MeasurementResultCollection
    {
        public List<MeasurementResult> results = new List<MeasurementResult>();
    }

    [Serializable]
    public class MeasurementFinished : UnityEvent<MeasurementResultCollection>
    {

    }
}