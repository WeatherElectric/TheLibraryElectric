using System;
using UltEvents;
using UnityEngine;

namespace TheLibraryElectric.Misc
{
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
