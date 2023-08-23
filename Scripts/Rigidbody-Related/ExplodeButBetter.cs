using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric
{
#if UNITY_EDITOR
[AddComponentMenu("The Library Electric/Explode But Better")]
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
            if (!active) { return; } // If not active, don't do anything
            if (useColliders)
            {
                ExplodeColliders();
            }
            else
            {
                Explode();
            }
        }
        public void ExplodeColliders()
        {
            foreach (GameObject go in gameObjects)
            {
                if (transform.root.gameObject == go.transform.root.gameObject) { continue; }
                Rigidbody rb = go.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce((go.transform.position - transform.position).normalized * explosionForce);
                }
            }
        }
        public void Explode()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider col in colliders)
            {
                if (transform.root.gameObject == col.transform.root.gameObject) { continue; }
                Rigidbody rb = col.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce((col.transform.position - transform.position).normalized * explosionForce);
                }
            }
        }
        void OnTriggerEnter(Collider other)
        {
            gameObjects.Add(other.gameObject); //When an object enters the trigger, add it to the list
        }
        void OnTriggerExit(Collider other)
        {
            gameObjects.Remove(other.gameObject); //When an object leaves the trigger, remove it from the list
        }
#if UNITY_EDITOR
		private void OnDrawGizmos()
        {
			if (useColliders)
				return;
			Gizmos.color = Color.blue;
			Gizmos.DrawWireSphere(transform.position, explosionRadius);
		}

		private void OnDrawGizmosSelected()
		{
			if (useColliders)
				return;
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, explosionRadius);
		}
#endif
#if !UNITY_EDITOR
        public ExplodeButBetter(IntPtr ptr) : base(ptr) { }
#endif
    }
}
