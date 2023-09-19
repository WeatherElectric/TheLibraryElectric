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
        public float timeUntilDrowning = 20f;
        public float damageInterval = 1f;
        public float damagePercentage = 0.10f;
        private RigManager _rigManager;
        private bool _isDrowning = false;
        private float _timeInsideWater = 0.0f;
        private float _methodCallTimer = 0.0f;

        private void OnTriggerEnter(Collider other)
        {
            _rigManager = other.GetComponentInParent<RigManager>();
            if (_rigManager != null)
            {
                var preventCheck = _rigManager.GetComponentInChildren<PreventFromDrowning>();
                if (preventCheck.preventDrowning == false)
                {
                    _isDrowning = true;
                }
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
#if !UNITY_EDITOR
        public DrowningManager(IntPtr ptr) : base(ptr) { }
#endif
    }
}