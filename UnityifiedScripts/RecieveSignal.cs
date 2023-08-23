using UnityEngine;
using UltEvents;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric
{
#if UNITY_EDITOR
[AddComponentMenu("The Library Electric/Recieve Signal")]
[RequireComponent(typeof(UltEventHolder))]
#endif
    public class RecieveSignal : MonoBehaviour
    {
        public string activationKey = "";
        private UltEventHolder ultEvent;
        private void Start()
        {
            ultEvent = GetComponent<UltEventHolder>();
        }
        public void InvokeEvent()
        {
            if (ultEvent != null)
            {
                ultEvent.Invoke();
            }
            else
            {
                Debug.LogWarning("No ultevent present!");
            }
        }
    }
}