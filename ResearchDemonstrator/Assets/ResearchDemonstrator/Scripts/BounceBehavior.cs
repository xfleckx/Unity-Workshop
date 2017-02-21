using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IAT.ResearchDemonstrator
{

    public class BounceBehavior : MonoBehaviour {

        public float forceEnergy;

        private Rigidbody rb;

	    void Start () {
            rb = GetComponent<Rigidbody>();
	    }
	
        private void OnCollisionEnter(Collision collision)
        {
            rb.AddForce(Vector3.up * forceEnergy);
        }
    }

}
