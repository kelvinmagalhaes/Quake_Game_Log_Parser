using Xunit;
using Quake_Game_Log.Source.Tools;

namespace Quake_Game_Log_Tests
{
    public class AnalysisTest
    {
        [Fact]
        public void AnalysisGameValidTest()
        {
            //Arrange
            bool result;
            //Act
            result = Analysis.AnalysisGame(19,21); // I know this round is valid
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void AnalysisGameNotValidTest()
        {
            //Arrange
            bool result;
            //Act
            result = Analysis.AnalysisGame(1, 21); // I know this round is not valid
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void AnalysisGameFileExcepctionTest()
        {
            //Arrange
            bool result;
            //Act
            result = Analysis.AnalysisGame(100, 21); // I know this round is not exists 
            //Assert
            Assert.False(result);
        }

    }
}
