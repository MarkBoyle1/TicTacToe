using Xunit;

namespace TicTacToe.Tests
{
    public class BadComputerPlayerTests
    {
        private BoardFactory _boardFactory = new BoardFactory();
        
        [Fact]
        public void given_OneSpaceRemains_andPlayerIsBadComputer_when_GetPlayerMove_then_return_theLastRemainingSpace()
        {
            Player player = new BadComputerPlayer("TestPlayer", "x", 0);
            
            Board board = _boardFactory.GenerateEmptyBoard(3);
            
            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("o", new Coordinates(0, 0), board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", new Coordinates(0, 1), updatedBoard);
            Board updatedBoard2 = _boardFactory.GenerateUpdatedBoard("o", new Coordinates(0, 2), updatedBoard1);
            Board updatedBoard3 = _boardFactory.GenerateUpdatedBoard("x", new Coordinates(1, 0), updatedBoard2);
            Board updatedBoard4 = _boardFactory.GenerateUpdatedBoard("x", new Coordinates(1, 1), updatedBoard3);
            Board updatedBoard5 = _boardFactory.GenerateUpdatedBoard("o", new Coordinates(1, 2), updatedBoard4);
            Board updatedBoard6 = _boardFactory.GenerateUpdatedBoard("x", new Coordinates(2, 0), updatedBoard5);
            Board updatedBoard7 = _boardFactory.GenerateUpdatedBoard("o", new Coordinates(2, 1), updatedBoard6);
            
            Coordinates computerMove = player.GetPlayerMove(updatedBoard7);
            
            Assert.Equal(2, computerMove.GetRow());
            Assert.Equal(2, computerMove.GetColumn());
        }
    }
}