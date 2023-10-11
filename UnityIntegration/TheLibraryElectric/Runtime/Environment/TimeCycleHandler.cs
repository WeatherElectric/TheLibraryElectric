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
		[Header("Light Settings")]
		[Tooltip("What should the light's rotation on the Y axis be?")]
        public float yAxis;
		[Tooltip("What should the light's rotation on the Z axis be?")]
        public float zAxis;
        [Tooltip("The reflection probe(s) to change the intensity of.")]
        public ReflectionProbe[] reflectionProbes;
        [Header("Reflection Probe Settings")]
        [Tooltip("What should the reflection probe's intensity be at night?")]
        public float nightIntensity = 0.4f;
        [Tooltip("What should the reflection probe's intensity be at day?")]
        public float dayIntensity = 1.0f;
        [Header("Time Settings")] 
        [Tooltip("What hour should the night start? 24 hour format")]
        public float nightStartHour = 19.0f;
	    [Tooltip("What hour should the night end? 24 hour format")]
        public float nightEndHour = 6.0f;

        private void Update()
        {
            var now = DateTime.Now;
            float hours = now.Hour;
            float minutes = now.Minute;
            float seconds = now.Second;
            var totalSeconds = hours * 3600 + minutes * 60 + seconds;
            var angle = 90 - (totalSeconds / 86400) * 360;
            sun.transform.rotation = Quaternion.Euler(-angle, yAxis, zAxis);
            var intensity = CalculateIntensity(hours, minutes);
            foreach (var reflectionProbe in reflectionProbes)
            {
	            reflectionProbe.intensity = intensity;
            }
        }
        
        private float CalculateIntensity(float hours, float minutes)
        {
	        if (hours >= nightStartHour || hours < nightEndHour)
	        {
		        return nightIntensity;
	        }
	        else
	        {
		        return dayIntensity;
	        }
        }
    }
}