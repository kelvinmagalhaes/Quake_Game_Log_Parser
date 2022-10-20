using System;
using System.IO;
using Nancy.Json;
using System.Linq;
using Quake_Game_Log.Source.Base;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Quake_Game_Log.Source.Tools
{
    public class FileTools
    {
        /// <summary>
        /// Find log file Funcion.
        /// </summary>
        /// <returns>Returns number of rounds.</returns>
        public static int FindFile()
        {
            using (StreamReader r = File.OpenText("qgames.log"))
            {
                int count = 1;
                if (r.ReadLine() != null)
                {
                    count = logParse(r);
                    return count;
                }
                return 0;
            }
        }

        /// <summary>
        /// Delete files Funcion before a new execution.
        /// </summary>
        public static void DeleteFiles()
        {
            int lenght = FindFile();
            for (int i = 1; i <= lenght; i++)
            {
                if (File.Exists(".\\Log_Rounds\\Round" + i + ".txt"))
                {
                    File.Delete(".\\Log_Rounds\\Round" + i + ".txt");
                }
                if (File.Exists(".\\Log_Rounds\\AnalysisRound" + i + ".json"))
                {
                    File.Delete(".\\Log_Rounds\\AnalysisRound" + i + ".json");
                }
            }
        }

        /// <summary>
        /// Parse function
        /// </summary>
        /// <param name="r">r is the text of log</param>
        /// <returns>returns the number of rounds</returns>
        public static int logParse(StreamReader r)
        {
            string def = @"InitGame:";
            string line;
            int count = 0;

            while ((line = r.ReadLine()) != null)
            {
                if (Regex.Match(line, def).Success)
                {
                    count++;
                    continue;
                }
                GameLog(line, count);
            }
            return count;
        }

        /// <summary>
        /// Create a file for receives the information of the round.
        /// </summary>
        /// <param name="line">line-per-line of log file</param>
        /// <param name="i">number of the round.</param>
        public static void GameLog(string line, int i)
        {
            using (StreamWriter w = File.AppendText(".\\Log_Rounds\\Round" + i + ".txt"))
            {
                Log(line, w);
            }
        }

        /// <summary>
        /// Write infos about round
        /// </summary>
        /// <param name="logMessage">Message each line</param>
        /// <param name="w">TextWriter object</param>
        public static void Log(string logMessage, TextWriter w)
        {
            w.WriteLine($"{logMessage}");
        }

        /// <summary>
        /// Analysis round function
        /// </summary>
        /// <param name="i">receives the number of round.</param>
        public static void AnalysisGame(int i)
        {
            using (StreamReader r = File.OpenText(".\\Log_Rounds\\Round" + i + ".txt"))
            {
                string line;
                string line2;
                int totalKills = 0;
                string world = @"<world>";
                List<string> playerList = new List<string>();
                List<string> scoreList = new List<string>();
                List<string> groupy = new List<string>();
                List<Deaths> meanDeaths = new List<Deaths>();
                List<Rank> rankPlayers = new List<Rank>();
                
                while ((line = r.ReadLine()) != null)
                {
                    Players(line, ref playerList);
                    Score(line, ref rankPlayers);
                    TotalKills(line, ref totalKills, ref groupy);
                    
                }

                UpdateRank.FinalRank(i, ref playerList, ref rankPlayers);

                var aux = new HashSet<string>(groupy);
                foreach (var item in aux)
                {
                    meanDeaths.Add(new Deaths { Mean = item, value = groupy.FindAll(s => s.Equals(item)).Count });
                }

                meanDeaths = meanDeaths.OrderByDescending(x => x.value).ToList();

                var obj = new Quake
                {
                    Game = i,
                    TotalKills = totalKills,
                    playerList = playerList,
                    rankList = rankPlayers,
                    meanDeathList = meanDeaths,
                };

                if (obj.playerList.Count() > 0 && obj.rankList.Count()>0)
                {
                    var json = new JavaScriptSerializer().Serialize(obj);
                    File.WriteAllText(@".\\Log_Rounds\\AnalysisRound" + i + ".json", json);
                    Console.WriteLine(json);
                }
                else
                {
                    Console.WriteLine("Round "+i+" not ended.");
                }
            }
        }

        /// <summary>
        /// Function to extract the total number of deaths. Receives the refs and fill.
        /// </summary>
        /// <param name="line">receives each line of the log</param>
        /// <param name="totalKills">pointer to indicate the total value.</param>
        /// <param name="groupy">pointer to indicate the means death in the round. </param>
        private static void TotalKills(string line, ref int totalKills, ref List<string> groupy)
        {
            string killed = @"killed";
            
            string meansDeath = @"MOD_UNKNOWN|MOD_SHOTGUN|MOD_GAUNTLET|MOD_MACHINEGUN|MOD_GRENADE|MOD_GRENADE_SPLASH|MOD_ROCKET|MOD_ROCKET_SPLASH|MOD_PLASMA|MOD_PLASMA_SPLASH|MOD_RAILGUN|MOD_LIGHTNING|MOD_BFG|MOD_BFG_SPLASH|MOD_WATER|MOD_SLIME|MOD_LAVA|MOD_CRUSH|MOD_TELEFRAG|MOD_FALLING|MOD_SUICIDE|MOD_TARGET_LASER|MOD_TRIGGER_HURT|MISSIONPACK|MOD_NAIL|MOD_CHAINGUN|MOD_PROXIMITY_MINE|MOD_KAMIKAZE|MOD_JUICED|MOD_GRAPPLE";

            if (Regex.IsMatch(line, killed))
            {
                totalKills++;
            }

            if (Regex.IsMatch(line, meansDeath))
            {
                groupy.Add(Regex.Match(line, meansDeath).Value);
            }   
            
        }

        /// <summary>
        /// Calculate the score funcion. Receives the rankPlayers and fill
        /// </summary>
        /// <param name="line">receives each line of the log</param>
        /// <param name="rankPlayers">pointer to indicate the rank players in the round.</param>
        private static void Score(string line, ref List<Rank> rankPlayers)
        {
            string score = @"score";
            string players = @"client:";

            List<string> playerScore = new List<string>();
            if (Regex.Match(line, score).Success)
            {
                int start = line.IndexOf(players);
                int start_score = line.IndexOf(score);
                //Console.WriteLine(line.Substring(start + 10) + ":" + line.Substring(start_score + 6, 3));
                rankPlayers.Add(new Rank { Name = line.Substring(start + 10), Score = (Int32.Parse(line.Substring(start_score + 6, 3))) });
            }
            
        }

        /// <summary>
        /// Extract the players function. Receives the ref playerList and fill
        /// </summary>
        /// <param name="line"></param>
        /// <param name="playerList">pointer to indicate the players in the round.</param>
        private static void Players(string line, ref List<string> playerList)
        {
            string players = @"client:";
            if (Regex.Match(line, players).Success)
            {
                int start = line.IndexOf(players);

                //Console.WriteLine(line.Substring(start + 10));
                playerList.Add(line.Substring(start + 10));
            }
        }
    }
}
