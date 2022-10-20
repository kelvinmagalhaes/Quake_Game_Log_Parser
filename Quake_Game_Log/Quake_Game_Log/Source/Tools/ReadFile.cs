using System.IO;
using Quake_Game_Log.Source.Base;
using System.Collections.Generic;

namespace Quake_Game_Log.Source.Tools
{
    /// <summary>
    /// Read class file
    /// </summary>
    public class ReadFile
    {
        /// <summary>
        /// Read function
        /// </summary>
        /// <param name="r">Text of the log</param>
        /// <param name="line">one line of text log</param>
        /// <param name="playerList">Player list</param>
        /// <param name="rankPlayers">rank players list</param>
        /// <param name="totalKills">total kills</param>
        /// <param name="groupy">means of death</param>
        public static void Read(StreamReader r, string line, ref List<string> playerList, ref List<Rank> rankPlayers, ref int totalKills, ref List<string> groupy)
        {
            while ((line = r.ReadLine()) != null)
            {
                ExtractPlayers.Players(line, ref playerList);
                ExtractScore.Score(line, ref rankPlayers);
                ExtractTotalKills.TotalKills(line, ref totalKills, ref groupy);
            }
        }
    }
}
