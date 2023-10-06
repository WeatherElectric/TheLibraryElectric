﻿using UnityEngine;
using System;
using UltEvents;

namespace TheLibraryElectric.Signals
{
    public class RecieveSignal : MonoBehaviour
    {
        public string activationKey;
        private void Start()
        {
            ModConsole.Msg($"Reciever spawned, key is {activationKey}", LoggingMode.DEBUG);
        }
        public void InvokeEvent()
        {
            var il2cppsucks = GetComponent<UltEventHolder>();
            il2cppsucks.Invoke();
        }
#if !UNITY_EDITOR
        public RecieveSignal(IntPtr ptr) : base(ptr) { }
#endif
    }
}