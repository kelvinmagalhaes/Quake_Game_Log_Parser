using Quake_Game_Log.Source.Base;
using System.Collections.Generic;

namespace Quake_Game_Log.Source.Tools
{
    public class ObjMount
    {
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
