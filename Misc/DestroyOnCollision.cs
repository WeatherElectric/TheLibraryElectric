using UnityEngine;
using System;
using SLZ.VFX;
using TheLibraryElectric.Markers;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Misc
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Destroy On Collision")]
#endif
    public class DestroyOnCollision : MonoBehaviour
    {
#if UNITY_EDITOR
[Header("Is Allowed To Destroy?")]
[SerializeField]
#endif
        bool activeState;
#if UNITY_EDITOR
[Header("Destroy Sound Audio Src")]
[SerializeField]
#endif
        public AudioSource audioSource;
        public GameObject[] excludedObjects;
        private Transform rigManager;
        private Blip blip;
        public void Disable()
        {
            activeState = false;
        }

        public void Enable()
        {
            activeState = true;
        }

        private void Start()
        {
            rigManager = GameObject.Find("[RigManager (Blank)]")?.transform;
            ModConsole.Msg($"Rigmanager is {rigManager.gameObject.name}", LoggingMode.DEBUG);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (activeState == true)
            {
                // Check if the colliding GameObject is not a child of the excluded object
                if (!collision.transform.IsChildOf(rigManager) && collision.gameObject.layer != 13 && !IsObjectExcluded(collision.gameObject) && !collision.gameObject.GetComponent<DoNotDestroy>())
                {
                    Rigidbody rb = collision.transform.GetComponentInParent<Rigidbody>();
                    if (rb != null)
                    {
                        blip = rb.transform.GetComponent<Blip>();
                    }
                    if (blip != null)
                    {
                        blip.CallSpawnEffect();
                    }
                    audioSource.Play();
                    // Destroy the colliding GameObject
                    ModConsole.Msg($"Destroying {collision.gameObject.name}", LoggingMode.DEBUG);
                    Destroy(collision.gameObject);
                }
            }
        }
#if !UNITY_EDITOR
        public DestroyOnCollision(IntPtr ptr) : base(ptr) { }
#endif
        private bool IsObjectExcluded(GameObject obj)
        {
            foreach (GameObject excludedObject in excludedObjects)
            {
                if (obj == excludedObject)
                {
                    ModConsole.Msg($"Ignoring {excludedObject}", LoggingMode.DEBUG);
                    return true;
                }
            }
            return false;
        }
    }

}