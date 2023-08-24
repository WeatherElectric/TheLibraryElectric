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
            ModConsole.Msg("Increasing timeScale by 1", LoggingMode.DEBUG);
            ScaleTime(Time.timeScale + 1.0f);
        }
        public void DecreaseTimeScale()
        {
            float newTimeScale = Time.timeScale - 1.0f;
            if (newTimeScale >= 0.0f)
            {
                ModConsole.Msg("Decreasing timeScale by 1", LoggingMode.DEBUG);
                ScaleTime(newTimeScale);
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