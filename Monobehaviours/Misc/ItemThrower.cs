using System;
using UnityEngine;
using TheLibraryElectric.InternalHelpers;
using SLZ.Marrow.Data;


namespace TheLibraryElectric.Misc
{
    public class ItemThrower : MonoBehaviour
    {
        public Spawnable spawnable;
        public Vector3 force;
        public void Throw()
        {
            SpawnCrateWithSpawnable.Spawn(spawnable, transform.position, transform.rotation, false, go =>
            {
                go.GetComponent<Rigidbody>().AddRelativeForce(force);
            });
        }
#if !UNITY_EDITOR
        public ItemThrower(IntPtr ptr) : base(ptr) { }
#endif
    }
}
