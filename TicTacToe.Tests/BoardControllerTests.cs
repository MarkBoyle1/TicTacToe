using System;
using Xunit;

namespace TicTacToe.Tests
{
    public class BoardTests
    {
        private Board _board = new Board(3);

        [Fact]
        public void when_UpdateBoard_and_coordinatesEqualZeroAndZero_then_update_TopLeftCorner()
        {
            _board.UpdateBoard("x", 0, 0, _board);
            
            Assert.Equal("x", _board.GetPoint(0,0));
        }
    }
}