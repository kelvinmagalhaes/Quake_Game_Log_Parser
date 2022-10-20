using Quake_Game_Log.Source.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Quake_Game_Log.Source.Tools
{
    public class ReadFile
    {
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
