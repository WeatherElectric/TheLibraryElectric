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
        public float countersNeeded = 5;
        public UltEvent onCounterHit;
        public void Add(float value)
        {
            counter += value;
            if (counter == countersNeeded)
            {
                onCounterHit.Invoke();
                counter = 0;
            }
        }
        public void Subtract(float value)
        {
            counter -= value;
        }
#if !UNITY_EDITOR
        public InvokeWhenCounter(IntPtr ptr) : base(ptr) { }
#endif
    }
}