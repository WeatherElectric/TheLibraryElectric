﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheLibraryElectric.Rigidbodies
{
    [AddComponentMenu("The Library Electric/Rigidbodies/Force Zone")]
    public class ForceZone : ElectricBehaviour
    {
        public List<Rigidbody> inTriggerRbs = new List<Rigidbody>();
        public Vector3 forceAmount;
        public Vector3 ForceAmount
        {
            get { return forceAmount; }
            set { forceAmount = value; }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody != null)
            {
                inTriggerRbs.Add(other.attachedRigidbody);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.attachedRigidbody != null && inTriggerRbs.Contains(other.attachedRigidbody))
            {
                inTriggerRbs.Remove(other.attachedRigidbody);
            }
        }

        private void Update()
        {
            foreach (var rb in inTriggerRbs)
            {
                rb.AddForce(forceAmount, ForceMode.Force);
            }
        }
    }
}
