using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

namespace IAT.ResearchDemonstrator
{
    [Serializable]
    public class BallWatchEvent : UnityEvent<int, BounceBehavior>
    {
        // nothing to here
    }
}
