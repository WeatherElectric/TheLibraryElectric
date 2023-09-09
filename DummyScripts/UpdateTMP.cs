using UnityEngine;
using TMPro;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Misc
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Misc/Update TextMeshPro")]
#endif
    public class UpdateTMP : MonoBehaviour
    {
        public TextMeshPro textMeshPro;
        public float startingValue = 1.0f;
        public float incrementAmount = 0.5f;
        public float minValue = 0.1f;

        private float currentValue;

        private void Start()
        {
            
        }

        private void UpdateTextValue()
        {
            
        }

        public void IncreaseValue()
        {
            
        }
        public void DecreaseValue()
        {
            
        }
    }
}