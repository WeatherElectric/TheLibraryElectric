using Il2CppUltEvents;
using TheLibraryElectric.Temp;
using UnityEngine;

namespace TheLibraryElectric.Misc
{
    public class RecordingEvents : MonoBehaviour
    {
        public bool invokeOnStart;
        public UltEvent ifObsRecording;
        public UltEvent ifNotRecording;

        private void Start()
        {
            if (!invokeOnStart)
            {
                return;
            }
            if (Utilities.IsObsRecording)
            {
                ifObsRecording.Invoke();
            }
            else
            {
                ifNotRecording.Invoke();
            }
        }

        public void Invoke()
        {
            if (Utilities.IsObsRecording)
            {
                ifObsRecording.Invoke();
            }
            else
            {
                ifNotRecording.Invoke();
            }
        }
    }
}