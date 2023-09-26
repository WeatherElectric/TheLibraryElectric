using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Water
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Markers/Ignore RB For Buoyancy")]
	[RequireComponent(typeof(Rigidbody))]
#endif
    public class IgnoreRigidbody : MonoBehaviour
    {

    }
}