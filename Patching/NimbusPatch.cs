using HarmonyLib;
using SLZ.Marrow.Pool;
using SLZ.Props;
using SLZ.Rig;

namespace TheLibraryElectric.Patching
{
    [HarmonyPatch(typeof(FlyingGun), "OnEnable")]
    public class NimbusPatch
    {
        public static bool nimbusToggle;
        public static void Prefix(FlyingGun __instance)
        {
            if (nimbusToggle)
            {
                __instance.GetComponent<AssetPoolee>().Despawn();
            }
        }
    }
}