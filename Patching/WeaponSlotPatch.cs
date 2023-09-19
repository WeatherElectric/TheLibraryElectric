using UnityEngine;
using HarmonyLib;
using SLZ.Interaction;
using TheLibraryElectric.Rigidbodies;
using TheLibraryElectric.Water;

namespace TheLibraryElectric.Patching
{
    public static class WeaponSlotPatch
    {
        [HarmonyPatch(typeof(InteractableHost), "onSlotInsert")]
        public class InteractableHostPatch
        {
            [HarmonyPrefix]
            public static void Postfix(GameObject __instance)
            {
                Component buoyancyManager = __instance.GetComponentInParent<RbBuoyancyManager>();
                if (buoyancyManager != null)
                {
                    Object.Destroy(buoyancyManager);
                }
                Component gravityManager = __instance.GetComponentInParent<RBGravityManager>();
                if (gravityManager != null)
                {
                    Object.Destroy(gravityManager);
                }
            }
        }
    }
}