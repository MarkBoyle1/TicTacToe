using System.Collections.Generic;
using Moq;
using Xunit;

namespace TicTacToe.Tests
{
    public class PlayerTests
    {
        private BoardFactory _boardFactory = new BoardFactory();
        
        [Fact]
        public void given_userInputEqualsX_when_GetPlayerMarker_then_PlayerMarkerEqualsX()
        {
            List<string> testInput = new List<string>() {"x"};
            GameSetUp _gameSetUp = new GameSetUp(new TestUserInput(testInput), new Output());

            Assert.Equal("x", _gameSetUp.GetPlayerMarker("Player1"));
        }
        
        [Fact]
        public void given_playerScoreEquals0_when_IncreaseScoreByOne_then_PlayerScoreEquals1()
        {
            Player player = new HumanPlayer("Player1", "x");
            
            player.IncreaseScoreByOne();

            Assert.Equal(1, player.Score);
        }

        [Fact]
        public void given_winningMoveEqualsOneThree_when_GetCoordinate_then_return_OneThree()
        {
            Player player = new GoodComputerPlayer("TestPlayer", "x");
            
            Board board = _boardFactory.GenerateInitialBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", new Coordinates(0,0), board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", new Coordinates(1,0), updatedBoard);

            string computerMove = player.GetCoordinate(updatedBoard1);
            
            Assert.Equal("3,1", computerMove);
        }
        
        [Fact]
        public void given_winningMoveEqualsOneOne_when_GetCoordinate_then_return_OneOne()
        {
            Player player = new GoodComputerPlayer("TestPlayer", "x");
            
            Board board = _boardFactory.GenerateInitialBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", new Coordinates(0,1), board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", new Coordinates(0,2), updatedBoard);

            string computerMove = player.GetCoordinate(updatedBoard1);
            
            Assert.Equal("1,1", computerMove);
        }
        
        [Fact]
        public void given_winningMoveEqualsThreeThree_when_GetCoordinate_then_return_ThreeThree()
        {
            Player player = new GoodComputerPlayer("TestPlayer", "x");
            
            Board board = _boardFactory.GenerateInitialBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", new Coordinates(0,0), board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", new Coordinates(1,1), updatedBoard);

            string computerMove = player.GetCoordinate(updatedBoard1);
            
            Assert.Equal("3,3", computerMove);
        }
        
        [Fact]
        public void given_boardIsEmpty_when_GetCoordinate_then_return_TwoTwo()
        {
            Player player = new GoodComputerPlayer("TestPlayer", "x");
            
            Board board = _boardFactory.GenerateInitialBoard(3);

            string computerMove = player.GetCoordinate(board);
            
            Assert.Equal("2,2", computerMove);
        }
    }
}