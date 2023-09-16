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
        public float divideByX = 3f;
        public float divideByY = 3f;
        public float divideByZ = 3f;
        public Vector3 minimumScale = new Vector3(1, 1, 1);
        public Vector3 maximumScale = new Vector3(200, 200, 200);
        public bool uniformScale = true;
        public float uniformScaleMinimum = 1f;
        public float uniformScaleMaximum = 200f;
        public float uniformScaleDivision = 3f;
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
            if (spawnedObjects.Contains(other.transform.root.gameObject) && ignoreSpawnedObjects)
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
            if (!uniformScale)
            {
                float clampedX = Mathf.Clamp(other.attachedRigidbody.velocity.x / divideByX, minimumScale.x, maximumScale.x);
                float clampedY = Mathf.Clamp(other.attachedRigidbody.velocity.y / divideByY, minimumScale.y, maximumScale.y);
                float clampedZ = Mathf.Clamp(other.attachedRigidbody.velocity.z / divideByZ, minimumScale.z, maximumScale.z);
                rbVelocity = new Vector3(clampedX, clampedY, clampedZ);
                spawnedObject.transform.localScale = Vector3.Scale(rbVelocity, spawnedObject.transform.lossyScale);
            }
            else
            {
                rbVelocity = new Vector3(other.attachedRigidbody.velocity.x, other.attachedRigidbody.velocity.y, other.attachedRigidbody.velocity.z);
                float uniformScale = Mathf.Clamp(rbVelocity.sqrMagnitude / uniformScaleDivision, uniformScaleMinimum, uniformScaleMinimum);
                Vector3 newScale = new Vector3(uniformScale, uniformScale, uniformScale);
            }

        }
#if !UNITY_EDITOR
        public SpawnOnTriggerEnter(IntPtr ptr) : base(ptr) { }
#endif
    }
}
