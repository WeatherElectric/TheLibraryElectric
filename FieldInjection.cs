using FieldInjector;
using TheLibraryElectric.Markers;
using TheLibraryElectric.Misc;
using TheLibraryElectric.PlayerUtil;
using TheLibraryElectric.Rigidbodies;
using TheLibraryElectric.Signals;
using TheLibraryElectric.Water;

namespace TheLibraryElectric
{
    internal static class FieldInjection
    {
        public static void Inject()
        {
            ModConsole.Msg("Injecting the fields with the fieldinjector which injects fields, crazy isnt it", LoggingMode.DEBUG);
            SerialisationHandler.Inject<DoNotFreeze>();
            ModConsole.Msg("Hopefully injected DoNotFreeze", LoggingMode.DEBUG);
            SerialisationHandler.Inject<DoNotDestroy>();
            ModConsole.Msg("Hopefully injected DoNotDestroy", LoggingMode.DEBUG);
            SerialisationHandler.Inject<RecieveSignal>();
            ModConsole.Msg("Hopefully injected RecieveSignal", LoggingMode.DEBUG);
            SerialisationHandler.Inject<SendSignal>();
            ModConsole.Msg("Hopefully injected SendSignal", LoggingMode.DEBUG);
            SerialisationHandler.Inject<RigManagerControl>();
            ModConsole.Msg("Hopefully injected RigManagerControl", LoggingMode.DEBUG);
            SerialisationHandler.Inject<FreezeRigidbodies>();
            ModConsole.Msg("Hopefully injected FreezeRigidbodies", LoggingMode.DEBUG);
            SerialisationHandler.Inject<DestroyOnCollision>();
            ModConsole.Msg("Hopefully injected DestroyOnCollision", LoggingMode.DEBUG);
            SerialisationHandler.Inject<ExplodeButBetter>();
            ModConsole.Msg("Hopefully injected ExplodeButBetter", LoggingMode.DEBUG);
            SerialisationHandler.Inject<TimescaleController>();
            ModConsole.Msg("Hopefully injected TimescaleController", LoggingMode.DEBUG);
            SerialisationHandler.Inject<UpdateTMP>();
            ModConsole.Msg("Hopefully injected UpdateTMP", LoggingMode.DEBUG);
            SerialisationHandler.Inject<VoidCounterObject>();
            ModConsole.Msg("Hopefully injected VoidCounterObject", LoggingMode.DEBUG);
            SerialisationHandler.Inject<RBGravityManager>();
            ModConsole.Msg("Hopefully injected RBGravityManager", LoggingMode.DEBUG);
            SerialisationHandler.Inject<GravityChamber>();
            ModConsole.Msg("Hopefully injected GravityChamber", LoggingMode.DEBUG);
            SerialisationHandler.Inject<RagdollZone>();
            ModConsole.Msg("Hopefully injected RagdollZone", LoggingMode.DEBUG);
            SerialisationHandler.Inject<ForceZone>();
            ModConsole.Msg("Hopefully injected ForceZone", LoggingMode.DEBUG);
            SerialisationHandler.Inject<SpawnOnTriggerEnter>();
            ModConsole.Msg("Hopefully injected SpawnOnTriggerEnter", LoggingMode.DEBUG);
            SerialisationHandler.Inject<SpawnCrateOnTriggerEnter>();
            ModConsole.Msg("Hopefully injected SpawnCrateOnTriggerEnter", LoggingMode.DEBUG);
            SerialisationHandler.Inject<DespawnPooledObject>();
            ModConsole.Msg("Hopefully injected DespawnPooledObject", LoggingMode.DEBUG);
            SerialisationHandler.Inject<RandomAudioPlayer>();
            ModConsole.Msg("Hopefully injected RandomAudioPlayer", LoggingMode.DEBUG);
            SerialisationHandler.Inject<IgnoreRigidbody>();
            ModConsole.Msg("Hopefully injected IgnoreRigidbody", LoggingMode.DEBUG);
            SerialisationHandler.Inject<RbBuoyancyManager>();
            ModConsole.Msg("Hopefully injected RbBuoyancyManager", LoggingMode.DEBUG);
            SerialisationHandler.Inject<WaterZone>();
            ModConsole.Msg("Hopefully injected WaterZone", LoggingMode.DEBUG);
            SerialisationHandler.Inject<ItemThrower>();
            ModConsole.Msg("Hopefully injected ItemThrower", LoggingMode.DEBUG);
            SerialisationHandler.Inject<SignalTrigger>();
            ModConsole.Msg("Hopefully injected SignalTrigger", LoggingMode.DEBUG);
            SerialisationHandler.Inject<SignalTriggerer>();
            ModConsole.Msg("Hopefully injected SignalTriggerer", LoggingMode.DEBUG);
            SerialisationHandler.Inject<HandMonitor>();
            ModConsole.Msg("Hopefully injected HandMonitor", LoggingMode.DEBUG);
            SerialisationHandler.Inject<SwimmingController>();
            ModConsole.Msg("Hopefully injected SwimmingController", LoggingMode.DEBUG);
            SerialisationHandler.Inject<InvokeIfLibInstalled>();
            ModConsole.Msg("Hopefully injected InvokeIfLibInstalled", LoggingMode.DEBUG);
            SerialisationHandler.Inject<DrowningManager>();
            ModConsole.Msg("Hopefully injected DrowningManager", LoggingMode.DEBUG);
            SerialisationHandler.Inject<RagdollOnCollide>();
            ModConsole.Msg("Hopefully injected RagdollOnCollide", LoggingMode.DEBUG);
            SerialisationHandler.Inject<PreventNimbus>();
            ModConsole.Msg("Hopefully injected PreventNimbus", LoggingMode.DEBUG);
            ModConsole.Msg("All fields are probably injected. I can't tell since this isn't async so I can't slap a bool on it.", LoggingMode.DEBUG);
        }
    }
}