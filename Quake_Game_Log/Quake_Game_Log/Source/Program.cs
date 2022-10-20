using Quake_Game_Log.Source.Tools;
using System;

namespace Quake_Game_Log.Source
{
    class Program
    {
        static void Main(string[] args)
        {
            FileTools.DeleteFiles();
            var count  = FileTools.FindFile();
            //if (count > 0)
            //{
            //    for (int i = 1; i <= count; i++)
            //    {
            //        Console.WriteLine("It's Analysing Round " + i);
            //        FileTools.AnalysisGame(i);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Files not founded.");
            //}
            FileTools.AnalysisGame(19);
        }
    }
}
