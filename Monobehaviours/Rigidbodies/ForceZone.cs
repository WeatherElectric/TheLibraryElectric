using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheLibraryElectric.Rigidbodies
{
    public class ForceZone : MonoBehaviour
    {
        public List<Rigidbody> inTriggerRbs = new List<Rigidbody>();
        public Vector3 forceAmount;
        public Vector3 ForceAmount
        {
            get { return forceAmount; }
            set { forceAmount = value; }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody != null)
            {
                inTriggerRbs.Add(other.attachedRigidbody);
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.attachedRigidbody != null && inTriggerRbs.Contains(other.attachedRigidbody))
            {
                inTriggerRbs.Remove(other.attachedRigidbody);
            }
        }
        void Update()
        {
            foreach (Rigidbody rb in inTriggerRbs)
            {
                rb.AddForce(forceAmount, ForceMode.Force);
            }
        }
#if !UNITY_EDITOR
        public ForceZone(IntPtr ptr) : base(ptr) { }
#endif
    }
}
