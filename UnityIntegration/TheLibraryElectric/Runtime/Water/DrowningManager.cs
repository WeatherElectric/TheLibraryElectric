using System;
using UnityEngine;
using SLZ.Rig;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Water
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Water/Drowning Manager")]
    [RequireComponent(typeof(Collider))]
#endif
    public class DrowningManager : MonoBehaviour
    {
		[Tooltip("How long it takes to start taking damage")]
        public float timeUntilDrowning = 30f;
		[Tooltip("Time in seconds between each damage tick")]
        public float damageInterval = 1f;
		[Tooltip("Percentage of the player's max health that's taken by the damage tick")]
        public float damagePercentage = 0.10f;
        private RigManager _rigManager;
		private Transform _head;
        private bool _isDrowning = false;
        private float _timeInsideWater = 0.0f;
        private float _methodCallTimer = 0.0f;

        private void OnTriggerEnter(Collider other)
        {
            _rigManager = other.GetComponentInParent<RigManager>();
            if (_rigManager != null)
            {
				_head = _rigManager.openControllerRig.m_head;
                _isDrowning = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            _isDrowning = false;
            _timeInsideWater = 0.0f;
        }
        private void FixedUpdate()
        {
            if (_isDrowning)
            {
                _timeInsideWater += Time.deltaTime;
                if (_timeInsideWater >= timeUntilDrowning)
                {
                    _methodCallTimer += Time.deltaTime;

                    if (_methodCallTimer >= damageInterval)
                    {
                        Drown();
                        _methodCallTimer = 0.0f;
                    }
                }
            }
        }
        private void Drown()
        {
            float damageTaken = _rigManager.health.max_Health * damagePercentage;
            _rigManager.health.TAKEDAMAGE(damageTaken);
        }
    }
}