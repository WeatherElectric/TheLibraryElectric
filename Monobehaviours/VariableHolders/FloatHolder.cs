using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TheLibraryElectric.VariableHolders
{
    public class FloatHolder : MonoBehaviour
    {
        public float variable;
        public float Variable
        {
            get { return variable; }
            set { variable = value; }
        }
#if !UNITY_EDITOR
        public FloatHolder(IntPtr ptr) : base(ptr) { }
#endif
    }
}
