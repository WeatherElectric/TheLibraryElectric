using UnityEngine;
using System;
using UltEvents;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Signals
{
#if UNITY_EDITOR
[AddComponentMenu("The Library Electric/Signals/Recieve Signal")]
[RequireComponent(typeof(UltEventHolder))]
#endif
    public class RecieveSignal : MonoBehaviour
    {
        public string activationKey;
        private UltEventHolder ultEvent;
        private void Start()
        {
            ModConsole.Msg($"Reciever spawned, key is {activationKey}", LoggingMode.DEBUG);
            ultEvent = GetComponent<UltEventHolder>();
        }
        public void InvokeEvent()
        {
            UltEventHolder il2cppsucks = GetComponent<UltEventHolder>();
            if (il2cppsucks != null)
            {
                ModConsole.Msg("Signal recieved, invoking", LoggingMode.DEBUG);
                il2cppsucks.Invoke();
            }
            else
            {
                ModConsole.Msg("No ultevent present!", LoggingMode.DEBUG);
            }
        }
#if !UNITY_EDITOR
        public RecieveSignal(IntPtr ptr) : base(ptr) { }
#endif
    }
}