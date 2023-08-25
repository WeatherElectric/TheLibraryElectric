using UnityEngine;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Misc/Update TextMeshPro")]
#endif
    public class UpdateTMP : MonoBehaviour
    {
        public TextMeshPro textMeshPro;
        public float startingValue = 1.0f;
        public float incrementAmount = 0.5f;

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
            if (currentValue < 0.0f)
            {
                currentValue = 0.0f;
            }
            UpdateTextValue();
        }
    }
}
