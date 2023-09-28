using UnityEngine;
using TMPro;
using System;

namespace TheLibraryElectric.Misc
{
    [AddComponentMenu("The Library Electric/Misc/Update TMP")]
    public class UpdateTMP : ElectricBehaviour
    {
        [Tooltip("The TextMeshPro component to update.")]
        public TextMeshPro textMeshPro;
        [Tooltip("The starting value of the text.")]
        public float startingValue = 1.0f;
        [Tooltip("The amount to increment the value by.")]
        public float incrementAmount = 0.5f;
        [Tooltip("The minimum value the text can be.")]
        public float minValue = 0.1f;
        private float currentValue;

        private void Start()
        {
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
            UpdateTextValue();
        }
        public void DecreaseValue()
        {
            currentValue -= incrementAmount;
            if (currentValue < 0.1f)
            {
                currentValue = minValue;
            }
            UpdateTextValue();
        }
    }
}