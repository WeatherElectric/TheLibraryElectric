using System;
using UnityEngine;

namespace TheLibraryElectric.Water
{
    [AddComponentMenu("The Library Electric/Water/Ignore Rigidbody")]
    [RequireComponent(typeof(Rigidbody))]
    public class IgnoreRigidbody : ElectricBehaviour
    {
        public string Comment => "This must be on the same object as the rigidbody!";
    }
}