using Xunit;
using Quake_Game_Log.Source.Tools;
using Quake_Game_Log.Source.Base;
using System.Collections.Generic;
using System.IO;

namespace Quake_Game_Log_Tests
{
    public class AnalysisTest
    {
        string line = null;
        int totalKills = 0;
        List<string> playerList = new List<string>(); //Player List
        List<string> scoreList = new List<string>();  //Score Players List
        List<string> groupy = new List<string>();     //Auxiliar variable to Means Death List
        List<Deaths> meanDeaths = new List<Deaths>(); // Means Death List
        List<Rank> rankPlayers = new List<Rank>();    //Rank Players

        /// <summary>
        /// Delete files
        /// </summary>
        [Fact]
        public void DeleteFileSucessTest()
        {
            //Arrange
            bool result;
            //Act
            result = FileTools.DeleteFiles();
            //Assert
            Assert.True(result);
        }

        /// <summary>
        /// Can find the file log?
        /// </summary>
        [Fact]
        public void FindFileSucessTest()
        {
            //Arrange
            int result;
            //Act
            result = FileTools.FindFile();
            //Assert
            Assert.NotEqual(0, result);
        }

        /// <summary>
        /// Check if the round selected is valid 
        /// </summary>
        [Fact]
        public void AnalysisGameValidTest()
        {
            //Arrange
            bool result;
            //Act
            FileTools.DeleteFiles();
            FileTools.FindFile();
            result = Analysis.AnalysisGame(19,21); // I know this round is valid
            //Assert
            Assert.True(result);
        }

        /// <summary>
        /// Check if the round selected is not valid 
        /// </summary>
        [Fact]
        public void AnalysisGameNotValidTest()
        {
            //Arrange
            bool result;
            //Act
            FileTools.DeleteFiles();
            FileTools.FindFile();
            result = Analysis.AnalysisGame(1, 21); // I know this round is not valid
            //Assert
            Assert.False(result);
        }

        /// <summary>
        /// Check if the round exists
        /// </summary>
        [Fact]
        public void AnalysisGameFileExcepctionTest()
        {
            //Arrange
            bool result;
            //Act
            FileTools.DeleteFiles();
            FileTools.FindFile(); 
            result = Analysis.AnalysisGame(100, 21); // I know this round is not exists 
            //Assert
            Assert.False(result);
        }


        /// <summary>
        /// Check any property is null
        /// </summary>
        [Fact]
        public void NotNullTest()
        {
            //Arrange
            bool result;
            FileTools.DeleteFiles();
            FileTools.FindFile();
            using (StreamReader r = File.OpenText(".\\Log_Rounds\\Round19.txt"))
            {
                //Act
                ReadFile.Read(r, line, ref playerList, ref rankPlayers, ref totalKills, ref groupy);
                result = ((playerList.Count > 0) && (rankPlayers.Count > 0) && (totalKills > 0) && (groupy.Count > 0));
                //Assert
                Assert.True(result);
            }
        }

    }
}
