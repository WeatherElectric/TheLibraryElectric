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
        public string activationKey;
        public void Broadcast()
        {
            ModConsole.Msg("Broadcasting", LoggingMode.DEBUG);
            ModConsole.Msg("Finding recievers", LoggingMode.DEBUG);
            RecieveSignal[] recievers = FindObjectsOfType<RecieveSignal>();
            ModConsole.Msg("Got recievers", LoggingMode.DEBUG);
            foreach (RecieveSignal reciever in recievers)
            {
                ModConsole.Msg("Finding recievers again", LoggingMode.DEBUG);
                RecieveSignal il2cppsucks = reciever.gameObject.GetComponent<RecieveSignal>();
                ModConsole.Msg($"Reciever gameobject is {il2cppsucks.gameObject.name}", LoggingMode.DEBUG);
                ModConsole.Msg($"Sender key is {activationKey}, reciever key is {il2cppsucks.activationKey}", LoggingMode.DEBUG);
                if (activationKey == il2cppsucks.activationKey)
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