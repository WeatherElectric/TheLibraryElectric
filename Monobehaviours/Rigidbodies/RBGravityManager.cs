using System;
using UnityEngine;

namespace TheLibraryElectric.Rigidbodies
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Rigidbody Related/RB Gravity Manager")]
    [RequireComponent(typeof(Rigidbody))]
#endif
    public class RBGravityManager : MonoBehaviour
    {
#if UNITY_EDITOR
        [HideInInspector]
#endif
        public Rigidbody thisRb;
        public Vector3 gravityAmount;
        internal Action<RBGravityManager> onDestroyed = null;
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
        private void OnDestroy()
        {
            onDestroyed?.Invoke(this);
        }
#if !UNITY_EDITOR
        public RBGravityManager(IntPtr ptr) : base(ptr) { }
#endif
    }
}