using MelonLoader;
using Jevil.ModStats;
using System.Threading.Tasks;

namespace TheLibraryElectric
{
    public class Main : MelonMod
    {
        internal const string Name = "The Library Electric";
        internal const string Description = "See how IL2CPP breaks the mod.";
        internal const string Author = "CarrionAndOn";
        internal const string Company = "Weather Electric";
        internal const string Version = "0.0.1";
        internal const string DownloadLink = "https://bonelab.thunderstore.io/package/CarrionAndOn/TheLibraryElectric/";
        public override void OnInitializeMelon()
        {
            ModConsole.Setup(LoggerInstance);
            Preferences.Setup();
            FieldInjector.SerialisationHandler.Inject<DoNotFreeze>();
            FieldInjector.SerialisationHandler.Inject<DoNotDestroy>();
            FieldInjector.SerialisationHandler.Inject<RecieveSignal>();
            FieldInjector.SerialisationHandler.Inject<SendSignal>();
            FieldInjector.SerialisationHandler.Inject<MrSplitter>();
            FieldInjector.SerialisationHandler.Inject<FreezeRigidbodies>();
            FieldInjector.SerialisationHandler.Inject<DestroyOnCollision>();
            FieldInjector.SerialisationHandler.Inject<ExplodeButBetter>();
            Startup();
        }
        public static async Task Startup()
        {
            const string STATS_CATEGORY = "TheLibraryElectric";
            string prefix = Jevil.Utilities.IsPlatformQuest() ? "Quest" : "PCVR";
            ModConsole.Msg($"Sending stats request for {prefix} platform launch!", LoggingMode.NORMAL);
            bool success = await StatsEntry.IncrementValueAsync(STATS_CATEGORY, prefix + "Launches");
            ModConsole.Msg($"Sending stats request for {prefix} platform launch {(success ? "succeeded" : "failed")}", LoggingMode.NORMAL);
        }
    }
}