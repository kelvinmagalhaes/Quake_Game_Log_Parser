using Quake_Game_Log.Source.Base;
using System.Collections.Generic;

namespace Quake_Game_Log.Source.Tools
{
    /// <summary>
    /// Mount object class
    /// </summary>
    public class ObjMount
    {
        /// <summary>
        /// Mount object
        /// </summary>
        /// <param name="i">Round</param>
        /// <param name="totalKills">Number of kills in the round</param>
        /// <param name="playerList">Players list in the round</param>
        /// <param name="rankPlayers">Rank players list of the round</param>
        /// <param name="meanDeaths">Means of deaths of the round</param>
        /// <returns>Returns the complete object ->Quake</returns>
        public static Quake QuakeObjMount(int i, int totalKills, ref List<string> playerList, ref List<Rank> rankPlayers, ref List<Deaths> meanDeaths)
        {

            var obj = new Quake
            {
                Game = i,
                TotalKills = totalKills,
                playerList = playerList,
                rankList = rankPlayers,
                meanDeathList = meanDeaths,
            };

            return obj;
        }
    }
}
