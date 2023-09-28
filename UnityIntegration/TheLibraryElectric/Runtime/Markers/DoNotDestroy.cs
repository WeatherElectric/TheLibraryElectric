using System;
using UnityEngine;

namespace TheLibraryElectric.Markers
{
    [AddComponentMenu("The Library Electric/Markers/Do Not Destroy")]
    public class DoNotDestroy : ElectricBehaviour
    {
        public override string Comment => "Put this on the root object!";
    }
}