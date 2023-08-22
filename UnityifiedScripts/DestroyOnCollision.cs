using UnityEngine;
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
        private Transform excludedObject;
        private void Start()
        {
            excludedObject = GameObject.Find("[RigManager (Blank)]")?.transform;
        }
        private void OnCollisionEnter(Collision collision)
        {
            // Check if the colliding GameObject is not a child of the excluded object
            if (!collision.transform.IsChildOf(excludedObject) && collision.gameObject.layer != 13)
            {
                // Destroy the colliding GameObject
                Destroy(collision.gameObject);
            }
        }
    }
}