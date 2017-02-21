using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IAT.ResearchDemonstrator
{

    public class BounceBehavior : MonoBehaviour {

        public BounceParameter param;

        public float bounceEnergy;

        private Rigidbody rb;

	    void Start () {
            rb = GetComponent<Rigidbody>();
	    }
	
        private void OnCollisionEnter(Collision collision)
        {
            if(param)
                rb.AddForce(Vector3.up * param.bounceEnergy);
            else
                rb.AddForce(Vector3.up * bounceEnergy);
        }
    }

}
