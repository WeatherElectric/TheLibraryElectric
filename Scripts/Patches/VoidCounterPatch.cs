using MelonLoader;
using HarmonyLib;
using UnityEngine;
using SLZ.Marrow.Pool;
using SLZ.Bonelab;
using TheLibraryElectric.Scripts.Misc;

namespace TheLibraryElectric
{
    public static class VoidCounterPatch
    {

        [HarmonyPatch(typeof(RigidbodyProjectile), "OnCollisionEnter")]
        public class VoidCounterPatch_Patch
        {
            // Prefix method runs before the original method (OnFire) is executed
            [HarmonyPrefix]
            public static bool Prefix(AssetPoolee __instance, Collision c)
            {
                if (c.gameObject.transform.root.GetComponent<VoidCounterObject>() != null) // Check if the colliding GameObject has the VoidCounterObject component
                {
                    PhysicMaterial dynamicMaterial = new PhysicMaterial
                    {
                        bounciness = 1f,  
                        dynamicFriction = 0.2f,
                        staticFriction = 0.5f
                    };
                    Collider[] colliders = __instance.GetComponentsInChildren<Collider>();
                    foreach (Collider collider in colliders)
                    {
                        collider.material = dynamicMaterial;
                    }
                    if (__instance.gameObject.GetComponent<Rigidbody>() == null)
                    {
                        __instance.gameObject.GetComponent<Rigidbody>().mass = 0.1f; // Set mass to 0.1f so it's easier to hit
                    }
                   
                    return false; // Prevent the ball from exploding by not running the original method
                }
                return true; // Run the original method, so it explodes
            }
        }
    }
}