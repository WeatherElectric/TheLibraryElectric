using System;
using UnityEngine;
using TheLibraryElectric.Patching;

namespace TheLibraryElectric.PlayerUtil
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Player Utilities/Prevent Nimbus")]
#endif
    public class PreventNimbus : MonoBehaviour
    {
        private void Awake()
        {
            NimbusPatch.nimbusToggle = true;
        }
#if !UNITY_EDITOR
        public PreventNimbus(IntPtr ptr) : base(ptr) { }
#endif
    }
}