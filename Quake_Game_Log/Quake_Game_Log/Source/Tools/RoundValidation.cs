using Quake_Game_Log.Source.Base;
using System.Collections.Generic;

namespace Quake_Game_Log.Source.Tools
{
    /// <summary>
    /// Round Validation
    /// </summary>
    public class RoundValidation
    {
        /// <summary>
        /// Check the round is valid or not
        /// </summary>
        /// <param name="rankPlayers">Rank players list</param>
        /// <returns>returns true if the rank is not null.</returns>
        public static bool Validation(ref List<Rank>rankPlayers)
        {
            if (rankPlayers.Count > 0)
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
