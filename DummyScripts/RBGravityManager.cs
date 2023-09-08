using System;
using UnityEngine;
using UnityEditor;

namespace TheLibraryElectric
{
    public class RBGravityManager : MonoBehaviour
    {
        [HideInInspector]
        public Rigidbody thisRb;
        public Vector3 gravityAmount;
        public Vector3 GravityAmount
        {
            get { return gravityAmount; }
            set { gravityAmount = value; }
        }
        void Start()
        {

        }
        void FixedUpdate()
        {

        }

    }
}
