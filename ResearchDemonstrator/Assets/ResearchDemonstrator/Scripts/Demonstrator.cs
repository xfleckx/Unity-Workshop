using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace IAT.ResearchDemonstrator
{
    public class Demonstrator : MonoBehaviour
    {
        BounceBehavior ball;

        private int hitCount;

        private void Awake()
        {
            checkPrefabInstanceIntegrity();
        }
        
        void Start()
        {
            ball.OnBallHitsThefloor += () =>
            {
                hitCount++;
            };
        }


        private void checkPrefabInstanceIntegrity()
        {
            ball = GetComponentInChildren<BounceBehavior>();
            Assert.IsNotNull(ball, "Prefab corrupt - missing BounceBehavior as children of the Demonstrator instance");

            var floor = transform.FindChild("floor");
            Assert.IsNotNull(floor, "Prefab corrupt - missing a 'Floor' as children of the Demonstrator");
        }

        public void BounceTheBallNTimes(int timesToBounce)
        {
            ball.LetTheBallBounce();
        }

        public int GetHitCount()
        {
            return hitCount;
        }
    }

}
