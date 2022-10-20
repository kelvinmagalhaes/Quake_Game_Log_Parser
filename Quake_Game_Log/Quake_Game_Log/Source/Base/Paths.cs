namespace Quake_Game_Log.Source.Base
{
    /// <summary>
    /// Paths class
    /// </summary>
    public class Paths
    {
        /// <summary>
        /// property RoundParse
        /// </summary>
        private static string RoundParse { get;  set; }
    
        /// <summary>
        /// Proper Analysis
        /// </summary>
        private static string Analysis { get;  set; }
        
        /// <summary>
        /// Property Quake
        /// </summary>
        private static string Quake { get; set; }

        /// <summary>
        /// Define the path to round files
        /// </summary>
        /// <returns>returns the round path</returns>
        public static string RoundPath()
        {
            return RoundParse = ".\\Log_Rounds\\Round";
        }

        /// <summary>
        /// Define the path to analysis files
        /// </summary>
        /// <returns>returns the analysis path</returns>
        public static string AnalysisPath()
        {
            return Analysis = ".\\Log_Rounds\\Analysis\\AnalysisRound";
        }

        /// <summary>
        /// Define the path to quake log
        /// </summary>
        /// <returns>returns the quake log path</returns>
        public static string QuakePath()
        {
            return Quake = "qgames.log";
        }
    }
}
