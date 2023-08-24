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
        public enum ActivationKey
        {
            CODE_A,
            CODE_B,
            CODE_C,
            CODE_D,
            CODE_E,
            CODE_F,
            CODE_G,
            CODE_H,
            CODE_I,
            CODE_J,
            CODE_K,
            CODE_L,
            CODE_M,
            CODE_N,
            CODE_O,
            CODE_P,
            CODE_Q,
            CODE_R,
            CODE_S,  
            CODE_T,
            CODE_U,
            CODE_V,
            CODE_W,
            CODE_X,
            CODE_Y,
            CODE_Z,
        }
        public ActivationKey activationKey;
        public void Broadcast()
        {
            ModConsole.Msg("Broadcasting", LoggingMode.DEBUG);
            ModConsole.Msg("Finding recievers", LoggingMode.DEBUG);
            RecieveSignal[] recievers = FindObjectsOfType<RecieveSignal>();
            ModConsole.Msg("Got recievers", LoggingMode.DEBUG);
            foreach (RecieveSignal reciever in recievers)
            {
                ModConsole.Msg($"Reciever gameobject is {reciever.gameObject.name}", LoggingMode.DEBUG);
                ModConsole.Msg($"Sender key is {activationKey}, reciever key is {reciever.activationKey}", LoggingMode.DEBUG);
                if ((int)activationKey == (int)reciever.activationKey)
                {
                    ModConsole.Msg("Calling reciever's invoke method", LoggingMode.DEBUG);
                    reciever.InvokeEvent();
                }
                else
                {
                    ModConsole.Msg("Could not find reciever's key, or key was not the same as sender's", LoggingMode.DEBUG);
                }
            }
        }
#if !UNITY_EDITOR
        public SendSignal(IntPtr ptr) : base(ptr) { }
#endif
    }
}