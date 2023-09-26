using System.Threading;
using BoneLib;
using MelonLoader;
using TheLibraryElectric.Patching;
using UnityEngine;

namespace TheLibraryElectric
{
    public class Main : MelonMod
    {
        internal const string Name = "The Library Electric";
        internal const string Description = "See how IL2CPP breaks the mod.";
        internal const string Author = "CarrionAndOn + BugoBug";
        internal const string Company = "Weather Electric";
        internal const string Version = "1.4.0";
        internal const string DownloadLink = "https://bonelab.thunderstore.io/package/CarrionAndOn/TheLibraryElectric/";
        public override void OnInitializeMelon()
        {
            ModConsole.Setup(LoggerInstance);
            Preferences.Setup();
            FieldInjection.Inject();
            ModConsole.Msg("Doing Jevillib stuff", LoggingMode.DEBUG);
        }
        public override void OnLateInitializeMelon()
        {
            var initializationThread = new Thread(new ThreadStart(async () =>
            {
                await ModStats.IncrementLaunch();
                if (!PlayerPrefs.HasKey("TheLibraryElectricLaunch"))
                    await ModStats.IncrementUser();
                PlayerPrefs.TrySetInt("TheLibraryElectricLaunch", 1);
            }));

            initializationThread.Start();
        }
    }
}