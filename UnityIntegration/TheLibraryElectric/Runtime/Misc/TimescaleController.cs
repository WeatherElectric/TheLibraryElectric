using UnityEngine;
using System;

namespace TheLibraryElectric.Misc
{
    [AddComponentMenu("The Library Electric/Misc/Timescale Controller")]
    public class TimescaleController : ElectricBehaviour
    {
        [Tooltip("The amount to increment the timeScale by.")]
        public float incrementValue = 0.5f;
        private float timeScale = 1.0f;
        public void ScaleTime()
        {
            if (timeScale >= 0.1f)
            {
                Time.timeScale = timeScale;
            }
        }
        private void FixedUpdate()
        {
            ScaleTime();
        }
        public void IncreaseTimeScale()
        {
            var currentTimeScale = timeScale;
            timeScale = currentTimeScale + incrementValue;
        }
        public void DecreaseTimeScale()
        {
            var currentTimeScale = timeScale;
            var newTimeScale = currentTimeScale - incrementValue;
            if (currentTimeScale >= 0.1f)
            {
                timeScale = newTimeScale;
            }
        }
        private void OnDestroy()
        {
            Time.timeScale = 1.0f;
        }
    }
}