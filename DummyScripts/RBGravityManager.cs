using System;
using UnityEngine;

namespace TheLibraryElectric.Rigidbodies
{
    public class RBGravityManager : MonoBehaviour
    {
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
