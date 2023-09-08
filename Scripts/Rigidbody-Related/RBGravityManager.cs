using System;
using UnityEngine;

namespace TheLibraryElectric
{
    public class RBGravityManager : MonoBehaviour
    {
        public Rigidbody thisRb;
        public Vector3 gravityAmount;
        public Vector3 GravityAmount
        {
            get { return gravityAmount; }
            set { gravityAmount = value; }
        }
        void Start()
        {
            thisRb = GetComponent<Rigidbody>(); // Get the Rigidbody component
            if (thisRb != null)
            {
                thisRb.useGravity = false; // Disable gravity so the scene gravity doesn't interfere
            }
        }
        void FixedUpdate()
        {
            if (thisRb != null)
            {
                thisRb.AddForce(gravityAmount * thisRb.mass, ForceMode.Force); // Add the gravity force
            }
        }
#if !UNITY_EDITOR
        public RBGravityManager(IntPtr ptr) : base(ptr) { }
#endif
    }
}
