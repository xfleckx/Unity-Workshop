using System;
using UnityEngine;

namespace IAT.ResearchDemonstrator
{

    public class BounceBehavior : MonoBehaviour {

        public BounceParameter param;

        public float bounceEnergy;

        public Action OnBallHitsThefloor;

        private Rigidbody rb;

        private bool ballShouldBounce;

        void Start () {
            rb = GetComponent<Rigidbody>();
	    }
	
        private void OnCollisionEnter(Collision collision)
        {
            if (!ballShouldBounce)
                return;

            if (OnBallHitsThefloor != null)
                OnBallHitsThefloor();

            applyForce();
        }

        private void applyForce()
        {
            if (param)
                rb.AddForce(Vector3.up * param.bounceEnergy);
            else
                rb.AddForce(Vector3.up * bounceEnergy);
        }

        public void LetTheBallBounce()
        {
            applyForce();
            ballShouldBounce = true;
        }

        public void DisableTheBounceForce()
        {
            ballShouldBounce = false;
        }
    }

}
