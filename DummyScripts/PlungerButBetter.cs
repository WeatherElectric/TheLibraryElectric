using UnityEngine;
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
			return;
        }

        private void Update()
        {
        }
    }
}