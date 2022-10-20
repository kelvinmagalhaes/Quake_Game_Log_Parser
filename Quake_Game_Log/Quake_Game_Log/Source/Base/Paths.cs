namespace Quake_Game_Log.Source.Base
{
    public class Paths
    {
        private static string RoundParse { get;  set; }
        private static string Analysis { get;  set; }
        private static string Quake { get; set; }

        public static string RoundPath()
        {
            return RoundParse = ".\\Log_Rounds\\Round";
        }
        public static string AnalysisPath()
        {
            return Analysis = ".\\Log_Rounds\\AnalysisRound";
        }

        public static string QuakePath()
        {
            return Quake = "qgames.log";
        }
    }
}
