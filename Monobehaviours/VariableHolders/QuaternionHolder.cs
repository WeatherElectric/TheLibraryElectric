using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TheLibraryElectric.VariableHolders
{
    public class QuaternionHolder : MonoBehaviour
    {
        public Quaternion variable;
        public Quaternion Variable
        {
            get { return variable; }
            set { variable = value; }
        }
#if !UNITY_EDITOR
        public QuaternionHolder(IntPtr ptr) : base(ptr) { }
#endif
    }
}
