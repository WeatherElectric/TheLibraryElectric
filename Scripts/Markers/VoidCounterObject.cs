﻿using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Markers/Void Counter Object")]
#endif
    public class VoidCounterObject : MonoBehaviour
    {
        public bool disableDespsawnDelay;
#if !UNITY_EDITOR
        public VoidCounterObject(IntPtr ptr) : base(ptr) { }
#endif
    }
}