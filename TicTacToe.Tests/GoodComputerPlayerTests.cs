using System.Collections.Generic;
using Moq;
using Xunit;

namespace TicTacToe.Tests
{
    public class GoodComputerPlayerTests
    {
        private BoardFactory _boardFactory = new BoardFactory();
        
        [Fact]
        public void given_winningMoveEqualsTwoZeroOnAColumn_when_GetPlayerMove_then_return_TwoZero()
        {
            Player player = new GoodComputerPlayer("TestPlayer", "x", 0);
            
            Board board = _boardFactory.GenerateEmptyBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", new Coordinates(0,0), board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", new Coordinates(1,0), updatedBoard);

            Coordinates computerMove = player.GetPlayerMove(updatedBoard1);
            
            Assert.Equal(2, computerMove.GetRow());
            Assert.Equal(0, computerMove.GetColumn());

        }
        
        [Fact]
        public void given_winningMoveEqualsZeroZeroOnARow_when_GetPlayerMove_then_return_ZeroZero()
        {
            Player player = new GoodComputerPlayer("TestPlayer", "x", 0);
            
            Board board = _boardFactory.GenerateEmptyBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", new Coordinates(0,1), board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", new Coordinates(0,2), updatedBoard);

            Coordinates computerMove = player.GetPlayerMove(updatedBoard1);
            
            Assert.Equal(0, computerMove.GetRow());
            Assert.Equal(0, computerMove.GetColumn());
        }
        
        [Fact]
        public void given_winningMoveEqualsTwoTwoOnDiagonalSlopingRight_when_GetPlayerMove_then_return_TwoTwo()
        {
            Player player = new GoodComputerPlayer("TestPlayer", "x", 0);
            
            Board board = _boardFactory.GenerateEmptyBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", new Coordinates(0,0), board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", new Coordinates(1,1), updatedBoard);

            Coordinates computerMove = player.GetPlayerMove(updatedBoard1);
            
            Assert.Equal(2, computerMove.GetRow());
            Assert.Equal(2, computerMove.GetColumn());
        }
        
        [Fact]
        public void given_winningMoveEqualsTwoZeroOnDiagonalSlopingLeft_when_GetPlayerMove_then_return_TwoZero()
        {
            Player player = new GoodComputerPlayer("TestPlayer", "x", 0);
            
            Board board = _boardFactory.GenerateEmptyBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", new Coordinates(0,2), board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", new Coordinates(1,1), updatedBoard);

            Coordinates computerMove = player.GetPlayerMove(updatedBoard1);
            
            Assert.Equal(2, computerMove.GetRow());
            Assert.Equal(0, computerMove.GetColumn());
        }
        
        [Fact]
        public void given_defendingMoveEqualsTwoZeroOnDiagonalSlopingLeft_when_GetPlayerMove_then_return_TwoZero()
        {
            Player player = new GoodComputerPlayer("TestPlayer", "x", 0);
            
            Board board = _boardFactory.GenerateEmptyBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("o", new Coordinates(0,2), board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("o", new Coordinates(1,1), updatedBoard);

            Coordinates computerMove = player.GetPlayerMove(updatedBoard1);
            
            Assert.Equal(2, computerMove.GetRow());
            Assert.Equal(0, computerMove.GetColumn());
        }
        
        [Fact]
        public void given_givenCornerIsFreeAndNoDefendingMovesRequired_when_GetPlayerMove_then_return_ZeroZero()
        {
            Player player = new GoodComputerPlayer("TestPlayer", "x", 0);
            
            Board board = _boardFactory.GenerateEmptyBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("o", new Coordinates(1,1), board);
            
            Coordinates computerMove = player.GetPlayerMove(updatedBoard);
            
            Assert.Equal(0, computerMove.GetRow());
            Assert.Equal(0, computerMove.GetColumn());
        }
        
        [Fact]
        public void given_boardIsEmpty_when_GetPlayerMove_then_return_OneOne()
        {
            Player player = new GoodComputerPlayer("TestPlayer", "x", 0);
            
            Board board = _boardFactory.GenerateEmptyBoard(3);

            Coordinates computerMove = player.GetPlayerMove(board);
            
            Assert.Equal(1, computerMove.GetRow());
            Assert.Equal(1, computerMove.GetColumn());
        }
    }
}