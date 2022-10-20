using Quake_Game_Log.Source.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Quake_Game_Log.Source.Tools
{
    public class UpdateRank
    {
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
