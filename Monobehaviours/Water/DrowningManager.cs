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
        public float timeUntilDrowning = 30f;
        public float damageInterval = 5f;
        public float damageTaken = 10f;
        private RigManager _rigManager;
        private Player_Health _playerHealth;
        private bool _isDrowning = true;
        private float _timeInsideWater = 0.0f;
        private float _methodCallTimer = 0.0f;

        private void OnTriggerEnter(Collider other)
        {
            _rigManager = other.GetComponent<RigManager>();
            if (_rigManager != null)
            {
                _playerHealth = _rigManager.GetComponent<Player_Health>();
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
            _playerHealth.TAKEDAMAGE(damageTaken);
        }
#if !UNITY_EDITOR
        public DrowningManager(IntPtr ptr) : base(ptr) { }
#endif
    }
}