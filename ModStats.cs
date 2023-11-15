using Jevil.ModStats;
using System.Threading.Tasks;
using TheLibraryElectric.Melon;

namespace TheLibraryElectric
{
    internal class ModStats
    {
        public static async Task IncrementLaunch()
        {
            const string STATS_CATEGORY = "TheLibraryElectric";
            var prefix = Jevil.Utilities.IsPlatformQuest() ? "Quest" : "PCVR";
            ModConsole.Msg($"Sending stats request for {prefix} platform launch!");
            var success = await StatsEntry.IncrementValueAsync(STATS_CATEGORY, prefix + "Launches");
            ModConsole.Msg($"Sending stats request for {prefix} platform launch {(success ? "succeeded" : "failed")}");
        }
        public static async Task IncrementUser()
        {
            const string STATS_CATEGORY = "TheLibraryElectric";
            var prefix = Jevil.Utilities.IsPlatformQuest() ? "Quest" : "PCVR";
            ModConsole.Msg($"Sending stats request for {prefix} platform user!");
            var success = await StatsEntry.IncrementValueAsync(STATS_CATEGORY, prefix + "Users");
            ModConsole.Msg($"Sending stats request for {prefix} platform user {(success ? "succeeded" : "failed")}");
        }
    }
}