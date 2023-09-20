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
        public float damagePercentage = 0.10f;
        public bool enableSoundQueue = false;
#if UNITY_EDITOR
        [Tooltip("The sound that plays when the player is halfway to drowning.")]
#endif
        public AudioSource halfWarningSound;
#if UNITY_EDITOR
        [Tooltip("The sound that plays when the player is a quarter of the way to drowning.")]
#endif
        public AudioSource quarterWarningSound;
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
				if (enableSoundQueue && _timeInsideWater >= timeUntilDrowning / 2)
                {
					halfWarningSound.transform.SetParent(_head);
                    halfWarningSound.Play();
                }
                if (enableSoundQueue && _timeInsideWater >= timeUntilDrowning / 4)
                {
					quarterWarningSound.transform.SetParent(_head);
                    quarterWarningSound.Play();
                }
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