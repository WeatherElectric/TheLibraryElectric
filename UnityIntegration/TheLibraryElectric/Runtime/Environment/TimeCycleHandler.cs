using System;
using UnityEngine;

namespace TheLibraryElectric.Environment
{
    [AddComponentMenu("The Library Electric/Environment/Time Cycle Handler")]
    public class TimeCycleHandler : MonoBehaviour
    {
		[Header("Light")]
		[Tooltip("The directional light that will be rotated.")]
        public Light sun;
		[Header("Extra Rotation")]
		[Tooltip("What should the light's rotation on the Y axis be?")]
        public float yAxis;
		[Tooltip("What should the light's rotation on the Z axis be?")]
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
    }
}