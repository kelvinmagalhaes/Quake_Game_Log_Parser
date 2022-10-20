using System.IO;
using Quake_Game_Log.Source.Base;
using System.Collections.Generic;

namespace Quake_Game_Log.Source.Tools
{
    public class Analysis
    {
        /// <summary>
        /// Analysis round function
        /// </summary>
        /// <param name="i">receives the number of round.</param>
        public static void AnalysisGame(int i)
        {
            using (StreamReader r = File.OpenText(".\\Log_Rounds\\Round" + i + ".txt"))
            {
                string line;
                int totalKills = 0;
                List<string> playerList = new List<string>(); //Player List
                List<string> scoreList = new List<string>();  //Score Players List
                List<string> groupy = new List<string>();     //Auxiliar variable to Means Death List
                List<Deaths> meanDeaths = new List<Deaths>(); // Means Death List
                List<Rank> rankPlayers = new List<Rank>();    //Rank Players

                while ((line = r.ReadLine()) != null)
                {
                    ExtractPlayers.Players(line, ref playerList);
                    ExtractScore.Score(line, ref rankPlayers);
                    ExtractTotalKills.TotalKills(line, ref totalKills, ref groupy);
                }
                bool isValid = RoundValidation.Validation(ref rankPlayers);
                
                if (isValid)
                {
                    UpdateRank.FinalRank(i, ref playerList, ref rankPlayers);
                    ExtractMeansDeath.MeansDeathRound(ref groupy, ref meanDeaths);
                    Quake obj = ObjMount.QuakeObjMount(i, totalKills, ref playerList, ref rankPlayers, ref meanDeaths);
                    FileTools.CreateJsonFile(obj, i);
                }
            }
        }
    }
}
