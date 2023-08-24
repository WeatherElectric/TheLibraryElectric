using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Spawnable Stuff/Timescale Controller")]
#endif
    public class TimescaleController : MonoBehaviour
    {
        public void ScaleTime(float timeScale)
        {
            if (timeScale >= 0.0f)
            {
                Time.timeScale = timeScale;
            }
        }
        public void IncreaseTimeScale()
        {
            ScaleTime(Time.timeScale + 1.0f);
        }
        public void DecreaseTimeScale()
        {
            float newTimeScale = Time.timeScale - 1.0f;
            if (newTimeScale >= 0.0f)
            {
                ScaleTime(newTimeScale);
            }
        }
#if !UNITY_EDITOR
        public TimescaleController(IntPtr ptr) : base(ptr) { }
#endif
    }
}