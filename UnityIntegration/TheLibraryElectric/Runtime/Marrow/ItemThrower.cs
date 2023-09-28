using System;
using UnityEngine;
using SLZ.Marrow.Data;


namespace TheLibraryElectric.Marrow
{
    [AddComponentMenu("The Library Electric/Marrow/Item Thrower")]
    public class ItemThrower : ElectricBehaviour
    {
        [Tooltip("The spawnable to throw.")]
        public Spawnable spawnable;
        [Tooltip("The force to throw the spawnable with.")]
        public Vector3 force;
        public void Throw()
        {

        }
    }
}
