using MelonLoader;

namespace TheLibraryElectric
{
    public class Main : MelonMod
    {
        internal const string Name = "The Library Electric";
        internal const string Description = "Condemn him to the IL2CPP.";
        internal const string Author = "CarrionAndOn";
        internal const string Company = "Weather Electric";
        internal const string Version = "0.0.0";
        internal const string DownloadLink = "null";

        public override void OnEarlyInitializeMelon()
        {
            FieldInjector.SerialisationHandler.Inject<KinematicRB>();
            FieldInjector.SerialisationHandler.Inject<DoNotFreeze>();
        }
        public override void OnInitializeMelon()
        {
            FieldInjector.SerialisationHandler.Inject<CubeBreak>();
            FieldInjector.SerialisationHandler.Inject<FreezeRigidbodies>();
            FieldInjector.SerialisationHandler.Inject<DestroyOnCollision>();
        }
    }
}