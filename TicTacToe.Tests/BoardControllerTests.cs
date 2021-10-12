using System;
using Xunit;

namespace TicTacToe.Tests
{
    public class BoardTests
    {
        private Board _board = new Board(3);
        
        // [Fact]
        // public void when_GenerateBoard_then_return_stringArrayOfArrays()
        // {
        //     string[][] expectedBoard = new string[][]
        //     {
        //         new string[] {".", ".", "."},
        //         new string[] {".", ".", "."},
        //         new string[] {".", ".", "."},
        //     };
        //
        //     Board board = _board.GenerateBoard(_board);
        //     
        //     Assert.Equal(expectedBoard, board._board);
        // }
        
        [Fact]
        public void when_UpdateBoard_and_coordinatesEqualOneAndOne_then_update_TopLeftCorner()
        {
            Board board = _board.GenerateBoard(_board);

            board = board.UpdateBoard("x", 0, 0, board);
            
            Assert.Equal("x", board.GetPoint(0,0));
        }
    }
}