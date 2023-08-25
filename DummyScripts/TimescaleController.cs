using UnityEngine;
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
		private float timeScale = 1.0f;
        public void ScaleTime()
        {
        }
		private void FixedUpdate()
		{
		}
        public void IncreaseTimeScale()
        {
        }
        public void DecreaseTimeScale()
        {
        }
        private void OnDestroy()
        {
        }
    }
}