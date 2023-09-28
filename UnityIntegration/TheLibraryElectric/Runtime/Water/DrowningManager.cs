using System;
using SLZ.Bonelab;
using UnityEngine;
using SLZ.Rig;

namespace TheLibraryElectric.Water
{
    [AddComponentMenu("The Library Electric/Water/Drowning Manager")]
    public class DrowningManager : ElectricBehaviour
    {
        [Tooltip("The amount of time the player can be in the water before they start drowning.")]
        public float timeUntilDrowning = 20f;
        [Tooltip("The amount of time between each damage tick.")]
        public float damageInterval = 1f;
        [Tooltip("The percentage of health the player loses per damage tick.")]
        public float damagePercentage = 0.10f;
        private RigManager _rigManager;
        private bool _isDrowning = false;
        private float _timeInsideWater = 0.0f;
        private float _methodCallTimer = 0.0f;

        private void OnTriggerEnter(Collider other)
        {
            return;
        }
        private void OnTriggerExit(Collider other)
        {
            return;
        }
        // The car told me to do this and the car is right
        private void FixedUpdate()
        {
            
        }
        private void CheckTimeInWater()
        {
            
        }
        private void RepeatDrownMethod()
        {
            
        }
        private void Drown()
        {
            
        }
    }
}