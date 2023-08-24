using UnityEngine;
using SLZ.VFX;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Misc/Destroy On Collision")]
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
        }

        public void Enable()
        {
        }

        private void Start()
        {
        }
        private void OnCollisionEnter(Collision collision)
        {
			return;
        }
		
        private bool IsObjectExcluded(GameObject obj)
        {
			return default(bool);
        }
    }

}