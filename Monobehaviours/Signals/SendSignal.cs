using UnityEngine;
using System;
using TheLibraryElectric.Melon;

namespace TheLibraryElectric.Signals
{
    public class SendSignal : MonoBehaviour
    {
        public string activationKey;
        public void Broadcast()
        {
            ModConsole.Msg("Fun fact! Reciever is spelled wrong in every log bit, and in the component. I'm not fixing it.", 1);
            ModConsole.Msg("Broadcasting", 1);
            ModConsole.Msg("Finding recievers", 1);
            RecieveSignal[] recievers = FindObjectsOfType<RecieveSignal>();
            ModConsole.Msg("Got recievers", 1);
            foreach (var reciever in recievers)
            {
                ModConsole.Msg("Finding recievers again", 1);
                var il2cppsucks = reciever.gameObject.GetComponent<RecieveSignal>();
                ModConsole.Msg($"Reciever gameobject is {il2cppsucks.gameObject.name}", 1);
                ModConsole.Msg($"Sender key is {activationKey}, reciever key is {il2cppsucks.activationKey}", 1);
                if (activationKey == il2cppsucks.activationKey)
                {
                    ModConsole.Msg("Calling reciever's invoke method", 1);
                    reciever.InvokeEvent();
                }
                else
                {
                    ModConsole.Msg("Could not find reciever's key, or key was not the same as sender's", 1);
                }
            }
        }
#if !UNITY_EDITOR
        public SendSignal(IntPtr ptr) : base(ptr) { }
#endif
    }
}