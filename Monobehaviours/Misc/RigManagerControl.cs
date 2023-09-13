using System;
using UnityEngine;
using BoneLib;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Misc
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Misc/Rigmanager Control")]
#endif
    public class RigManagerControl : MonoBehaviour
    {
        public void RagDoll()
        {
            Player.physicsRig.RagdollRig();
        }
        public void UnRagDoll()
        {
            Player.physicsRig.UnRagdollRig();
        }
        public void Teleport(Vector3 feetPos)
        {
            Player.rigManager.Teleport(feetPos);
        }
        public void Teleport(Vector3 feetPos, bool zerovelocity)
        {
            Player.rigManager.Teleport(feetPos, zerovelocity);
        }
        public void Invincible()
        {
            Player.rigManager.health.healthMode = Health.HealthMode.Invincible;
        }
        public void Mortal()
        {
            Player.rigManager.health.healthMode = Health.HealthMode.Mortal;
        }
        public void InstantDeath()
        {
            Player.rigManager.health.healthMode = Health.HealthMode.InsantDeath;
        }
#if !UNITY_EDITOR
        public RigManagerControl(IntPtr ptr) : base(ptr) { }
#endif
    }
}