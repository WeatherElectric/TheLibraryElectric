using System;
using UnityEngine;

namespace TheLibraryElectric.Groups
{
    public class GroupProxy : MonoBehaviour
    {
        public void TriggerGroupByID(string id)
        {
            if(id == "null")
            {
                return;
            }
            foreach(GroupIdentifier identifier in FindObjectsOfType<GroupIdentifier>())
            {
                if(identifier.currectGroupID == id)
                {
                    identifier.onGroupTrigger.Invoke();
                }
            }
        }
        public void AddObjectToGroup(GameObject obj, string id)
        {
            if (id == "null")
            {
                return;
            }
            GroupIdentifier identifier = obj.GetComponent<GroupIdentifier>();
            if(identifier != null)
            {
                identifier.currectGroupID = id;
                identifier.onGroupJoin.Invoke();
            }
        }
        public string GetGroupFromObject(GameObject obj)
        {
            GroupIdentifier groupIdentifier = obj.GetComponent<GroupIdentifier>();
            if(groupIdentifier != null)
            {
                return groupIdentifier.currectGroupID;
            }
            return "null";
        }
        public bool DoesGroupExist(string id)
        {
            foreach (GroupIdentifier identifier in FindObjectsOfType<GroupIdentifier>())
            {
                if(identifier.currectGroupID == id)
                {
                    return true;
                }
            }
            return false;
        }
#if !UNITY_EDITOR
        public GroupProxy(IntPtr ptr) : base(ptr) { }
#endif
    }
}
