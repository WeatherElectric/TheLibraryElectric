using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Misc/Audio Stream Player")]
#endif
    public class AudioStreamPlayer : MonoBehaviour
    {
        public AudioSource audioSource;
        public string audioStreamUrl = "";

        IEnumerator Start()
        {
            if (audioSource == null)
            {
                ModConsole.Msg("AudioSource not assigned!", LoggingMode.DEBUG);
                yield break;
            }

            UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(audioStreamUrl, AudioType.MPEG);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                AudioClip audioClip = DownloadHandlerAudioClip.GetContent(www);
                audioSource.clip = audioClip;
                ModConsole.Msg($"Playing streamed clip from {audioStreamUrl} to {audioSource.gameObject.name}", LoggingMode.DEBUG);
                audioSource.Play();
            }
            else
            {
                ModConsole.Msg($"Error loading audio stream: {www.error}", LoggingMode.DEBUG);
            }

            www.Dispose(); // Dispose of the UnityWebRequest
        }
    }
}