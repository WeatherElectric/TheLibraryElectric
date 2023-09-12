using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Markers
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Markers/Do Not Destroy")]
	[RequireComponent(typeof(Rigidbody))]
#endif
    public class DoNotDestroy : MonoBehaviour
    {
		
    }
}