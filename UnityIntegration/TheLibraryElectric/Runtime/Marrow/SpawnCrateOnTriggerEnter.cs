using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheLibraryElectric.Marrow
{
    [AddComponentMenu("The Library Electric/Marrow/Spawn Crate On Trigger Enter")]
    public class SpawnCrateOnTriggerEnter : ElectricBehaviour
    {
        [Tooltip("The barcode to spawn.")]
        public string barcodeToSpawn;
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
        private void OnTriggerEnter(Collider other)
        {
            return;
        }
    }
}
