using System;
using BoneLib;
using SLZ.Bonelab;
using UnityEngine;

namespace TheLibraryElectric.PlayerUtil
{ 
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Player Util/Apply Rig Manager")]
#endif
    public class ApplyRigManager : MonoBehaviour
    {
#if UNITY_EDITOR
        [Header("Player Leash")]
        [Tooltip("Whether the script should apply the rig manager to the player leash script.")]
#endif
        public bool playerLeash;
        public Simple_PlayerLeasher playerLeasher;
#if UNITY_EDITOR
        [Header("Player Launch Pad")]
        [Tooltip("Whether the script should apply the rig manager to the player launch pad script.")]
#endif
        public bool playerLaunchPad;
        public PlayerLaunchPad[] playerLaunchPads;
#if UNITY_EDITOR
        [Header("Force Avatar")]
        [Tooltip("Whether the script should apply the rig manager to the force avatar script.")]
#endif
        public bool forceAvatar;
        public ForceAvatar[] forceAvatars;
#if UNITY_EDITOR
        [Header("Random Avatar")]
        [Tooltip("Whether the script should apply the rig manager to the random avatar script.")]
#endif
        public bool randomAvatar;
        public RandomAvatar[] randomAvatars;

        private void Start()
        {
            if (playerLeash)
            {
                PlayerLeash();
            }
            if (playerLaunchPad)
            {
                PlayerLaunchPad();
            }
            if (forceAvatar)
            {
                ForceAvatar();
            }
            if (randomAvatar)
            {
                RandomAvatar();
            }
        }

        private void PlayerLeash()
        {
            playerLeasher.rM = Player.rigManager;
        }
        
        private void PlayerLaunchPad()
        {
            foreach (var launchPad in playerLaunchPads)
            {
                launchPad.rigManager = Player.rigManager;
            }
        }
        
        private void ForceAvatar()
        {
            foreach (var avatar in forceAvatars)
            {
                avatar.rm = Player.rigManager;
            }
        }
        
        private void RandomAvatar()
        {
            foreach (var avatar in randomAvatars)
            {
                avatar.rm = Player.rigManager;
            }
        }
        
#if !UNITY_EDITOR
        public ApplyRigManager(IntPtr ptr) : base(ptr) { }
#endif
    }
}