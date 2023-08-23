using System;
using UnityEngine;

namespace TheLibraryElectric
{
    public class KinematicRB : MonoBehaviour
    {
#if !UNITY_EDITOR
        public KinematicRB(IntPtr ptr) : base(ptr) { }
#endif
    }
}