using UnityEngine;
using System;

namespace TheLibraryElectric.Signals
{
    [AddComponentMenu("The Library Electric/Signals/Send Signal")]
    public class SendSignal : ElectricBehaviour
    {
        [Tooltip("The key to activate this signal.")]
        public string activationKey;
        public void Broadcast()
        {
            RecieveSignal[] recievers = FindObjectsOfType<RecieveSignal>();
            foreach (var reciever in recievers)
            {
                var il2cppsucks = reciever.gameObject.GetComponent<RecieveSignal>();
                if (activationKey == il2cppsucks.activationKey)
                {
                    reciever.InvokeEvent();
                }
            }
        }
    }
}