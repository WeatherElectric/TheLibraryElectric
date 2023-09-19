using UnityEngine;
using HarmonyLib;
using SLZ.Props.Weapons;
using TheLibraryElectric.Rigidbodies;
using TheLibraryElectric.Water;

namespace TheLibraryElectric.Patching
{
    public static class WeaponSlotPatch
    {
        [HarmonyPatch(typeof(WeaponSlot), "onSlotInsert")]
        public class SlotPatch
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