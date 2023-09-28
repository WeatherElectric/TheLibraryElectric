using System;
using SLZ.Rig;
using UnityEngine;

namespace TheLibraryElectric.Water
{
    [HideInInspector]
    public class HandMonitor : ElectricBehaviour
    {
        public Vector3 handVelocity;
        public RigManager rigManager;
        public float minimumVelocity;
        public float velocityMultiplier;
        private Rigidbody handRb;

        private void Start()
        {
            handRb = GetComponent<Rigidbody>();
        }
        private void FixedUpdate()
        {
            handVelocity = handRb.velocity - rigManager.physicsRig.m_chest.GetComponent<Rigidbody>().velocity;
            if (handVelocity.sqrMagnitude > minimumVelocity)
            {
                rigManager.physicsRig.m_head.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, handVelocity.sqrMagnitude * velocityMultiplier));
            }
        }
    }
}