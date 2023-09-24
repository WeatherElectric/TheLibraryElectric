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
            
        }
        private void Unragdoll()
        {
            
        }
    }
}