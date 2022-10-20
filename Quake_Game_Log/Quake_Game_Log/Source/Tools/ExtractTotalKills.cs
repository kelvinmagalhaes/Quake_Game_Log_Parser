using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Quake_Game_Log.Source.Tools
{
    /// <summary>
    /// Extract total kills class
    /// </summary>
    public class ExtractTotalKills
    {
        /// <summary>
        /// Function to extract the total number of deaths. Receives the refs and fill.
        /// </summary>
        /// <param name="line">receives each line of the log</param>
        /// <param name="totalKills">pointer to indicate the total value.</param>
        /// <param name="groupy">pointer to indicate the means death in the round. </param>
        public static bool TotalKills(string line, ref int totalKills, ref List<string> groupy)
        {
            string killed = @"killed";

            string meansDeath = @"MOD_UNKNOWN|MOD_SHOTGUN|MOD_GAUNTLET|MOD_MACHINEGUN|MOD_GRENADE|MOD_GRENADE_SPLASH|MOD_ROCKET|MOD_ROCKET_SPLASH|MOD_PLASMA|MOD_PLASMA_SPLASH|MOD_RAILGUN|MOD_LIGHTNING|MOD_BFG|MOD_BFG_SPLASH|MOD_WATER|MOD_SLIME|MOD_LAVA|MOD_CRUSH|MOD_TELEFRAG|MOD_FALLING|MOD_SUICIDE|MOD_TARGET_LASER|MOD_TRIGGER_HURT|MISSIONPACK|MOD_NAIL|MOD_CHAINGUN|MOD_PROXIMITY_MINE|MOD_KAMIKAZE|MOD_JUICED|MOD_GRAPPLE";

            if (Regex.IsMatch(line, killed))
            {
                totalKills++;
            }

            if (Regex.IsMatch(line, meansDeath))
            {
                groupy.Add(Regex.Match(line, meansDeath).Value);
            }

            if (groupy.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
