using UnityEngine;
using System;
using UltEvents;

namespace TheLibraryElectric.Signals
{
    public class RecieveSignal : MonoBehaviour
    {
        public string activationKey;
        public UltEvent ultEvent;
        private void Start()
        {
            ModConsole.Msg($"Reciever spawned, key is {activationKey}", LoggingMode.DEBUG);
        }
        public void InvokeEvent()
        {
            ultEvent.Invoke();
        }
#if !UNITY_EDITOR
        public RecieveSignal(IntPtr ptr) : base(ptr) { }
#endif
    }
}