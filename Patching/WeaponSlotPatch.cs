using UnityEngine;
using HarmonyLib;
using SLZ.Interaction;
using TheLibraryElectric.Rigidbodies;
using TheLibraryElectric.Water;

namespace TheLibraryElectric.Patching
{
    public static class WeaponSlotPatch
    {
        [HarmonyPatch(typeof(InteractableHost), "InsertInSlot")]
        public class InteractableHostPatch
        {
            [HarmonyPrefix]
            public static void Postfix(GameObject __instance)
            {
                Component buoyancyManager = __instance.GetComponent<RbBuoyancyManager>();
                if (buoyancyManager != null)
                {
                    Object.Destroy(buoyancyManager);
                }
                Component gravityManager = __instance.GetComponent<RBGravityManager>();
                if (gravityManager != null)
                {
                    Object.Destroy(gravityManager);
                }
            }
        }
    }
}