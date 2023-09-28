using System;
using UnityEngine;

namespace TheLibraryElectric.Markers
{
    public class VoidCounterObject : MonoBehaviour
    {
        // bugo misspelled this, SLZ reference
        public bool disableDespsawnDelay;
#if !UNITY_EDITOR
        public VoidCounterObject(IntPtr ptr) : base(ptr) { }
#endif
    }
}