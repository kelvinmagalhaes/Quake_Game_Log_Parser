using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Quake_Game_Log.Source.Tools
{
    public class ExtractPlayers
    {
        /// <summary>
        /// Extract the players function. Receives the ref playerList and fill
        /// </summary>
        /// <param name="line"></param>
        /// <param name="playerList">pointer to indicate the players in the round.</param>
        public static bool Players(string line, ref List<string> playerList)
        {
            string players = @"client:";
            if (Regex.Match(line, players).Success)
            {
                int start = line.IndexOf(players);
                playerList.Add(line.Substring(start + 10));
            }

            if (playerList.Count > 0)
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
