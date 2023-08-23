using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Freeze Rigidbodies")]
#endif
    public class FreezeRigidbodies : MonoBehaviour
    {
        private GameObject rigManager;
        private List<Rigidbody> kinematicRbs = new List<Rigidbody>();
        private List<Rigidbody> frozenRbs = new List<Rigidbody>();
        private void Start()
        {
            GameObject rm = GameObject.Find("[RigManager (Blank)]");
            rigManager = rm;
            Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();
            UpdateKinematicObjects(); // Update the list of kinematic rigidbodies
        }
        public void UpdateKinematicObjects()
        {
            Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();
            foreach(Rigidbody rb in allRigidbodies)
            {
                if(!rb.transform.IsChildOf(rigManager.transform) && rb.isKinematic && !kinematicRbs.Contains(rb)) //If the rb is kinematic and not in the list, add it
                {
                    kinematicRbs.Add(rb);
                }
                else if (!rb.isKinematic && kinematicRbs.Contains(rb)) //If the rb is not kinematic and in the list, remove it
                {
                    kinematicRbs.Remove(rb);
                }
            }
        }
        public void Freeze()
        {
            if (rigManager != null)
            {
                UpdateKinematicObjects();
                Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();
                foreach (Rigidbody rb in allRigidbodies)
                {
                    // Check if the RB is in the list of kinematic rigidbodies
                    if (kinematicRbs.Contains(rb))
                    {
                        continue; // Skip freezing if the RB is in the list of kinematic rigidbodies
                    }
                    // Check if the GameObject has the DoNotFreeze component
                    if (rb.gameObject.GetComponent<DoNotFreeze>() != null)
                    {
                        continue; // Skip freezing if the DoNotFreeze component is present
                    }
                    if(frozenRbs.Contains(rb))
                    {
                        continue;
                    }
                    else
                    {
                        frozenRbs.Add(rb);
                    }

                    if (!rb.transform.IsChildOf(rigManager.transform))
                    {
                        rb.isKinematic = true; // Freeze the rigidbody
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
                    // Check if the GameObject has the DoNotFreeze component
                    if (rb.gameObject.GetComponent<DoNotFreeze>() != null)
                    {
                        continue; // Skip freezing if the DoNotFreeze component is present
                    }
                    if (!rb.transform.IsChildOf(rigManager.transform) && !kinematicRbs.Contains(rb))
                    {
                        rb.isKinematic = false; // Unfreeze the rigidbody
                    }
                }
                frozenRbs = new List<Rigidbody>();
            }
        }

        private void OnDestroy()
        {
            //KinematicRB[] kinematicRBs = FindObjectsOfType<KinematicRB>();
            //foreach (KinematicRB kinematicRB in kinematicRBs)
            //{
            //    Destroy(kinematicRB.gameObject);
            //}
            Unfreeze();
        }
#if !UNITY_EDITOR
        public FreezeRigidbodies(IntPtr ptr) : base(ptr) { }
#endif
    }
}