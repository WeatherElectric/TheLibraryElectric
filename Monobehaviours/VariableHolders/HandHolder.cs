using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLZ.Interaction;
using UnityEngine;

namespace TheLibraryElectric.VariableHolders
{
    public class HandHolder : MonoBehaviour
    {
        public Hand variable;
        public Hand Variable
        {
            get { return variable; }
            set { variable = value; }
        }
#if !UNITY_EDITOR
        public HandHolder(IntPtr ptr) : base(ptr) { }
#endif
    }
}
