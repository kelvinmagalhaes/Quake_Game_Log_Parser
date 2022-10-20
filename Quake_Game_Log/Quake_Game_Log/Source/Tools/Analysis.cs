using System;
using System.IO;
using Quake_Game_Log.Source.Base;
using System.Collections.Generic;

namespace Quake_Game_Log.Source.Tools
{
    /// <summary>
    /// Analisys class
    /// </summary>
    public class Analysis
    {
        /// <summary>
        /// Analysis round function
        /// </summary>
        /// <param name="i">receives the number of round.</param>
        /// <returns>True if the match is not null.</returns>
        public static bool AnalysisGame(int i, int count)
        {
            if (i <= count)
            {
                using (StreamReader r = File.OpenText(Paths.RoundPath() + i + ".txt"))
                {
                    string line = null;
                    int totalKills = 0;
                    List<string> playerList = new List<string>(); //Player List
                    List<string> scoreList = new List<string>();  //Score Players List
                    List<string> groupy = new List<string>();     //Auxiliar variable to Means Death List
                    List<Deaths> meanDeaths = new List<Deaths>(); // Means Death List
                    List<Rank> rankPlayers = new List<Rank>();    //Rank Players

                    ReadFile.Read(r, line, ref playerList, ref rankPlayers, ref totalKills, ref groupy);

                    bool isValid = RoundValidation.Validation(ref rankPlayers);

                    if (isValid)// Check if the round is valid, is valid if the score is not null.
                    {
                        UpdateRank.FinalRank(i, ref playerList, ref rankPlayers); //Update the final rank 
                        ExtractMeansDeath.MeansDeathRound(ref groupy, ref meanDeaths); // get the means death and values of the round
                        Quake obj = ObjMount.QuakeObjMount(i, totalKills, ref playerList, ref rankPlayers, ref meanDeaths); // prepare the object
                        FileTools.CreateJsonFile(obj, i); // create the json file.
                        return true;
                    }
                    else
                    {
                        Console.Write("Invalid Round.");
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
    }
}
