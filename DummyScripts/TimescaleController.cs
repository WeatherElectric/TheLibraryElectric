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
        public void ScaleTime(float timeScale)
        {
			return;
        }
        public void IncreaseTimeScale()
        {
        }
        public void DecreaseTimeScale()
        {
        }
    }
}