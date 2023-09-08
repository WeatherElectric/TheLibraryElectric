using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheLibraryElectric
{
    public class GravityChamber : MonoBehaviour
    {
        public List<Collider> inTriggerCol = new List<Collider>();
        public Vector3 gravityAmount;
        public Vector3 GravityAmount
        {
            get { return gravityAmount; }
            set { gravityAmount = value; }
        }
        void OnTriggerEnter(Collider other)
        {
            if(other.GetComponentInParent<Rigidbody>() != null && other.GetComponentInParent<Rigidbody>().GetComponent<RBGravityManager>() == null) // Check if the colliding GameObject has a Rigidbody and doesn't have the RBGravityManager component
            {
                other.GetComponentInParent<Rigidbody>().gameObject.AddComponent<RBGravityManager>().gravityAmount = gravityAmount; // Add the RBGravityManager component and set the gravity amount
                inTriggerCol.Add(other); // Add the colliding GameObject to the list
            }
        }
        void OnTriggerExit(Collider other) // When the GameObject exits the trigger collider
        {
            if (inTriggerCol.Contains(other)) // Check if the colliding GameObject is in the list
            {
                other.GetComponentInParent<Rigidbody>().useGravity = true; // Enable gravity
                UnityEngine.Object.Destroy(other.GetComponentInParent<Rigidbody>().GetComponent<RBGravityManager>()); // Destroy the RBGravityManager component
                inTriggerCol.Remove(other); // Remove the colliding GameObject from the list
            }

        }
        void Update()
        {
            foreach(Collider collider in inTriggerCol) // Loop through the list
            {
                if (collider != null)
                {
                    collider.GetComponentInParent<Rigidbody>().GetComponent<RBGravityManager>().gravityAmount = gravityAmount; // Get the RBGravityManager component & update the gravity amount
                }
            }
        }
#if !UNITY_EDITOR
        public GravityChamber(IntPtr ptr) : base(ptr) { }
#endif
    }
}
