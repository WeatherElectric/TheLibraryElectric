using UnityEngine;
using System;
using UltEvents;

namespace TheLibraryElectric.Signals
{
    [AddComponentMenu("The Library Electric/Signals/Recieve Signal")]
    public class RecieveSignal : ElectricBehaviour
    {
        [Tooltip("The key to activate this signal.")]
        public string activationKey;
        [Tooltip("The event to invoke when the signal is recieved.")]
        public UltEvent activationEvent;
        private void Start()
        {

        }
        public void InvokeEvent()
        {
            activationEvent.Invoke();
        }
    }
}