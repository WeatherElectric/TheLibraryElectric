using UnityEngine;
using System;
using MelonLoader;
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
            CODE_A =1,
            CODE_B =2,
            CODE_C =3,
            CODE_D =4,
            CODE_E =5,
            CODE_F =6,
            CODE_G =7,
            CODE_H =8,
            CODE_I =9,
            CODE_J =10,
            CODE_K =11,
            CODE_L =12,
            CODE_M =13,
            CODE_N =14,
            CODE_O =15,
            CODE_P =16,
            CODE_Q =17,
            CODE_R =18,
            CODE_S =19,  
            CODE_T =20,
            CODE_U =21,
            CODE_V =22,
            CODE_W =23,
            CODE_X =24,
            CODE_Y =25,
            CODE_Z =26,
        }
        public ActivationKey activationKey;
        public void Broadcast()
        {
            MelonLogger.Msg("Method was called");
            MelonLogger.Msg("Getting all recievers");
            RecieveSignal[] recievers = FindObjectsOfType<RecieveSignal>();
            MelonLogger.Msg("Foreach");
            foreach (RecieveSignal reciever in recievers)
            {
                MelonLogger.Msg("Check if activation key is the same");
                MelonLogger.Msg($"Reciever's gameobject is {reciever.gameObject.name}");
                if ((int)activationKey == (int)reciever.activationKey)
                {
                    MelonLogger.Msg("Invoke");
                    reciever.InvokeEvent();
                }
                else
                {
                    MelonLogger.Msg("Key was not the same, or some other error");
                }
            }
        }
#if !UNITY_EDITOR
        public SendSignal(IntPtr ptr) : base(ptr) { }
#endif
    }
}