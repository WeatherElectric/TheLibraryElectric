using SLZ.Interaction;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Misc
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Misc/Mr Splitter")]
#endif
    public class MrSplitter : MonoBehaviour
    {
        public int amount = 5;
        public float force = 10f;
        Vector3[] offsets = { new Vector3(0.25f, 0.25f, 0.25f), new Vector3(-0.25f, 0.25f, 0.25f), new Vector3(0.25f, 0.25f, -0.25f), new Vector3(-0.25f, 0.25f, -0.25f),
                            new Vector3(0.25f, -0.25f, 0.25f), new Vector3(-0.25f, -0.25f, 0.25f), new Vector3(0.25f, -0.25f, -0.25f), new Vector3(-0.25f, -0.25f, -0.25f),};
#if UNITY_EDITOR
        [ContextMenu("Break")]
#endif
        public void Break()
        {
            
        }
    }
}