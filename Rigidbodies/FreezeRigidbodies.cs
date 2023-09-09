using UnityEngine;
using System;
using TheLibraryElectric.Markers;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Rigidbodies
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Rigidbody Related/Freeze Rigidbodies")]
#endif
    public class FreezeRigidbodies : MonoBehaviour
    {
        private GameObject rigManager;
        private void Start()
        {
            GameObject rm = GameObject.Find("[RigManager (Blank)]");
            ModConsole.Msg("Got rigmanager", LoggingMode.DEBUG);
            rigManager = rm;
            Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();
            ModConsole.Msg("Got rigidbodies", LoggingMode.DEBUG);
            foreach (Rigidbody rb in allRigidbodies)
            {
                ModConsole.Msg("Giving existing kinematic RBs DoNotFreeze", LoggingMode.DEBUG);
                // Check if the GameObject has the DoNotFreeze component
                if (rb.gameObject.GetComponent<DoNotFreeze>() != null)
                {
                    continue; // Skip this if it already DoNotFreeze
                }
                if (!rb.transform.IsChildOf(rigManager.transform) && rb.isKinematic)
                {
                    rb.gameObject.AddComponent<DoNotFreeze>();
                }
            }
        }
        public void Freeze()
        {
            if (rigManager != null)
            {
                ModConsole.Msg("Getting rigidbodies", LoggingMode.DEBUG);
                Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();
                foreach (Rigidbody rb in allRigidbodies)
                {
                    // Check if the GameObject has the DoNotFreeze component
                    if (rb.gameObject.GetComponent<DoNotFreeze>() != null)
                    {
                        ModConsole.Msg($"{rb.gameObject.name} has DoNotFreeze, skipping", LoggingMode.DEBUG);
                        continue; // Skip freezing if the DoNotFreeze component is present
                    }
                    if (!rb.transform.IsChildOf(rigManager.transform))
                    {
                        ModConsole.Msg("Froze all RBs", LoggingMode.DEBUG);
                        rb.isKinematic = true;
                    }
                }
            }
            else
            {
                ModConsole.Msg("Somehow, the rigmanager is null!", LoggingMode.NORMAL);
            }
        }
        public void Unfreeze()
        {
            if (rigManager != null)
            {
                ModConsole.Msg("Getting all RBs", LoggingMode.DEBUG);
                Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();
                foreach (Rigidbody rb in allRigidbodies)
                {
                    // Check if the GameObject has the DoNotFreeze component
                    if (rb.gameObject.GetComponent<DoNotFreeze>() != null)
                    {
                        continue; // Skip freezing if the DoNotFreeze component is present
                    }
                    if (!rb.transform.IsChildOf(rigManager.transform))
                    {
                        rb.isKinematic = false;
                    }
                }
            }
            else
            {
                ModConsole.Msg("Somehow, the rigmanager is null!", LoggingMode.DEBUG);
            }
        }

        private void OnDestroy()
        {
            Unfreeze();
        }
#if !UNITY_EDITOR
        public FreezeRigidbodies(IntPtr ptr) : base(ptr) { }
#endif
    }
}