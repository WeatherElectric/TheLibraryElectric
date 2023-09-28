using System;
using UltEvents;
using UnityEngine;

namespace TheLibraryElectric.Misc
{
    [AddComponentMenu("The Library Electric/Misc/Invoke If Lib Installed")]
    public class InvokeIfLibInstalled : ElectricBehaviour
    {
        public UltEvent ifInstalled;
        public void Awake()
        {
            ifInstalled.Invoke();
        }
    }
}
