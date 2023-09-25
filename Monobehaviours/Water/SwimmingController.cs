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

        private void OnTriggerEnter(Collider other)
        {
            rigManager = other.GetComponentInParent<RigManager>();
            if (rigManager != null)
            {
                ModConsole.Msg("SwimmingController: RigManager found!", LoggingMode.DEBUG);
                if (rigManager.physicsRig.leftHand.GetComponent<HandMonitor>() == null)
                {
                    var handMonitor = rigManager.physicsRig.leftHand.gameObject.AddComponent<HandMonitor>();
                    handMonitor.rigManager = rigManager;
                    handMonitor.minimumVelocity = minimumVelocity;

                }
                if (rigManager.physicsRig.rightHand.GetComponent<HandMonitor>() == null)
                {
                    var handMonitor = rigManager.physicsRig.rightHand.gameObject.AddComponent<HandMonitor>();
                    handMonitor.rigManager = rigManager;
                    handMonitor.minimumVelocity = minimumVelocity;
                    handMonitor.velocityMultiplier = velocityMultiplier;

                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            rigManager = other.GetComponentInParent<RigManager>();
            if (rigManager != null)
            {
                if (rigManager.physicsRig.leftHand.GetComponent<HandMonitor>() != null)
                {
                    Destroy(rigManager.physicsRig.leftHand.GetComponent<HandMonitor>());
                }
            }
            if (rigManager != null)
            {
                if (rigManager.physicsRig.rightHand.GetComponent<HandMonitor>() != null)
                {
                    Destroy(rigManager.physicsRig.rightHand.GetComponent<HandMonitor>());
                }
            }
        }
#if !UNITY_EDITOR
        public SwimmingController(IntPtr ptr) : base(ptr) { }
#endif
    }
}