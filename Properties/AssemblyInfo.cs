using MelonLoader;
using System.Reflection;

[assembly: AssemblyTitle(TheLibraryElectric.Main.Description)]
[assembly: AssemblyDescription(TheLibraryElectric.Main.Description)]
[assembly: AssemblyCompany(TheLibraryElectric.Main.Company)]
[assembly: AssemblyProduct(TheLibraryElectric.Main.Name)]
[assembly: AssemblyCopyright("Developed by " + TheLibraryElectric.Main.Author)]
[assembly: AssemblyTrademark(TheLibraryElectric.Main.Company)]
[assembly: AssemblyVersion(TheLibraryElectric.Main.Version)]
[assembly: AssemblyFileVersion(TheLibraryElectric.Main.Version)]
[assembly: MelonInfo(typeof(TheLibraryElectric.Main), TheLibraryElectric.Main.Name, TheLibraryElectric.Main.Version, TheLibraryElectric.Main.Author, TheLibraryElectric.Main.DownloadLink)]
[assembly: MelonColor(System.ConsoleColor.Cyan)]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("Stress Level Zero", "BONELAB")]
[assembly: MelonOptionalDependencies("JeviLib")]