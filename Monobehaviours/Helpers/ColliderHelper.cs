using UnityEngine;

namespace TheLibraryElectric.Helpers
{
    public static class ColliderHelper
    {
        public static void SetTrigger(Collider collider, bool b)
        {
            collider.isTrigger = b;
        }
        public static bool GetTrigger(Collider collider)
        {
            return collider.isTrigger;
        }
        public static Rigidbody GetRigidbody(Collider collider)
        {
            return collider.attachedRigidbody;
        }
        public static GameObject GetGameObject(Collider collider)
        {
            return collider.gameObject;
        }
    }
}