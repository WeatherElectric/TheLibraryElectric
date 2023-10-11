using System;
using SLZ.Marrow.Pool;
using UnityEngine;

namespace TheLibraryElectric.Marrow
{
    public class DelayedFizzler : MonoBehaviour
    {
        public float delay = 1f;
        private AssetPoolee _assetPoolee;

        private void OnTriggerEnter(Collider other)
        {
            _assetPoolee = other.attachedRigidbody.gameObject.GetComponent<AssetPoolee>();
            Invoke(nameof(Fizzle), delay);
        }
        
        private void Fizzle()
        {
            _assetPoolee.GetComponent<AssetPoolee>().Despawn();
            _assetPoolee = null;
        }
#if !UNITY_EDITOR
        public DelayedFizzler(IntPtr ptr) : base(ptr) { }
#endif
    }
}