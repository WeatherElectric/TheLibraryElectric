using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Water
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Water/Prevent From Drowning")]
#endif
    public class PreventFromDrowning : MonoBehaviour
    {
        public bool preventDrowning;

        public bool PreventDrowning
        {
            get { return preventDrowning; }
            set { preventDrowning = value; }
        }
#if !UNITY_EDITOR
        public PreventFromDrowning(IntPtr ptr) : base(ptr) { }
#endif
    }
}