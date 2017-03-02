using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace IAT.ResearchDemonstrator
{
    public class Demonstrator : MonoBehaviour
    {
        private BounceBehavior ball;

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

            var floor = transform.FindChild("Floor");
            Assert.IsNotNull(floor, "Prefab corrupt - missing a 'Floor' as children of the Demonstrator");
        }

        private IEnumerator WatchBall(int targetBounceCount)
        {
            hitCount = 0;

            yield return new WaitWhile(() => hitCount != targetBounceCount);

            if(onBallReachedTargetHitCount.GetPersistentEventCount() > 0)
            {
                onBallReachedTargetHitCount.Invoke(hitCount, ball);
            }

        }

        #region public interface for the prefab user

        // props:
        public BallWatchEvent onBallReachedTargetHitCount; 

        // methods:

        public void BounceTheBallNTimes(int timesToBounce = int.MaxValue)
        {
            IEnumerator watchRoutine = WatchBall(timesToBounce);

            StartCoroutine(watchRoutine);

            ball.LetTheBallBounce();
        }
        
        public int GetHitCount()
        {
            return hitCount;
        }

        #endregion
    }

}
