using HarmonyLib;
using SLZ.Rig;

namespace TheLibraryElectric.Patching
{
    [HarmonyPatch(typeof(PhysicsRig), "CheckDangle")]
    public class VaultingPatch
    {
        public static bool vaultingToggle;
        public static bool Prefix(PhysicsRig __instance, ref bool __result)
        {
            if (vaultingToggle)
            {
                __result = false;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}