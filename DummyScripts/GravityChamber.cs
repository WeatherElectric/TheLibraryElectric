using System;
using System.Collections.Generic;
using SLZ.Rig;
using UnityEngine;

namespace TheLibraryElectric.Rigidbodies
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Rigidbody Related/Gravity Chamber")]
	[RequireComponent(typeof(Collider))]
#endif
    public class GravityChamber : MonoBehaviour
    {
        public List<RBGravityManager> inTriggerCol = new List<RBGravityManager>();
        public Vector3 gravityAmount;
        public bool ignoreRigManager;
        public Vector3 GravityAmount
        {
            get { return gravityAmount; }
            set { gravityAmount = value; }
        }
        void OnTriggerEnter(Collider other)
        {
            return;
        }
        void OnTriggerExit(Collider other) // When the GameObject exits the trigger collider
        {
            return;
        }
        void Update()
        {
            
        }
    }
}
