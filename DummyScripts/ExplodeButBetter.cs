using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Rigidbodies
{
#if UNITY_EDITOR
[AddComponentMenu("The Library Electric/Rigidbody Related/Explode But Better")]
#endif
    public class ExplodeButBetter : MonoBehaviour
    {
        public bool useColliders;
        public float explosionRadius = 5f;
        public float explosionForce = 1000f;
        public bool active = false;
        private List<GameObject> gameObjects = new List<GameObject>();

        void Update()
        {
        }
        public void ExplodeColliders()
        {
        }
        public void Explode()
        {
        }
        void OnTriggerEnter(Collider other)
        {
            return;
        }
        void OnTriggerExit(Collider other)
        {
            return;
        }
#if UNITY_EDITOR
		private void OnDrawGizmosSelected()
		{
			if (useColliders)
				return;
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, explosionRadius);
		}
#endif
    }
}
