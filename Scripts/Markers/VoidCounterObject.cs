using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TheLibraryElectric.Scripts.Misc
{
    public class VoidCounterObject : MonoBehaviour
    {
#if !UNITY_EDITOR
        public VoidCounterObject(IntPtr ptr) : base(ptr) { }
#endif
    }
}
