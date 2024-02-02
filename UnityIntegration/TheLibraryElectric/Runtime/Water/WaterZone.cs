using UnityEditor;
using System.Collections.Generic;
using SLZ.Rig;
using UnityEngine;

namespace TheLibraryElectric.Water
{
    [AddComponentMenu("The Library Electric/Water/Water Zone")]
    public class WaterZone : ElectricBehaviour
    {
        [HideInInspector]
        public List<RbBuoyancyManager> inTriggerCol = new List<RbBuoyancyManager>();
        [Tooltip("The multiplier for the buoyancy.")]
        public float buoyancyMultiplier = 1.0f; // Adjust this to control the buoyancy threshold.
        [Tooltip("The midpoint of mass where things start to sink.")]
        public float midpoint = 50.0f; // Adjust this to control the midpoint of the effect.
        [Tooltip("Should objects right at the midpoint sink or float?")]
        public bool midpointSink = true; // Will masses at the midpoint sink or float?
        [Tooltip("Should dampening be enabled?")]
        public bool dampening = true; // If dampening is enabled, drag will increase as the object sinks.
        [Tooltip("The dampening multiplier.")]
        public float dampeningAmount = 0.98f; // Dampening multiplier
        [Tooltip("Should the water ignore the player?")]
        public bool ignoreRigManager;

        private void OnTriggerEnter(Collider other)
        {
            var colliderRigidbody = other.attachedRigidbody;
            if (colliderRigidbody != null && colliderRigidbody.GetComponent<RbBuoyancyManager>() == null) // Check if the colliding GameObject has a Rigidbody and doesn't have the RBGravityManager component
            {
                if (other.GetComponentInParent<RigManager>() != null && ignoreRigManager)
                {
                    return;
                }

                var themanager = colliderRigidbody.gameObject.AddComponent<RbBuoyancyManager>(); // Add the RBGravityManager component and set the gravity amount

                if(other.GetComponentInParent<IgnoreRigidbody>() != null)
                {
                    return;
                }
                
                themanager.dampening = dampening;
                themanager.buoyancyMultiplier = buoyancyMultiplier;
                themanager.midpoint = midpoint;
                themanager.dampeningAmount = dampeningAmount;
                themanager.midpointSink = midpointSink;
                Rigidbody[] childRbs = colliderRigidbody.GetComponentsInChildren<Rigidbody>(true);
                foreach (var rb in childRbs)
                {
                    if (rb.isKinematic)
                    {
                        if (rb.GetComponent<RbBuoyancyManager>() == null)
                        {
                            var manager = rb.gameObject.AddComponent<RbBuoyancyManager>();
                            manager.buoyancyMultiplier = buoyancyMultiplier;
                            manager.dampening = dampening;
                            manager.midpoint = midpoint;
                            manager.dampeningAmount = dampeningAmount;
                            manager.midpointSink = midpointSink;
                        }
                    }
                }
                inTriggerCol.Add(themanager); // Add the colliding GameObject to the list
            }
        }

        private void OnTriggerExit(Collider other) // When the GameObject exits the trigger collider
        {
            var colliderRigidbody = other.attachedRigidbody;
            RbBuoyancyManager manager = null;

            if (colliderRigidbody != null)
                manager = colliderRigidbody.GetComponent<RbBuoyancyManager>();

            if (inTriggerCol.Contains(manager)) // Check if the colliding GameObject is in the list
            {
                colliderRigidbody.useGravity = true; // Enable gravity
                UnityEngine.Object.Destroy(manager); // Destroy the RBGravityManager component
                Rigidbody[] childRbs = colliderRigidbody.GetComponentsInChildren<Rigidbody>(true);
                foreach (var rb in childRbs)
                {
                    if (rb.isKinematic)
                    {
                        if (rb.GetComponent<RbBuoyancyManager>() != null)
                        {
                            UnityEngine.Object.Destroy(rb.GetComponent<RbBuoyancyManager>());
                        }
                    }
                }
            }

        }

        private void Update()
        {
            foreach(var rBBuoyancyManager in inTriggerCol) // Loop through the list
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