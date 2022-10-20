using Quake_Game_Log.Source.Base;
using System.Collections.Generic;

namespace Quake_Game_Log.Source.Base
{
    /// <summary>
    /// Quake class
    /// </summary>
    public class Quake
    {
        /// <summary>
        /// Indicate the round number
        /// </summary>
        public int Game;
        
        /// <summary>
        /// Indicate the total kills of round
        /// </summary>
        public int TotalKills;
        
        /// <summary>
        /// Indicate the players in the round
        /// </summary>
        public List<string> playerList;
        
        /// <summary>
        /// Indicate the rank of players of round
        /// </summary>
        public List<Rank> rankList;
        
        /// <summary>
        /// Indicate the means of deaths of round
        /// </summary>
        public List<Deaths> meanDeathList;
    }
}