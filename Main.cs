using MelonLoader;

namespace TheLibraryElectric
{
    public class Main : MelonMod
    {
        internal const string Name = "The Library Electric";
        internal const string Description = "See how IL2CPP breaks the mod.";
        internal const string Author = "CarrionAndOn";
        internal const string Company = "Weather Electric";
        internal const string Version = "0.1.0";
        internal const string DownloadLink = "https://bonelab.thunderstore.io/package/CarrionAndOn/TheLibraryElectric/";
        public override void OnInitializeMelon()
        {
            ModConsole.Setup(LoggerInstance);
            Preferences.Setup();
            ModConsole.Msg("Injecting the fields with the fieldinjector which injects fields", LoggingMode.DEBUG);
            FieldInjector.SerialisationHandler.Inject<DoNotFreeze>();
            FieldInjector.SerialisationHandler.Inject<DoNotDestroy>();
            FieldInjector.SerialisationHandler.Inject<RecieveSignal>();
            FieldInjector.SerialisationHandler.Inject<SendSignal>();
            FieldInjector.SerialisationHandler.Inject<MrSplitter>();
            FieldInjector.SerialisationHandler.Inject<FreezeRigidbodies>();
            FieldInjector.SerialisationHandler.Inject<DestroyOnCollision>();
            FieldInjector.SerialisationHandler.Inject<ExplodeButBetter>();
            ModConsole.Msg("Doing Jevillib Stuff", LoggingMode.DEBUG);
            ModStats.Increment();
        }
    }
}