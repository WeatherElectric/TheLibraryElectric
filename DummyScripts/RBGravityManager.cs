using System;
using UnityEngine;

namespace TheLibraryElectric.Rigidbodies
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Rigidbody Related/RB Gravity Manager")]
	[RequireComponent(typeof(Rigidbody))]
#endif
    public class RBGravityManager : MonoBehaviour
    {
#if UNITY_EDITOR
	[HideInInspector]
#endif
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
