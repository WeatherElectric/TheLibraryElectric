using System;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Misc
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Misc/Spawn On Trigger Enter")]
#endif
    public class SpawnOnTriggerEnter : MonoBehaviour
    {

        public GameObject objectToSpawn;
        public bool divideVelocity;
        public float divideByX = 0.1f;
        public float divideByY = 0.1f;
        public float divideByZ = 0.1f;
        public Vector3 minimumScale = new Vector3(1, 1, 1);
        public bool ignoreSpawnedObjects = false;
        public bool fixedRotation = true;
        public Quaternion rotation = new Quaternion(0, 0, 1, 0);
        public float minimumVelocity = 0.5f;

        private Vector3 rbVelocity;
        private List<GameObject> spawnedObjects = new List<GameObject>();
        private GameObject spawnedObject;
        void OnTriggerEnter(Collider other)
        {
            if (objectToSpawn == null)
            {
                return;
            }
            if (spawnedObjects.Contains(other.transform.root.gameObject))
            {
                return;
            }
            if (other.attachedRigidbody.velocity.sqrMagnitude < minimumVelocity)
            {
                return;
            }
            if (fixedRotation)
            {
                spawnedObject = Instantiate(objectToSpawn, other.transform.position, rotation);
            }
            else
            {
                spawnedObject = Instantiate(objectToSpawn, other.transform.position, other.transform.rotation);

            }

            float clampedX = Mathf.Clamp(other.attachedRigidbody.velocity.x / divideByX, minimumScale.x, 200f);
            float clampedY = Mathf.Clamp(other.attachedRigidbody.velocity.y / divideByY, minimumScale.y, 200f);
            float clampedZ = Mathf.Clamp(other.attachedRigidbody.velocity.z / divideByZ, minimumScale.z, 200f);
            rbVelocity = new Vector3(clampedX, clampedY, clampedZ);
            spawnedObject.transform.localScale = Vector3.Scale(rbVelocity, spawnedObject.transform.lossyScale);
        }
#if !UNITY_EDITOR
        public SpawnOnTriggerEnter(IntPtr ptr) : base(ptr) { }
#endif
    }
}
