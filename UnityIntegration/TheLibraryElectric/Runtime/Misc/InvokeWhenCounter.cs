using System;
using UnityEngine;
using UltEvents;

namespace TheLibraryElectric.Misc
{
    [AddComponentMenu("The Library Electric/Misc/Invoke When Counter Reached")]
    public class InvokeWhenCounter : ElectricBehaviour
    {
        private float counter;
        [Tooltip("The number needed for the counter to reach before invoking.")]
        public float countersNeeded = 5;
        [Tooltip("The event to invoke when the counter reaches the number needed.")]
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
    }
}