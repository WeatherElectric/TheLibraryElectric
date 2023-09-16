using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Water
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Water/Rigidbody Buoyancy")]
    [RequireComponent(typeof(Rigidbody))]
#endif
    public class RigidbodyBuoyancy : MonoBehaviour
    {
#if UNITY_EDITOR
        [Tooltip("This mass will be used instead of the rigidbody's mass.")]
#endif
        public float customMass = 1.0f;
        private Rigidbody _rb;
        private float _ogMass;
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _ogMass = _rb.mass;
        }
        public void DoTheThing()
        {
            _rb.mass = customMass;
        }
        public void UndoTheThing()
        {
            _rb.mass = _ogMass;
        }
    }
}