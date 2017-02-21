using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IAT.ResearchDemonstrator
{


    [CreateAssetMenu(fileName = "BounceParams", menuName = "IAT/BounceParams", order = 1000)]
    public class BounceParameter : ScriptableObject
    {
        public float bounceEnergy;
    }

}
