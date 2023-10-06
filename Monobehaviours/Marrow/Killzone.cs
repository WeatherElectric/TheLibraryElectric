using System;
using System.Collections.Generic;
using PuppetMasta;
using SLZ.AI;
using SLZ.Combat;
using UnityEngine;
using SLZ.Rig;

namespace TheLibraryElectric.Marrow
{
    public class Killzone : MonoBehaviour
    {
        public bool ignorePlayer;
        public bool ignoreNpcs;
        public float damageTickRate = 1f;
        public float playerDamageAmount = 1f;
        public int npcDamageAmount = 1;
        private List<RigManager> _playerinZone = new List<RigManager>();
        private List<AIBrain> _npcinZone = new List<AIBrain>();

        private void OnCollisionEnter(Collision other)
        {
            var rm = other.gameObject.GetComponentInParent<RigManager>();
            if (rm != null && !ignorePlayer)
            {
                _playerinZone.Add(rm);
            }
            var npc = other.gameObject.GetComponentInParent<AIBrain>();
            if (npc != null && !ignoreNpcs)
            {
                _npcinZone.Add(npc);
            }
        }

        private void OnCollisionStay(Collision other)
        {
            var rm = other.gameObject.GetComponentInParent<RigManager>();
            if (rm != null && !ignorePlayer && !_playerinZone.Contains(rm))
            {
                _playerinZone.Add(rm);
            }
            var npc = other.gameObject.GetComponentInParent<AIBrain>();
            if (npc != null && !ignoreNpcs && !_npcinZone.Contains(npc))
            {
                _npcinZone.Add(npc);
            }
        }

        private void OnCollisionExit(Collision other)
        {
            var rm = other.gameObject.GetComponentInParent<RigManager>();
            if (rm != null && !ignorePlayer)
            {
                _playerinZone.Remove(rm);
            }
            var npc = other.gameObject.GetComponentInParent<AIBrain>();
            if (npc != null && !ignoreNpcs)
            {
                _npcinZone.Remove(npc);
            }
        }

        private void OnEnable()
        {
            InvokeRepeating(nameof(DamageTick), 0.0f, damageTickRate);
        }

        private void OnDisable()
        {
            CancelInvoke(nameof(DamageTick));
            _playerinZone.Clear();
            _npcinZone.Clear();
        }
        
        private void DamageTick()
        {
            foreach (var player in _playerinZone)
            {
                if (player == null)
                {
                    return;
                }
                player.health.TAKEDAMAGE(playerDamageAmount);
            }
            foreach (var npc in _npcinZone)
            {
                if (npc == null)
                {
                    return;
                }
                npc.behaviour.health.TakeDamage(npcDamageAmount, new Attack());
            }
        }
#if !UNITY_EDITOR
        public Killzone(IntPtr ptr) : base(ptr) { }
#endif
    }
}