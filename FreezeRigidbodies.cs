using UnityEngine;
using MelonLoader;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric
{
    [RegisterTypeInIl2Cpp]
    #if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Freeze Rigidbodies")]
    #endif
    public class FreezeRigidbodies : MonoBehaviour
    {
        private GameObject rigManager;
        private void Start()
        {
            GameObject rm = GameObject.Find("[RigManager (Blank)]");
            rigManager = rm;
            Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();

            foreach (Rigidbody rb in allRigidbodies)
            {
                // Check if the GameObject has the KinematicRB component
                if (rb.gameObject.TryGetComponent(out KinematicRB _))
                {
                    continue; // Skip this if it already somehow has KinematicRB
                }

                if (!rb.transform.IsChildOf(rigManager.transform) && rb.gameObject != gameObject)
                {
                    rb.gameObject.AddComponent<KinematicRB>();
                }
            }
        }
        public void Freeze()
        {
            if (rigManager != null)
            {
                Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();

                foreach (Rigidbody rb in allRigidbodies)
                {
                    // Check if the GameObject has the KinematicRB component
                    if (rb.gameObject.TryGetComponent(out KinematicRB _))
                    {
                        continue; // Skip freezing if the KinematicRB component is present
                    }

                    // Check if the GameObject has the DoNotFreeze component
                    if (rb.gameObject.TryGetComponent(out DoNotFreeze _))
                    {
                        continue; // Skip freezing if the DoNotFreeze component is present
                    }

                    if (!rb.transform.IsChildOf(rigManager.transform) && rb.gameObject != gameObject)
                    {
                        rb.isKinematic = true;
                    }
                }
            }
        }
        public void Unfreeze()
        {
            if (rigManager != null)
            {
                Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();

                foreach (Rigidbody rb in allRigidbodies)
                {
                    // Check if the GameObject has the KinematicRB component
                    if (rb.gameObject.TryGetComponent(out KinematicRB _))
                    {
                        continue; // Skip freezing if the KinematicRB component is present
                    }

                    // Check if the GameObject has the DoNotFreeze component
                    if (rb.gameObject.TryGetComponent(out DoNotFreeze _))
                    {
                        continue; // Skip freezing if the DoNotFreeze component is present
                    }

                    if (!rb.transform.IsChildOf(rigManager.transform) && rb.gameObject != gameObject)
                    {
                        rb.isKinematic = false;
                    }
                }
            }
        }
        
        private void OnDestroy()
        {
            Unfreeze();
        }
    }
}