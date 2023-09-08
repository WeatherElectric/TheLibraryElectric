using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheLibraryElectric
{
    public class GravityChamber : MonoBehaviour
    {
        [HideInInspector]
        public List<Collider> inTriggerCol = new List<Collider>();
        public Vector3 gravityAmount;
        public Vector3 GravityAmount
        {
            get { return gravityAmount; }
            set { gravityAmount = value; }
        }
        public bool ignoreRigManager;
        void OnTriggerEnter(Collider other)
        {

        }
        void OnTriggerExit(Collider other) // When the GameObject exits the trigger collider
        {


        }
        void Update()
        {

        }

    }
}
