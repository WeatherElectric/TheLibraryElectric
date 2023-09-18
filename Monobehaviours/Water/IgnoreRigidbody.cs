using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Water
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Markers/Ignore RB For Buoyancy")]
#endif
    public class IgnoreRigidbody : MonoBehaviour
    {
#if !UNITY_EDITOR
        public IgnoreRigidbody(IntPtr ptr) : base(ptr) { }
#endif
    }
}