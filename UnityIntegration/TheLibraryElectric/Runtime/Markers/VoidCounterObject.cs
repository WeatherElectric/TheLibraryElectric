using System;
using UnityEngine;

namespace TheLibraryElectric.Markers
{
    [AddComponentMenu("The Library Electric/Markers/Void Counter Object")]
    [RequireComponent(typeof(Rigidbody))]
    public class VoidCounterObject : ElectricBehaviour
    {
        public override string Comment => "Put this on the same object as the rigidbody!";
        // bugo misspelled this, SLZ reference
        public bool disableDespsawnDelay;
    }
}