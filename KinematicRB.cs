using MelonLoader;
using UnityEngine;
using System;

namespace TheLibraryElectric
{
    [RegisterTypeInIl2Cpp]
    public class KinematicRB : MonoBehaviour
    {
#if !UNITY_EDITOR
        public KinematicRB(IntPtr ptr) : base(ptr) { }
#endif
    }
}