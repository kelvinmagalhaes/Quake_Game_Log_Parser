using Quake_Game_Log.Source.Base;
using System.Collections.Generic;

namespace Quake_Game_Log.Source.Tools
{
    public class RoundValidation
    {
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
