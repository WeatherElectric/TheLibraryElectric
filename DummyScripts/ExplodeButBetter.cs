using System.Collections.Generic;
using UnityEngine;
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
    }
}
