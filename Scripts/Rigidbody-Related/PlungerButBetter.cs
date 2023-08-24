using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Rigidbody Related/Plunger But Better")]
#endif
    public class PlungerButBetter : MonoBehaviour
    {

        public float breakForce = 1000f; // Adjust this value as needed
        public float attachAngle = 45f;
        public Vector3 attachmentDirection = Vector3.forward; // Adjust this direction as needed
        public bool ignoreRigManager = true; // Enable or disable ignoring RigManager descendants

        private FixedJoint fixedJoint;
        private Rigidbody attachedRigidbody;

        private void OnTriggerEnter(Collider other)
        {
            // Check if the other object has colliders and is not the same object as this one
            if (other.gameObject != gameObject && other.gameObject.GetComponent<Collider>())
            {
                if (ignoreRigManager)
                {
                    // Check if the other object's parent is a descendant of "[RigManager (Blank)]"
                    Transform parent = other.transform.parent;
                    while (parent != null)
                    {
                        if (parent.name == "[RigManager (Blank)]")
                        {
                            return; // Ignore collision with this object
                        }
                        parent = parent.parent;
                    }
                }

                Vector3 collisionDirection = other.transform.position - transform.position;
                float angle = Vector3.Angle(collisionDirection, attachmentDirection);

                if (angle < attachAngle) // Adjust the angle threshold as needed
                {
                    Rigidbody otherRigidbody = other.gameObject.GetComponent<Rigidbody>();
                    if (otherRigidbody != null)
                    {
                        fixedJoint = gameObject.AddComponent<FixedJoint>();
                        fixedJoint.connectedBody = otherRigidbody;
                        fixedJoint.breakForce = breakForce;
                        attachedRigidbody = otherRigidbody;
                    }
                }
            }
        }

        private void Update()
        {
            if (fixedJoint != null && attachedRigidbody == null)
            {
                // If the attached rigidbody is null, the joint is no longer connected
                Destroy(fixedJoint);
                fixedJoint = null;
            }
        }
#if !UNITY_EDITOR
        public PlungerButBetter(IntPtr ptr) : base(ptr) { }
#endif
    }
}