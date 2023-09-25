using System;
using UnityEngine;
using UltEvents;

namespace TheLibraryElectric.Misc
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Misc/Invoke When Counter Is Hit")]
#endif
    public class InvokeWhenCounter : MonoBehaviour
    {
#if UNITY_EDITOR
        [HideInInspector]
#endif
        public float counter;
#if UNITY_EDITOR
        [Tooltip("The number the counter must reach for the event to be invoked.")]
#endif
        public float countersNeeded = 5.0f;
        public float Counter
        {
            get { return counter; }
            set { counter = value; }
        }
        public UltEvent onCounterHit;
        public void Update()
        {
            const double tolerance = 0.0f;
            if (Math.Abs(counter - countersNeeded) < tolerance)
            {
                onCounterHit.Invoke();
                counter = 0.0f;
            }
        }
#if !UNITY_EDITOR
        public InvokeWhenCounter(IntPtr ptr) : base(ptr) { }
#endif
    }
}