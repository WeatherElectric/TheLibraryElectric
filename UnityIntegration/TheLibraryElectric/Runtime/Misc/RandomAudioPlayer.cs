using UnityEngine;
using Random = UnityEngine.Random;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Misc
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Misc/Random Audio Player")]
#endif
    public class RandomAudioPlayer : MonoBehaviour
    {
        public AudioSource[] audioSources;
        private void Start()
        {
            if (audioSources.Length == 0)
            {
                Debug.LogError("No AudioSources assigned to the array!");
            }
        }

        public void PlayRandomSound()
        {
            if (audioSources.Length > 0)
            {
                int randomIndex = Random.Range(0, audioSources.Length);
                
                audioSources[randomIndex].Play();
            }
			else
			{
				Debug.LogWarning("No AudioSources assigned to the array!");
			}
        }
    }
}