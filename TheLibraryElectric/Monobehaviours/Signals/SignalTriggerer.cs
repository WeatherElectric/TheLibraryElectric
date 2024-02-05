using System;
using TheLibraryElectric.Melon;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Signals
{
    public class SignalTriggerer : MonoBehaviour
    {
        public string activationKey;
        public void Start()
        {
            ModConsole.Msg($"SignalTriggerer spawned, key is {activationKey}", 1);
        }
#if !UNITY_EDITOR
        public SignalTriggerer(IntPtr ptr) : base(ptr) { }
#endif
    }
}