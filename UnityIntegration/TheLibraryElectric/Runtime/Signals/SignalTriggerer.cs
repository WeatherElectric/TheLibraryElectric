using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Signals
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Signals/Signal Triggerer")]
#endif
    public class SignalTriggerer : MonoBehaviour
    {
        public string activationKey;
        public void Start()
        {

        }
    }
}