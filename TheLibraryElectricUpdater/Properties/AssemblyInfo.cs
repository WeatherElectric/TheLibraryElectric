using MelonLoader;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle(TheLibraryElectricUpdater.BuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(TheLibraryElectricUpdater.BuildInfo.Company)]
[assembly: AssemblyProduct(TheLibraryElectricUpdater.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + TheLibraryElectricUpdater.BuildInfo.Author)]
[assembly: AssemblyTrademark(TheLibraryElectricUpdater.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(TheLibraryElectricUpdater.BuildInfo.Version)]
[assembly: AssemblyFileVersion(TheLibraryElectricUpdater.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonInfo(typeof(TheLibraryElectricUpdater.Main), TheLibraryElectricUpdater.BuildInfo.Name, TheLibraryElectricUpdater.BuildInfo.Version, TheLibraryElectricUpdater.BuildInfo.Author, TheLibraryElectricUpdater.BuildInfo.DownloadLink)]


// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("Stress Level Zero", "BONELAB")]