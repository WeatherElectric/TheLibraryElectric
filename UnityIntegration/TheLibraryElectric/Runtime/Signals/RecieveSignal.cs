using UnityEngine;
using System;
using UltEvents;

namespace TheLibraryElectric.Signals
{
    [AddComponentMenu("The Library Electric/Signals/Recieve Signal")]
	[RequireComponent(typeof(UltEventHolder))]
    public class RecieveSignal : ElectricBehaviour
    {
        [Tooltip("The key to activate this signal.")]
        public string activationKey;
        private void Start()
        {

        }
        public void InvokeEvent()
        {
            var il2cppsucks = GetComponent<UltEventHolder>();
            il2cppsucks.Invoke();
        }
    }
}