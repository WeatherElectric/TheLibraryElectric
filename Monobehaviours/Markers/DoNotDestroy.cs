using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Markers
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Markers/Do Not Destroy")]
#endif
    public class DoNotDestroy : MonoBehaviour
    {
#if !UNITY_EDITOR
        public DoNotDestroy(IntPtr ptr) : base(ptr) { }
#endif
    }
}