using System;
using SLZ.Bonelab;
using SLZ.Rig;
using UnityEngine;

namespace TheLibraryElectric.PlayerUtil
{ 
    [AddComponentMenu("The Library Electric/Player Util/Apply Rig Manager")]
    public class ApplyRigManager : ElectricBehaviour
    {
        [Header("Player Leash")]
        [Tooltip("Should the script apply the RM to player leash?")]
        public bool playerLeash;
        public Simple_PlayerLeasher playerLeasher;
        [Header("Player LaunchPad")]
        [Tooltip("Should the script apply the RM to player launchpad?")]
        public bool playerLaunchPad;
        public PlayerLaunchPad[] playerLaunchPads;
        [Header("Force Avatar")]
        [Tooltip("Should the script apply the RM to force avatar?")]
        public bool forceAvatar;
        public ForceAvatar[] forceAvatars;
        [Header("Random Avatar")]
        [Tooltip("Should the script apply the RM to random avatar?")]
        public bool randomAvatar;
        public RandomAvatar[] randomAvatars;

        private RigManager _rigManager;
        public void Apply()
        {
            
        }

        private void PlayerLeash()
        {

        }
        
        private void PlayerLaunchPad()
        {

        }
        
        private void ForceAvatar()
        {

        }
        
        private void RandomAvatar()
        {

        }
    }
}