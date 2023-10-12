using UnityEngine;
using System;

namespace TheLibraryElectric.Environment
{
    public class TimeCycleHandler : MonoBehaviour
    {
        public Light sun;
        public float yAxis;
        public float zAxis;
        public float nightLightIntensity = 0.001f;
        public float dayLightIntensity = 1.0f;
        public ReflectionProbe[] reflectionProbes;
        public float nightIntensity = 0.4f;
        public float dayIntensity = 1.0f;
        public float nightStartHour = 19.0f;
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
            var intensity = CalculateIntensity(hours, false);
            foreach (var reflectionProbe in reflectionProbes)
            {
                reflectionProbe.intensity = intensity;
            }
            var lightintensity = CalculateIntensity(hours, true);
            sun.intensity = lightintensity;
        }
        
        private float CalculateIntensity(float hours, bool light)
        {
            if (light)
            {
                if (hours >= nightStartHour || hours < nightEndHour)
                {
                    return nightLightIntensity;
                }
                else
                {
                    return dayLightIntensity;
                }
            }
            else
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
        
#if !UNITY_EDITOR
        public TimeCycleHandler(IntPtr ptr) : base(ptr) { }
#endif
    }
}