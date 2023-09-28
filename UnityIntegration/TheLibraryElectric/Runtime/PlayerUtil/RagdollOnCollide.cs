using System;
using SLZ.Rig;
using UnityEngine;

namespace TheLibraryElectric.PlayerUtil
{
    [AddComponentMenu("The Library Electric/Player Util/Ragdoll On Collide")]
    public class RagdollOnCollide : ElectricBehaviour
    {
        [Tooltip("The amount of time to wait before unragdolling the player.")]
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