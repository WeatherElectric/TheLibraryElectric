using Jevil.ModStats;
using System.Threading.Tasks;

namespace TheLibraryElectric
{
    internal class ModStats
    {
        public static async Task IncrementLaunch()
        {
            const string STATS_CATEGORY = "TheLibraryElectric";
            string prefix = Jevil.Utilities.IsPlatformQuest() ? "Quest" : "PCVR";
            ModConsole.Msg($"Sending stats request for {prefix} platform launch!", LoggingMode.NORMAL);
            bool success = await StatsEntry.IncrementValueAsync(STATS_CATEGORY, prefix + "Launches");
            ModConsole.Msg($"Sending stats request for {prefix} platform launch {(success ? "succeeded" : "failed")}", LoggingMode.NORMAL);
        }
        public static async Task IncrementUser()
        {
            const string STATS_CATEGORY = "TheLibraryElectric";
            string prefix = Jevil.Utilities.IsPlatformQuest() ? "Quest" : "PCVR";
            ModConsole.Msg($"Sending stats request for {prefix} platform user!", LoggingMode.NORMAL);
            bool success = await StatsEntry.IncrementValueAsync(STATS_CATEGORY, prefix + "Users");
            ModConsole.Msg($"Sending stats request for {prefix} platform user {(success ? "succeeded" : "failed")}", LoggingMode.NORMAL);
        }
    }
}