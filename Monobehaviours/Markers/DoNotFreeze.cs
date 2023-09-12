using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Markers
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Markers/Do Not Freeze")]
    [RequireComponent(typeof(Rigidbody))]
#endif
    public class DoNotFreeze : MonoBehaviour
    {
#if !UNITY_EDITOR
        public DoNotFreeze(IntPtr ptr) : base(ptr) { }
#endif
    }
}