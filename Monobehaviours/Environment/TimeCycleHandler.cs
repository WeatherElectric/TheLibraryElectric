using UnityEngine;
using System;

namespace TheLibraryElectric.Environment
{
    public class TimeCycleHandler : MonoBehaviour
    {
        public Light sun;
        public float yAxis;
        public float zAxis;

        private void Update()
        {
            var now = DateTime.Now;
            float hours = now.Hour;
            float minutes = now.Minute;
            float seconds = now.Second;
            var totalSeconds = hours * 3600 + minutes * 60 + seconds;
            var angle = 90 - (totalSeconds / 86400) * 360;
            sun.transform.rotation = Quaternion.Euler(-angle, yAxis, zAxis);
        }
#if !UNITY_EDITOR
        public TimeCycleHandler(IntPtr ptr) : base(ptr) { }
#endif
    }
}