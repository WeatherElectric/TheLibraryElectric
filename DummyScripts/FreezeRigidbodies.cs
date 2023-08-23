using UnityEngine;
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
        private void Start()
        {
        }
        public void Freeze()
        {
        }
        public void Unfreeze()
        {
        }

        private void OnDestroy()
        {
        }
    }
}