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
    }
}