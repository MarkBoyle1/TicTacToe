using Xunit;

namespace TicTacToe.Tests
{
    public class ResultTests
    {
        private ResultChecker _result = new ResultChecker(3);

        [Fact]
        public void given_rowIsComplete_when_CheckResults_then_return_true()
        {
            Board _board = new Board(3);

            _board.UpdateBoard("x", 0, 0, _board);
            _board.UpdateBoard("x", 0, 1, _board);
            _board.UpdateBoard("x", 0, 2, _board);
            
            Assert.True(_result.CheckResults(_board));
        }
        
        [Fact]
        public void given_rowIsCompleteWithO_when_CheckResults_then_return_true()
        {
            Board _board = new Board(3);

            _board.UpdateBoard("o", 0, 0, _board);
            _board.UpdateBoard("o", 0, 1, _board);
            _board.UpdateBoard("o", 0, 2, _board);
        
            Assert.True(_result.CheckResults(_board));
        }
        
        [Fact]
        public void given_rowIsNotComplete_when_CheckResults_then_return_false()
        {
            Board _board = new Board(3);

            _board.UpdateBoard("x", 0, 0, _board);
            _board.UpdateBoard("x", 0, 2, _board);
        
            Assert.False(_result.CheckResults(_board));
        }
        
        [Fact]
        public void given_columnIsNotComplete_when_CheckResults_then_return_false()
        {
            Board _board = new Board(3);

            _board.UpdateBoard("x", 0, 0, _board);
            _board.UpdateBoard("x", 2, 0, _board);

            Assert.False(_result.CheckResults(_board));
        }
        
        [Fact]
        public void given_columnIsComplete_when_CheckResults_then_return_true()
        {
            Board _board = new Board(3);

            _board.UpdateBoard("x", 0, 0, _board);
            _board.UpdateBoard("x", 1, 0, _board);
            _board.UpdateBoard("x", 2, 0, _board);
        
            Assert.True(_result.CheckResults(_board));
        }
        
        [Fact]
        public void given_diagonalSlopingRightIsComplete_when_CheckResults_then_return_true()
        {
            Board _board = new Board(3);

            _board.UpdateBoard("x", 0, 0, _board);
            _board.UpdateBoard("x", 1, 1, _board);
            _board.UpdateBoard("x", 2, 2, _board);
        
            Assert.True(_result.CheckResults(_board));
        }
        
        [Fact]
        public void given_diagonalSlopingLeftIsComplete_when_CheckResults_then_return_true()
        {
            Board _board = new Board(3);

            _board.UpdateBoard("x", 0, 2, _board);
            _board.UpdateBoard("x", 1, 1, _board);
            _board.UpdateBoard("x", 2, 0, _board);
        
            Assert.True(_result.CheckResults(_board));
        }
    }
}