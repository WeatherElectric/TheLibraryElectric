using System;
using UnityEngine;
using SLZ.Rig;

namespace TheLibraryElectric.Water
{
    [AddComponentMenu("The Library Electric/Water/Swimming Controller")]
    public class SwimmingController : ElectricBehaviour
    {
        [HideInInspector]
        public RigManager rigManager;
        [Tooltip("The minimum velocity required to swim.")]
        public float minimumVelocity = 10f;
        [Tooltip("The multiplier for the velocity.")]
        public float velocityMultiplier = 100f;

        private void OnTriggerEnter(Collider other)
        {
            return;
        }

        private void OnTriggerExit(Collider other)
        {
            return;
        }
    }
}