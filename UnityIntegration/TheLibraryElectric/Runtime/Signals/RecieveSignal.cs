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
            ultEvent = GetComponent<UltEventHolder>();
        }
        public void InvokeEvent()
        {
            UltEventHolder il2cppsucks = GetComponent<UltEventHolder>();
            if (il2cppsucks != null)
            {
                il2cppsucks.Invoke();
            }
        }
    }
}