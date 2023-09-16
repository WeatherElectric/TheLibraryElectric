using UnityEngine;
using SLZ.Marrow.Data;


namespace TheLibraryElectric.Misc
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Misc/Item Thrower")]
#endif
    public class ItemThrower : MonoBehaviour
    {
        public Spawnable spawnable;
        public Vector3 force;
        void Throw()
        {

        }
    }
}
