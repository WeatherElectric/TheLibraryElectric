using SLZ.Marrow.Pool;
using UnityEngine;
using System;

namespace TheLibraryElectric.Marrow
{
    [AddComponentMenu("The Library Electric/Marrow/Despawn Pooled Object")]
    public class DespawnPooledObject : ElectricBehaviour
    {
        public override string Comment => "Put this on the root object!";
        private GameObject _self;
        private AssetPoolee _assetPoolee;
        private void Start()
        {
        }

        public void Despawn()
        {
        }
    }
}