using System;

using UltEvents;
using UnityEngine;

namespace TheLibraryElectric.Groups
{
    public class GroupIdentifier : MonoBehaviour
    {
        public UltEvent onGroupJoin;
        public UltEvent onGroupTrigger;
        public string currectGroupID { get; set; }

        void Update()
        {
            if(currectGroupID == "null")
            {
                currectGroupID = null;
            }
        }
#if !UNITY_EDITOR
        public GroupIdentifier(IntPtr ptr) : base(ptr) { }
#endif
    }
}
