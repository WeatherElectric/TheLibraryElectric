using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Markers
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Markers/Void Counter Object")]
#endif
    public class VoidCounterObject : MonoBehaviour
    {
        // bugo misspelled this, SLZ reference
        public bool disableDespsawnDelay;
    }
}