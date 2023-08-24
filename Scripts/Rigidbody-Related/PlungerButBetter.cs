using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TheLibraryElectric.Scripts.Rigidbody_Related
{
    public class PlungerButBetter : MonoBehaviour
    {
        [Flags]
        public enum localAxisLimit
        {
            X = 1 << 0, // 1
            Y = 1 << 1, // 2
            Z = 1 << 2  // 4
        }

        public localAxisLimit selectedLimits;

    }

}

