using System;
using SLZ.Interaction;
using SLZ.Marrow.Pool;
using UnityEngine;

namespace TheLibraryElectric.Misc
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Misc/Absolute Fizzler")]
    [RequireComponent(typeof(Collider))]
#endif
    public class AbsoluteFizzler : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
        }
    }
}