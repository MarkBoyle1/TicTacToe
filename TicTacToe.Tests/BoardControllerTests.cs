using System;
using Xunit;

namespace TicTacToe.Tests
{
    public class BoardControllerTests
    {
        private BoardController _board = new BoardController();
        
        [Fact]
        public void when_GenerateBoard_then_return_stringArrayOfArrays()
        {
            string[][] expectedBoard = new string[][]
            {
                new string[] {".", ".", "."},
                new string[] {".", ".", "."},
                new string[] {".", ".", "."},
            };

            Board board = _board.GenerateBoard();
            
            Assert.Equal(expectedBoard, board._board);
        }
        
        [Fact]
        public void when_UpdateBoard_and_coordinatesEqualOneAndOne_then_update_TopLeftCorner()
        {
            string[][] expectedBoard = new string[][]
            {
                new string[] {"x", ".", "."},
                new string[] {".", ".", "."},
                new string[] {".", ".", "."},
            };
            
            Board board = _board.GenerateBoard();

            board = _board.UpdateBoard("x", 0, 0, board);
            
            Assert.Equal(expectedBoard, board._board);
        }
    }
}