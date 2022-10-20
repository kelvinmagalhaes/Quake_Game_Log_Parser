using Quake_Game_Log.Source.Base;
using System.Collections.Generic;

namespace Quake_Game_Log.Source.Base
{
    public class Quake
    {
        public int Game;
        public int TotalKills;
        public List<string> playerList;
        public List<Rank> rankList;
        public List<Deaths> meanDeathList;
    }
}