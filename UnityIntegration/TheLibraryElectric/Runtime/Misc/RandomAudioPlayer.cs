using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TheLibraryElectric.Misc
{
    [AddComponentMenu("The Library Electric/Misc/Random Audio Player")]
    public class RandomAudioPlayer : ElectricBehaviour
    {
        public AudioSource[] audioSources;
        private void Start()
        {

        }

        public void PlayRandomSound()
        {
            if (audioSources.Length > 0)
            {
                var randomIndex = Random.Range(0, audioSources.Length);
                
                audioSources[randomIndex].Play();
            }
        }
    }
}