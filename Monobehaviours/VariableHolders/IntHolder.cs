using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TheLibraryElectric.VariableHolders
{
    public class IntHolder : MonoBehaviour
    {
        public int variable;
        public int Variable
        {
            get { return variable; }
            set { variable = value; }
        }
#if !UNITY_EDITOR
        public IntHolder(IntPtr ptr) : base(ptr) { }
#endif
    }
}
