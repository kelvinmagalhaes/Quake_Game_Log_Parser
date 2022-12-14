using System;
using Quake_Game_Log.Source.Base;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Quake_Game_Log.Source.Tools
{
    /// <summary>
    /// Extract score players class
    /// </summary>
    public class ExtractScore
    {
        /// <summary>
        /// Calculate the score funcion. Receives the rankPlayers and fill
        /// </summary>
        /// <param name="line">receives each line of the log</param>
        /// <param name="rankPlayers">pointer to indicate the rank players in the round.</param>
        public static bool Score(string line, ref List<Rank> rankPlayers)
        {
            string score = @"score";
            string players = @"client:";

            if (Regex.Match(line, score).Success)
            {
                int start = line.IndexOf(players);
                int start_score = line.IndexOf(score);
                rankPlayers.Add(new Rank { Name = line.Substring(start + 10), Score = (Int32.Parse(line.Substring(start_score + 6, 3))) });
            }

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
