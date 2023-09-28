using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TheLibraryElectric.Misc
{
    public class RandomAudioPlayer : MonoBehaviour
    {
        public AudioSource[] audioSources;
        private void Start()
        {
            if (audioSources.Length == 0)
            {
                ModConsole.Msg("No audiosources assigned!", LoggingMode.DEBUG);
            }
        }

        public void PlayRandomSound()
        {
            if (audioSources.Length > 0)
            {
                var randomIndex = Random.Range(0, audioSources.Length);
                
                audioSources[randomIndex].Play();
            }
            else
            {
                ModConsole.Msg("No audiosources assigned!", LoggingMode.DEBUG);
            }
        }
#if !UNITY_EDITOR
        public RandomAudioPlayer(IntPtr ptr) : base(ptr) { }
#endif
    }
}