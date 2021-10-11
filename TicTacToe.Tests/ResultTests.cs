using Xunit;

namespace TicTacToe.Tests
{
    public class ResultTests
    {
        private Result _result = new Result(3);
        [Fact]
        public void given_rowIsComplete_when_CheckResults_then_return_true()
        {
            string[][] board = new string[][]
            {
                new string[] {"x", "x", "x"},
                new string[] {".", ".", "."},
                new string[] {".", ".", "."},
            };

            Assert.True(_result.CheckResults(board));
        }
        
        [Fact]
        public void given_rowIsCompleteWithO_when_CheckResults_then_return_true()
        {
            string[][] board = new string[][]
            {
                new string[] {"o", "o", "o"},
                new string[] {".", ".", "."},
                new string[] {".", ".", "."},
            };

            Assert.True(_result.CheckResults(board));
        }
        
        [Fact]
        public void given_rowIsNotComplete_when_CheckResults_then_return_false()
        {
            string[][] board = new string[][]
            {
                new string[] {"o", ".", "o"},
                new string[] {".", ".", "."},
                new string[] {".", ".", "."},
            };

            Assert.False(_result.CheckResults(board));
        }
        
        [Fact]
        public void given_columnIsNotComplete_when_CheckResults_then_return_false()
        {
            string[][] board = new string[][]
            {
                new string[] {"o", ".", "."},
                new string[] {".", ".", "."},
                new string[] {"o", ".", "."},
            };

            Assert.False(_result.CheckResults(board));
        }
        
        [Fact]
        public void given_columnIsComplete_when_CheckResults_then_return_true()
        {
            string[][] board = new string[][]
            {
                new string[] {"x", ".", "."},
                new string[] {"x", ".", "."},
                new string[] {"x", ".", "."},
            };

            Assert.True(_result.CheckResults(board));
        }
        
        [Fact]
        public void given_diagonalSlopingRightIsComplete_when_CheckResults_then_return_true()
        {
            string[][] board = new string[][]
            {
                new string[] {"x", ".", "."},
                new string[] {".", "x", "."},
                new string[] {".", ".", "x"},
            };

            Assert.True(_result.CheckResults(board));
        }
        
        [Fact]
        public void given_diagonalSlopingLeftIsComplete_when_CheckResults_then_return_true()
        {
            string[][] board = new string[][]
            {
                new string[] {".", ".", "x"},
                new string[] {".", "x", "."},
                new string[] {"x", ".", "."}
            };

            Assert.True(_result.CheckResults(board));
        }
    }
}