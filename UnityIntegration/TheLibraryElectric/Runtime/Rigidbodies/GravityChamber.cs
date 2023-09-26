using System;
using System.Collections.Generic;
using SLZ.Rig;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Rigidbodies
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Rigidbodies/Gravity Chamber")]
    [RequireComponent(typeof(Collider))]
#endif
    public class GravityChamber : MonoBehaviour
    {
#if UNITY_EDITOR
    [HideInInspector]
#endif
        public List<RBGravityManager> inTriggerCol = new List<RBGravityManager>();
		[Tooltip("The amount of gravity the objects should have")]
        public Vector3 gravityAmount;
		[Tooltip("Should the player be ignored?")]
        public bool ignoreRigManager;
        public Vector3 GravityAmount
        {
            get { return gravityAmount; }
            set { gravityAmount = value; }
        }
        void OnTriggerEnter(Collider other)
        {
            if(other.GetComponentInParent<Rigidbody>() != null && other.GetComponentInParent<Rigidbody>().GetComponent<RBGravityManager>() == null) // Check if the colliding GameObject has a Rigidbody and doesn't have the RBGravityManager component
            {
                if(other.GetComponentInParent<RigManager>() != null && ignoreRigManager)
                {
                    return;
                }
                other.GetComponentInParent<Rigidbody>().gameObject.AddComponent<RBGravityManager>().gravityAmount = gravityAmount; // Add the RBGravityManager component and set the gravity amount
                Rigidbody[] childRbs = other.GetComponentInParent<Rigidbody>().GetComponentsInChildren<Rigidbody>();
                foreach(Rigidbody rb in childRbs)
                {
                    if (rb.isKinematic)
                    {
                        if (rb.GetComponent<RBGravityManager>() == null)
                        {
                            rb.gameObject.AddComponent<RBGravityManager>().gravityAmount = gravityAmount;

                        }
                    }
                }
                inTriggerCol.Add(other.GetComponentInParent<Rigidbody>().GetComponent<RBGravityManager>()); // Add the colliding GameObject to the list
            }
        }
        void OnTriggerExit(Collider other) // When the GameObject exits the trigger collider
        {
            if (inTriggerCol.Contains(other.GetComponentInParent<Rigidbody>().GetComponent<RBGravityManager>())) // Check if the colliding GameObject is in the list
            {
                other.GetComponentInParent<Rigidbody>().useGravity = true; // Enable gravity
                UnityEngine.Object.Destroy(other.GetComponentInParent<Rigidbody>().GetComponent<RBGravityManager>()); // Destroy the RBGravityManager component
                Rigidbody[] childRbs = other.GetComponentInParent<Rigidbody>().GetComponentsInChildren<Rigidbody>();
                foreach (Rigidbody rb in childRbs)
                {
                    if (rb.isKinematic)
                    {
                        if (rb.GetComponent<RBGravityManager>() != null)
                        {
                            UnityEngine.Object.Destroy(rb.GetComponent<RBGravityManager>());

                        }
                    }
                }
                inTriggerCol.Remove(other.GetComponentInParent<Rigidbody>().GetComponent<RBGravityManager>()); // Remove the colliding GameObject from the list
            }

        }
        void Update()
        {
            foreach(RBGravityManager rBGravityManager in inTriggerCol) // Loop through the list
            {
                if (rBGravityManager != null)
                {
                    rBGravityManager.gravityAmount = gravityAmount; // Get the RBGravityManager component & update the gravity amount
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
                Gizmos.color = Color.green;

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