using UnityEngine;

namespace TheLibraryElectric.Markers
{
    [AddComponentMenu("The Library Electric/Markers/Do Not Freeze")]
    [RequireComponent(typeof(Rigidbody))]
    public class DoNotFreeze : ElectricBehaviour
    {
        public override string Comment => "Put this on the same object as the rigidbody!";
    }
}