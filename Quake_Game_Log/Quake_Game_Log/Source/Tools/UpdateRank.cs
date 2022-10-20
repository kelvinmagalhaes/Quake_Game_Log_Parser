using System.IO;
using System.Linq;
using Quake_Game_Log.Source.Base;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Quake_Game_Log.Source.Tools
{
    /// <summary>
    /// Update rank class
    /// </summary>
    public class UpdateRank
    {
        /// <summary>
        /// Update the rank, if the player was killed by <world> the his score receives -1 kill.
        /// </summary>
        /// <param name="i">Round</param>
        /// <param name="playerList">Players list</param>
        /// <param name="rankPlayers">Rank Players list</param>
        public static void FinalRank(int i,ref List<string> playerList, ref List<Rank> rankPlayers)
        {
            string world = @"<world>";
            string line;
            using (StreamReader r = File.OpenText(".\\Log_Rounds\\Round" + i + ".txt"))
            {
                while ((line = r.ReadLine()) != null)
                {
                    //Analysis world kills and update the scores
                    if (Regex.IsMatch(line, world))
                    {
                        foreach (var item in playerList)
                        {
                            if (line.Contains(item))
                            {
                                var x = rankPlayers.FindIndex(x => x.Name.Equals(item));
                                rankPlayers[x].Score = rankPlayers[x].Score - 1;
                            }
                        }
                    }
                }

                //Order rank
                rankPlayers = rankPlayers.OrderByDescending(x => x.Score).ToList();
            }
        }
    }
}
