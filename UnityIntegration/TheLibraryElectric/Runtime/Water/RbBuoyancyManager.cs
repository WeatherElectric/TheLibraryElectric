using UnityEngine;
using System;

namespace TheLibraryElectric.Water
{
#if UNITY_EDITOR
        [HideInInspector]
#endif
    public class RbBuoyancyManager : MonoBehaviour
    {
        public Rigidbody thisRb;
        public float buoyancyMultiplier; // Adjust this to control the buoyancy threshold.
        public float midpoint; // Adjust this to control the midpoint of the buoyancy threshold.
        public bool midpointSink; // Will masses at the midpoint sink or float?
        public bool dampening; // If dampening is enabled, drag will increase as the object sinks.
        public float dampeningAmount; // Dampening multiplier

        private void Start()
        {
            thisRb = GetComponent<Rigidbody>(); // Get the Rigidbody component
            if (thisRb != null)
            {
                thisRb.useGravity = false; // Disable gravity so the scene gravity doesn't interfere
            }
        }
        private void FixedUpdate()
        {
            // If mass is smaller than midpoint, float
            if (thisRb != null && thisRb.mass < midpoint)
            {
                float buoyantForce = thisRb.mass + Physics.gravity.magnitude * buoyancyMultiplier;
                thisRb.AddForce(Vector3.up * buoyantForce);
                if (dampening)
                { 
                    thisRb.velocity *= dampeningAmount;
                }
            }
            // If mass is bigger than midpoint, sink
            if (thisRb != null && thisRb.mass > midpoint)
            {
                float buoyantForce = thisRb.mass + Physics.gravity.magnitude * buoyancyMultiplier;
                thisRb.AddForce(Vector3.down * buoyantForce);
                if (dampening)
                { 
                    thisRb.velocity *= dampeningAmount;
                }
            }
            // If mass is the midpoint, go based off the settings
            if (thisRb != null && thisRb.mass == midpoint)
            {
                if (midpointSink)
                {
                    float buoyantForce = thisRb.mass + Physics.gravity.magnitude * buoyancyMultiplier;
                    thisRb.AddForce(Vector3.down * buoyantForce);
                    if (dampening)
                    { 
                        thisRb.velocity *= dampeningAmount;
                    }
                }
                if (!midpointSink)
                {
                    float buoyantForce = thisRb.mass + Physics.gravity.magnitude * buoyancyMultiplier;
                    thisRb.AddForce(Vector3.up * buoyantForce);
                    if (dampening)
                    { 
                            thisRb.velocity *= dampeningAmount;
                    }
                }
            }
        }
    }
}