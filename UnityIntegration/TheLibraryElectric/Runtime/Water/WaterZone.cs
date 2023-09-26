using System;
using System.Collections.Generic;
using SLZ.Rig;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Water
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Water/Water Zone")]
    [RequireComponent(typeof(Collider))]
#endif
    public class WaterZone : MonoBehaviour
    {
#if UNITY_EDITOR
    [HideInInspector]
#endif
        public List<RbBuoyancyManager> inTriggerCol = new List<RbBuoyancyManager>();
		[Tooltip("Multiplier on the buoyancy effect")]
        public float buoyancyMultiplier = 1.0f; // Adjust this to control the buoyancy threshold.
		[Tooltip("The mass midpoint used to decide when objects will start to sink. Anything higher than the midpoint will sink")]
        public float midpoint = 50.0f; // Adjust this to control the midpoint of the effect.
#if UNITY_EDITOR
        [Tooltip("If this is true, RBs with a mass that is exactly the midpoint will sink, if false, they will float.")]
#endif
        public bool midpointSink = true; // Will masses at the midpoint sink or float?
		[Tooltip("If dampening is enabled, the object will get slower overtime and eventually stop bobbing.")]
        public bool dampening = true; // If dampening is enabled, drag will increase as the object sinks.
		[Tooltip("Lower = more dampening, this value's a bit weird. May break some stuff")]
        public float dampeningAmount = 0.98f; // Dampening multiplier
		[Tooltip("Should the player be ignored?")]
        public bool ignoreRigManager;
        void OnTriggerEnter(Collider other)
        {
            if(other.GetComponentInParent<Rigidbody>() != null && other.GetComponentInParent<Rigidbody>().GetComponent<RbBuoyancyManager>() == null) // Check if the colliding GameObject has a Rigidbody and doesn't have the RBGravityManager component
            {
                if(other.GetComponentInParent<RigManager>() != null && ignoreRigManager)
                {
                    return;
                }
                if(other.GetComponentInParent<IgnoreRigidbody>() != null)
                {
                    return;
                }
                RbBuoyancyManager themanager = other.GetComponentInParent<Rigidbody>().gameObject.AddComponent<RbBuoyancyManager>(); // Add the RBGravityManager component and set the gravity amount
                themanager.dampening = dampening;
                themanager.buoyancyMultiplier = buoyancyMultiplier;
                themanager.midpoint = midpoint;
                themanager.dampeningAmount = dampeningAmount;
                themanager.midpointSink = midpointSink;
                Rigidbody[] childRbs = other.GetComponentInParent<Rigidbody>().GetComponentsInChildren<Rigidbody>();
                foreach(Rigidbody rb in childRbs)
                {
                    if (rb.isKinematic)
                    {
                        if (rb.GetComponent<RbBuoyancyManager>() == null)
                        {
                            RbBuoyancyManager manager = rb.gameObject.AddComponent<RbBuoyancyManager>();
                            manager.buoyancyMultiplier = buoyancyMultiplier;
                            manager.dampening = dampening;
                            manager.midpoint = midpoint;
                            manager.dampeningAmount = dampeningAmount;
                            manager.midpointSink = midpointSink;
                        }
                    }
                }
                inTriggerCol.Add(other.GetComponentInParent<Rigidbody>().GetComponent<RbBuoyancyManager>()); // Add the colliding GameObject to the list
            }
        }
        void OnTriggerExit(Collider other) // When the GameObject exits the trigger collider
        {
            if (inTriggerCol.Contains(other.GetComponentInParent<Rigidbody>().GetComponent<RbBuoyancyManager>())) // Check if the colliding GameObject is in the list
            {
                other.GetComponentInParent<Rigidbody>().useGravity = true; // Enable gravity
                UnityEngine.Object.Destroy(other.GetComponentInParent<Rigidbody>().GetComponent<RbBuoyancyManager>()); // Destroy the RBGravityManager component
                Rigidbody[] childRbs = other.GetComponentInParent<Rigidbody>().GetComponentsInChildren<Rigidbody>();
                foreach (Rigidbody rb in childRbs)
                {
                    if (rb.isKinematic)
                    {
                        if (rb.GetComponent<RbBuoyancyManager>() != null)
                        {
                            UnityEngine.Object.Destroy(rb.GetComponent<RbBuoyancyManager>());
                        }
                    }
                }
                inTriggerCol.Remove(other.GetComponentInParent<Rigidbody>().GetComponent<RbBuoyancyManager>()); // Remove the colliding GameObject from the list
            }

        }
        void Update()
        {
            foreach(RbBuoyancyManager rBBuoyancyManager in inTriggerCol) // Loop through the list
            {
                if (rBBuoyancyManager != null)
                {
                    rBBuoyancyManager.buoyancyMultiplier = buoyancyMultiplier; // Get the RBGravityManager component & update the gravity amount
                    rBBuoyancyManager.dampening = dampening;
                    rBBuoyancyManager.midpoint = midpoint;
                    rBBuoyancyManager.dampeningAmount = dampeningAmount;
                    rBBuoyancyManager.midpointSink = midpointSink;
                }
            }
        }
#if UNITY_EDITOR
		private void OnDrawGizmos()
        {
			if (Selection.activeGameObject == gameObject)
				return;
            Collider collider = GetComponent<Collider>();

            if (collider != null && (collider is CapsuleCollider || collider is BoxCollider || collider is SphereCollider))
            {
                Gizmos.color = Color.blue;

                // Draw gizmo based on collider type
                if (collider is CapsuleCollider)
                {
                    DrawCapsuleGizmo((CapsuleCollider)collider);
                }
                else if (collider is BoxCollider)
                {
                    DrawBoxGizmo((BoxCollider)collider);
                }
                else if (collider is SphereCollider)
                {
                    DrawSphereGizmo((SphereCollider)collider);
                }
            }
        }
        private void DrawCapsuleGizmo(CapsuleCollider capsuleCollider)
        {
            Vector3 position = transform.position + capsuleCollider.center;
			float height = capsuleCollider.height * transform.lossyScale.y;
			float radius = capsuleCollider.radius * Mathf.Max(transform.lossyScale.x, transform.lossyScale.z);
			Vector3 boxSize = new Vector3(radius * 2, height - 2 * radius, radius * 2);
			Gizmos.DrawWireSphere(position + Vector3.up * (height / 2 - radius), radius);
			Gizmos.DrawWireSphere(position - Vector3.up * (height / 2 - radius), radius);
			Gizmos.DrawWireCube(position, boxSize);
        }

        private void DrawBoxGizmo(BoxCollider boxCollider)
        {
            Vector3 position = transform.position + boxCollider.center;
            Vector3 size = Vector3.Scale(boxCollider.size, transform.lossyScale);
            Gizmos.DrawWireCube(position, size);
        }

        private void DrawSphereGizmo(SphereCollider sphereCollider)
        {
            Vector3 position = transform.position + sphereCollider.center;
            float radius = sphereCollider.radius * Mathf.Max(transform.lossyScale.x, transform.lossyScale.y, transform.lossyScale.z);
            Gizmos.DrawWireSphere(position, radius);
        }
#endif
    }
}