using System;
using UnityEngine;

namespace TheLibraryElectric.Signals
{
    [AddComponentMenu("The Library Electric/Signals/Signal Triggerer")]
    public class SignalTriggerer : ElectricBehaviour
    {
        public string Comment => "This must be on a collider!";
        [Tooltip("The key to activate this signal.")]
        public string activationKey;
        public void Start()
        {
        }
    }
}