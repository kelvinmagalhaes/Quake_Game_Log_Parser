using System;
using System.IO;
using Nancy.Json;
using System.Linq;
using Quake_Game_Log.Source.Base;
using System.Text.RegularExpressions;

namespace Quake_Game_Log.Source.Tools
{
    public class FileTools
    {
        #region Find File
        /// <summary>
        /// Find log file Funcion.
        /// </summary>
        /// <returns>Returns number of rounds.</returns>
        public static int FindFile()
        {
            using (StreamReader r = File.OpenText(Paths.QuakePath()))
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
        #endregion

        #region Delete analysis files
        /// <summary>
        /// Delete files Funcion before a new execution.
        /// </summary>
        public static bool DeleteFiles()
        {
            int lenght = FindFile();
            for (int i = 1; i <= lenght; i++)
            {
                if (File.Exists(Paths.RoundPath() + i + ".txt"))
                {
                    File.Delete(Paths.RoundPath() + i + ".txt");
                }
                if (File.Exists(Paths.AnalysisPath() + i + ".json"))
                {
                    File.Delete(Paths.AnalysisPath() + i + ".json");
                }
            }
            if (File.Exists(Paths.RoundPath() + "1.txt"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Generate file log to each round
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
        #endregion

        #region Generate Analysis Json files
        public static void CreateJsonFile(Quake obj,int i)
        {
            if (obj.playerList.Count() > 0 && obj.rankList.Count() > 0)
            {
                var json = new JavaScriptSerializer().Serialize(obj);
                File.WriteAllText(Paths.AnalysisPath() + i + ".json", json);
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine("Round " + i + " not ended.");
            }
        }
        #endregion

    }
}
