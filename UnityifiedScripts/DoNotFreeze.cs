using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Do Not Freeze")]
#endif
    public class DoNotFreeze : MonoBehaviour
    {
#if UNITY_EDITOR
		[SerializeField]
        [TextArea(3, 10)] // Allows for multiline input in the Inspector
        private const string usageNote = "This component must be on the same GameObject as the Rigidbody.";
#endif
    }
}