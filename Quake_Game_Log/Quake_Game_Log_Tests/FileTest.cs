using Xunit;
using Quake_Game_Log.Source.Tools;

namespace Quake_Game_Log_Tests
{
    public class FileTest
    {
        /// <summary>
        /// Can find the file log?
        /// </summary>
        [Fact]
        public void Find_File()
        {
            //Arrange
            int find;
            //Act
            find = FileTools.FindFile();
            //Assert
            Assert.NotEqual(0, find);
        }
    }
}
