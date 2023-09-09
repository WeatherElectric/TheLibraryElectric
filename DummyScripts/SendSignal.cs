using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Signals
{
#if UNITY_EDITOR
[AddComponentMenu("The Library Electric/Signals/Send Signal")]
#endif
    public class SendSignal : MonoBehaviour
    {
        public string activationKey;
        public void Broadcast()
        {
            
        }
    }
}