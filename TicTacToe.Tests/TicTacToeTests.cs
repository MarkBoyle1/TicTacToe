using System;
using Xunit;

namespace TicTacToe.Tests
{
    public class TicTacToeTests
    {
        private Board _board = new Board();
        
        [Fact]
        public void when_GenerateBoard_then_return_stringArrayOfArrays()
        {
            string[][] expectedBoard = new string[][]
            {
                new string[] {".", ".", "."},
                new string[] {".", ".", "."},
                new string[] {".", ".", "."},
            };

            string[][] board = _board.GenerateBoard();
            
            Assert.Equal(expectedBoard, board);
        }
    }
}