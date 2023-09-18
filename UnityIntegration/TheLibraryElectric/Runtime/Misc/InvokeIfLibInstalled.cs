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
    class InvokeIfLibInstalled : MonoBehaviour
    {
        [TextArea]
        public string Comment = "This script will invoke a ultevent on awake.\nUseful when you need to detect if The Library Electric is installed.";
        public void Awake()
        {
            gameObject.GetComponent<UltEventHolder>().Invoke();
        }
#if !UNITY_EDITOR
        public InvokeIfLibInstalled(IntPtr ptr) : base(ptr) { }
#endif
    }
}
