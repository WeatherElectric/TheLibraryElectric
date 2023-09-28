using UnityEngine;
using TMPro;
using System;

namespace TheLibraryElectric.Misc
{
    public class UpdateTMP : MonoBehaviour
    {
        public TextMeshPro textMeshPro;
        public float startingValue = 1.0f;
        public float incrementAmount = 0.5f;
        public float minValue = 0.1f;

        private float currentValue;

        private void Start()
        {
            ModConsole.Msg($"Starting value is {startingValue}", LoggingMode.DEBUG);
            currentValue = startingValue;
            UpdateTextValue();
        }

        private void UpdateTextValue()
        {
            textMeshPro.text = currentValue.ToString("F1"); // Displaying with one decimal place
        }

        public void IncreaseValue()
        {
            currentValue += incrementAmount;
            ModConsole.Msg($"Increasing value by {incrementAmount}, now {currentValue}", LoggingMode.DEBUG);
            UpdateTextValue();
        }
        public void DecreaseValue()
        {
            currentValue -= incrementAmount;
            ModConsole.Msg($"Decreasing value by {incrementAmount}, now {currentValue}", LoggingMode.DEBUG);
            if (currentValue < 0.1f)
            {
                ModConsole.Msg("Value should not be lower than 0.1!", LoggingMode.DEBUG);
                currentValue = minValue;
            }
            UpdateTextValue();
        }
#if !UNITY_EDITOR
        public UpdateTMP(IntPtr ptr) : base(ptr) { }
#endif
    }
}