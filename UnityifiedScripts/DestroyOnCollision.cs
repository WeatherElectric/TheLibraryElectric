using UnityEngine;
using SLZ.VFX;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric
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
        public bool activeState;
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
                    Destroy(collision.gameObject);
                }
            }
        }
        private bool IsObjectExcluded(GameObject obj)
        {
            foreach (GameObject excludedObject in excludedObjects)
            {
                if (obj == excludedObject)
                {
                    return true;
                }
            }
            return false;
        }
    }

}