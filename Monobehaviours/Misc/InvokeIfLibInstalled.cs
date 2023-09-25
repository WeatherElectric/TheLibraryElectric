using System;
using UltEvents;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Misc
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Misc/Invoke if Library is Installed")]
#endif
    public class InvokeIfLibInstalled : MonoBehaviour
    {
        public void Awake()
        {
            gameObject.GetComponent<UltEventHolder>().Invoke();
        }
#if !UNITY_EDITOR
        public InvokeIfLibInstalled(IntPtr ptr) : base(ptr) { }
#endif
    }
}
