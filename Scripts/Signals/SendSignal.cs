using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric
{
#if UNITY_EDITOR
[AddComponentMenu("The Library Electric/Signals/Send Signal")]
#endif
    public class SendSignal : MonoBehaviour
    {
        public string activationKey = "";
        public void Broadcast()
        {
            RecieveSignal[] recievers = FindObjectsOfType<RecieveSignal>();
            foreach (RecieveSignal reciever in recievers)
            {
                if (reciever != null && reciever.activationKey == activationKey)
                {
                    reciever.InvokeEvent();
                }
            }
        }
#if !UNITY_EDITOR
        public SendSignal(IntPtr ptr) : base(ptr) { }
#endif
    }
}