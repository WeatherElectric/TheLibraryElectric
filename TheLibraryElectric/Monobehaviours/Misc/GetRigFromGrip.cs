using System;
using Il2CppSLZ.Interaction;
using Il2CppSLZ.Rig;
using UnityEngine;

namespace TheLibraryElectric.Misc
{
    public class GetRigFromGrip : MonoBehaviour
    { 
        public RigManager GetRig(Grip grip)
        {
            return grip.GetHand().GetComponentInParent<RigManager>();
        }
#if !UNITY_EDITOR
        public GetRigFromGrip(IntPtr ptr) : base(ptr) { }
#endif
    }
}
