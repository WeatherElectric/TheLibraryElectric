using System.Collections.Generic;
using PuppetMasta;
using SLZ.Combat;
using UnityEngine;
using SLZ.Rig;
using UnityEditor;

namespace TheLibraryElectric.Marrow
{
    [AddComponentMenu("The Library Electric/Marrow/Killzone")]
    [RequireComponent(typeof(Collider))]
    public class Killzone : ElectricBehaviour
    {
		public override string Comment => "This is safe to disable! It clears the list, so if it gets disabled and the player's still inside, it won't keep damaging them even if they're outside it!";
        [Header("Ignore Settings")]
        [Tooltip("Should this killzone ignore players?")]
        public bool ignorePlayer;
        [Tooltip("Should this killzone ignore NPCs?")]
        public bool ignoreNpcs;
        [Header("Damage Settings")]
        [Tooltip("How often should this killzone deal damage?")]
        public float damageTickRate = 1f;
        [Tooltip("How much damage should this killzone deal to players?")]
        public float playerDamageAmount = 1f;
        [Tooltip("How much damage should this killzone deal to NPCs?")]
        public int npcDamageAmount = 1;
        private List<RigManager> _playerinZone = new List<RigManager>();
        private List<BehaviourPowerLegs> _npcinZone = new List<BehaviourPowerLegs>();

        private void OnCollisionEnter(Collision other)
        {
            var rm = other.gameObject.GetComponentInParent<RigManager>();
            if (rm != null && !ignorePlayer)
            {
                _playerinZone.Add(rm);
            }
            var npc = other.gameObject.GetComponentInParent<BehaviourPowerLegs>();
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
            var npc = other.gameObject.GetComponentInParent<BehaviourPowerLegs>();
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
            var npc = other.gameObject.GetComponentInParent<BehaviourPowerLegs>();
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
                player.health.TAKEDAMAGE(playerDamageAmount);
            }
            foreach (var npc in _npcinZone)
            {
                npc.health.TakeDamage(npcDamageAmount, new Attack());
            }
        }
        #if UNITY_EDITOR
		private void OnDrawGizmos()
        {
			if (Selection.activeGameObject == gameObject)
				return;
            Collider collider = GetComponent<Collider>();

            if (collider != null && (collider is CapsuleCollider || collider is BoxCollider || collider is SphereCollider))
            {
                Gizmos.color = Color.red;

                // Draw gizmo based on collider type
                if (collider is CapsuleCollider)
                {
                    DrawCapsuleGizmo((CapsuleCollider)collider);
                }
                else if (collider is BoxCollider)
                {
                    DrawBoxGizmo((BoxCollider)collider);
                }
                else if (collider is SphereCollider)
                {
                    DrawSphereGizmo((SphereCollider)collider);
                }
            }
        }
        private void DrawCapsuleGizmo(CapsuleCollider capsuleCollider)
        {
            Vector3 position = transform.position + capsuleCollider.center;
			float height = capsuleCollider.height * transform.lossyScale.y;
			float radius = capsuleCollider.radius * Mathf.Max(transform.lossyScale.x, transform.lossyScale.z);
			Vector3 boxSize = new Vector3(radius * 2, height - 2 * radius, radius * 2);
			Gizmos.DrawWireSphere(position + Vector3.up * (height / 2 - radius), radius);
			Gizmos.DrawWireSphere(position - Vector3.up * (height / 2 - radius), radius);
			Gizmos.DrawWireCube(position, boxSize);
        }

        private void DrawBoxGizmo(BoxCollider boxCollider)
        {
            Vector3 position = transform.position + boxCollider.center;
            Vector3 size = Vector3.Scale(boxCollider.size, transform.lossyScale);
            Gizmos.DrawWireCube(position, size);
        }

        private void DrawSphereGizmo(SphereCollider sphereCollider)
        {
            Vector3 position = transform.position + sphereCollider.center;
            float radius = sphereCollider.radius * Mathf.Max(transform.lossyScale.x, transform.lossyScale.y, transform.lossyScale.z);
            Gizmos.DrawWireSphere(position, radius);
        }
        #endif
    }
}