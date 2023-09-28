using System;
using BoneLib;
using SLZ.Bonelab;
using SLZ.Rig;
using UnityEngine;

namespace TheLibraryElectric.PlayerUtil
{ 
    public class ApplyRigManager : MonoBehaviour
    {
        public bool playerLeash;
        public Simple_PlayerLeasher playerLeasher;
        public bool playerLaunchPad;
        public PlayerLaunchPad[] playerLaunchPads;
        public bool forceAvatar;
        public ForceAvatar[] forceAvatars;
        public bool randomAvatar;
        public RandomAvatar[] randomAvatars;

        private RigManager _rigManager;
        public void Apply()
        {
            _rigManager = Player.rigManager;
            ModConsole.Msg($"Playerleash is {playerLeash}", LoggingMode.DEBUG);
            ModConsole.Msg($"PlayerLaunchPad is {playerLaunchPad}", LoggingMode.DEBUG);
            ModConsole.Msg($"ForceAvatar is {forceAvatar}", LoggingMode.DEBUG);
            ModConsole.Msg($"RandomAvatar is {randomAvatar}", LoggingMode.DEBUG);
            if (playerLeash)
            {
                ModConsole.Msg($"Executing PlayerLeash", LoggingMode.DEBUG);
                PlayerLeash();
            }
            if (playerLaunchPad)
            {
                ModConsole.Msg($"Executing PlayerLaunchPad", LoggingMode.DEBUG);
                PlayerLaunchPad();
            }
            if (forceAvatar)
            {
                ModConsole.Msg($"Executing ForceAvatar", LoggingMode.DEBUG);
                ForceAvatar();
            }
            if (randomAvatar)
            {
                ModConsole.Msg($"Executing RandomAvatar", LoggingMode.DEBUG);
                RandomAvatar();
            }
        }

        private void PlayerLeash()
        {
            playerLeasher.rM = _rigManager;
            ModConsole.Msg($"PlayerLeasher RM is {playerLeasher.rM}", LoggingMode.DEBUG);
            playerLeasher.gameObject.SetActive(true);
        }
        
        private void PlayerLaunchPad()
        {
            foreach (var launchPad in playerLaunchPads)
            {
                launchPad.rigManager = _rigManager;
                ModConsole.Msg($"PlayerLaunchPad RM is {launchPad.rigManager}", LoggingMode.DEBUG);
                launchPad.gameObject.SetActive(true);
            }
        }
        
        private void ForceAvatar()
        {
            foreach (var avatar in forceAvatars)
            {
                ModConsole.Msg($"ForceAvatar RM is {avatar.rm}", LoggingMode.DEBUG);
                avatar.rm = _rigManager;
                avatar.gameObject.SetActive(true);
            }
        }
        
        private void RandomAvatar()
        {
            foreach (var avatar in randomAvatars)
            {
                ModConsole.Msg($"RandomAvatar RM is {avatar.rm}", LoggingMode.DEBUG);
                avatar.rm = _rigManager;
                avatar.gameObject.SetActive(true);
            }
        }
        
#if !UNITY_EDITOR
        public ApplyRigManager(IntPtr ptr) : base(ptr) { }
#endif
    }
}