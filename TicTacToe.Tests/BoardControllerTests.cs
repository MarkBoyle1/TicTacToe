using System;
using Xunit;

namespace TicTacToe.Tests
{
    public class BoardTests
    {
        private BoardFactory _boardFactory = new BoardFactory();

        [Fact]
        public void when_SizeOfBoardEqualsThree_when_GenerateInitialBoard_then_RowLengthEqualsThree()
        {
            Board board = _boardFactory.GenerateEmptyBoard(3);

            Assert.Equal(3, board.GetRow(0).Length);
        }
        
        [Fact]
        public void when_UpdateBoard_and_coordinatesEqualZeroAndZero_then_update_TopLeftCorner()
        {
            Coordinates coordinates = new Coordinates(0, 0);
            Board board = _boardFactory.GenerateEmptyBoard(3);
            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", coordinates, board);
            
            Assert.Equal("x", updatedBoard.GetPoint(0,0));
        }
        
        [Fact]
        public void when_SizeOfBoardEqualsFive_when_GenerateInitialBoard_then_RowLengthEqualsFive()
        {
            Board board = _boardFactory.GenerateEmptyBoard(5);

            Assert.Equal(5, board.GetRow(0).Length);
        }
    }
}