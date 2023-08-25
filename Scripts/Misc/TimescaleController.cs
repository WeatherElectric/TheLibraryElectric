using UnityEngine;
using System;
using static Ara.AraTrail;
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
        public float incrementValue = 0.5f;
        public void ScaleTime(float timeScale)
        {
            if (timeScale >= 0.0f)
            {
                ModConsole.Msg($"Setting timescale to {timeScale}", LoggingMode.DEBUG);
                Time.timeScale = timeScale;
            }
            else
            {
                ModConsole.Msg("Scale cannot be negative!", LoggingMode.DEBUG);
            }
        }
        public void IncreaseTimeScale()
        {
            float addTimeScale = Time.timeScale + incrementValue;
            ModConsole.Msg($"Increasing timeScale by {incrementValue}, now {addTimeScale}", LoggingMode.DEBUG);
            ScaleTime(addTimeScale);
        }
        public void DecreaseTimeScale()
        {
            float subTimeScale = Time.timeScale - incrementValue;
            if (subTimeScale >= 0.0f)
            {
                ModConsole.Msg($"Decreasing timeScale by {incrementValue}, now {subTimeScale}", LoggingMode.DEBUG);
                ScaleTime(subTimeScale);
            }
            else
            {
                ModConsole.Msg("Scale cannot be negative!", LoggingMode.DEBUG);
            }
        }
#if !UNITY_EDITOR
        public TimescaleController(IntPtr ptr) : base(ptr) { }
#endif
    }
}