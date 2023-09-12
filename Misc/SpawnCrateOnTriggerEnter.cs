using System;
using System.Collections.Generic;
using BoneLib.Nullables;
using SLZ.Marrow.Data;
using SLZ.Marrow.Pool;
using SLZ.Marrow.Warehouse;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Misc
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Misc/Spawn Crate On Trigger Enter")]
#endif
    public class SpawnCrateOnTriggerEnter : MonoBehaviour
    {

        public SpawnableCrateReference objectToSpawn;
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
                Spawnable spawnable = new Spawnable()
                {
                    crateRef = objectToSpawn
                };
                AssetSpawner.Register(spawnable);
                Action<GameObject> spawnAction = go =>
                {
                    go.transform.rotation = rotation;
                    spawnedObject = go;
                };
                AssetSpawner.Spawn(spawnable, other.transform.position, Quaternion.identity, new BoxedNullable<Vector3>(null), false, new BoxedNullable<int>(null), spawnAction);
            }
            else
            {
                Spawnable spawnable = new Spawnable()
                {
                    crateRef = objectToSpawn
                };
                AssetSpawner.Register(spawnable);
                Action<GameObject> spawnAction = go =>
                {
                    go.transform.rotation = other.transform.rotation;
                    spawnedObject = go;
                };
                AssetSpawner.Spawn(spawnable, other.transform.position, Quaternion.identity, new BoxedNullable<Vector3>(null), false, new BoxedNullable<int>(null), spawnAction);
            }

            float clampedX = Mathf.Clamp(other.attachedRigidbody.velocity.x / divideByX, minimumScale.x, 200f);
            float clampedY = Mathf.Clamp(other.attachedRigidbody.velocity.y / divideByY, minimumScale.y, 200f);
            float clampedZ = Mathf.Clamp(other.attachedRigidbody.velocity.z / divideByZ, minimumScale.z, 200f);
            rbVelocity = new Vector3(clampedX, clampedY, clampedZ);
            spawnedObject.transform.localScale = Vector3.Scale(rbVelocity, spawnedObject.transform.lossyScale);
        }
#if !UNITY_EDITOR
        public SpawnCrateOnTriggerEnter(IntPtr ptr) : base(ptr) { }
#endif
    }
}
