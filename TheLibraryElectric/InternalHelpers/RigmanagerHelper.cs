using BoneLib;
using Il2CppSLZ.Rig;
using UnityEngine;

namespace TheLibraryElectric.Helpers
{
    public static class RigManagerHelper
    {
        public static RigManager GetFromCollider(Collider collider)
        {
            return collider.GetComponentInParent<RigManager>();
        }
        public static void RagDoll(RigManager rig)
        {
            rig.physicsRig.RagdollRig();
        }
        public static void UnRagDoll(RigManager rig)
        {
            rig.physicsRig.UnRagdollRig();
        }
        public static void Teleport(RigManager rig, Vector3 feetPos)
        {
            rig.Teleport(feetPos);
        }
        public static void Teleport(RigManager rig, Vector3 feetPos, bool zerovelocity)
        {
            rig.Teleport(feetPos, zerovelocity);
        }
        public static void SetDoubleJump(RigManager rig, bool canDoubleJump)
        {
            rig.remapHeptaRig.doubleJump = canDoubleJump;
        }
        public static RigManager GetFromBonelib()
        {
            return Player.rigManager;
        }
    }
}