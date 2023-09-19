﻿using MelonLoader;
using System;
using System.IO;

namespace TheLibraryElectricUpdater
{
    public static class BuildInfo
    {
        public const string Name = "TheLibraryElectricUpdater"; // Name of the Mod.  (MUST BE SET)
        public const string Author = "CarrionAndOn"; // Author of the Mod.  (Set as null if none)
        public const string Company = "Weather Electric"; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class Main : MelonPlugin
    {
        private MelonPreferences_Category prefsCategory = MelonPreferences.CreateCategory("TheLibraryElectricUpdater");
        private MelonPreferences_Entry<bool> offlineModePref;
        private bool isOffline => offlineModePref.Value;

        public static readonly string libraryElectricAssemblyPath = Path.Combine(MelonHandler.ModsDirectory, "TheLibraryElectric.dll");
        public static readonly string libraryElectricUpdaterAssemblyPath = Path.Combine(MelonHandler.PluginsDirectory, "TheLibraryElectricUpdater.dll");

        public static MelonLogger.Instance Logger { get; private set; }


        public override void OnPreInitialization()
        {
            Logger = LoggerInstance;

            offlineModePref = prefsCategory.CreateEntry("OfflineMode", false);
            prefsCategory.SaveToFile(false);

            LoggerInstance.Msg(isOffline ? ConsoleColor.Yellow : ConsoleColor.Green, isOffline ? "BoneLib is in OFFLINE mode" : "BoneLib is in ONLINE mode");

            if (isOffline)
            {
                if (!File.Exists(libraryElectricAssemblyPath))
                {
                    LoggerInstance.Warning("TheLibraryElectric.dll was not found in the Mods folder");
                    LoggerInstance.Warning("Download it from github or switch to ONLINE mode");
                    LoggerInstance.Warning("https://github.com/CarrionAndOn/TheLibraryElectric/releases");
                }
            }
            else
            {
                Updater.UpdateMod();
            }
        }

        public override void OnApplicationQuit()
        {
            Updater.UpdatePlugin();
        }
    }
}