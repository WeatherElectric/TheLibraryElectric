using System;
using SLZ.Rig;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.PlayerUtil
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Player Utilities/Ragdoll On Collision")]
    [RequireComponent(typeof(Collider))]
#endif
    public class RagdollOnCollide : MonoBehaviour
    {
        public float delayBeforeUnragdoll = 2f;
        private RigManager _rigManager;
        
        private void OnCollisionEnter()
        {
            var col = GetComponent<Collider>();
            _rigManager = col.GetComponentInParent<RigManager>();
            if (_rigManager != null)
            {
                _rigManager.physicsRig.RagdollRig();
                Invoke(nameof(Unragdoll), delayBeforeUnragdoll);
            }
        }
        private void Unragdoll()
        {
            _rigManager.physicsRig.UnRagdollRig();
        }
#if !UNITY_EDITOR
        public RagdollOnCollide(IntPtr ptr) : base(ptr) { }
#endif
    }
}