using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Markers
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Markers/Do Not Freeze")]
    [RequireComponent(typeof(Rigidbody))]
#endif
    public class DoNotFreeze : MonoBehaviour
    {
#if UNITY_EDITOR
		[SerializeField]
        [TextArea(3, 10)] // Allows for multiline input in the Inspector
        private const string usageNote = "This component must be on the same GameObject as the Rigidbody.";
#endif
#if !UNITY_EDITOR
        public DoNotFreeze(IntPtr ptr) : base(ptr) { }
#endif
    }
}