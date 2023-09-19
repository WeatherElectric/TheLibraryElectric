using System;
using UnityEngine;
using SLZ.Rig;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Water
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Water/Swimming Controller")]
    [RequireComponent(typeof(Collider))]
#endif
    public class SwimmingController : MonoBehaviour
    {
#if UNITY_EDITOR
        [HideInInspector]
#endif
        public RigManager rigManager;
        public float minimumVelocity = 10f;
        public float velocityMultiplier = 100f;
        void OnTriggerEnter(Collider other)
        {
            return;
        }
        void OnTriggerExit(Collider other)
        {
            return;
        }
    }
}