using Xunit;

namespace TicTacToe.Tests
{
    public class ResultTests
    {
        private ResultChecker _result = new ResultChecker(3);
        private BoardFactory _boardFactory = new BoardFactory();

        [Fact]
        public void given_rowIsComplete_when_CheckResults_then_return_true()
        {
            Coordinates coordinates1 = new Coordinates(0, 0);
            Coordinates coordinates2 = new Coordinates(0, 1);
            Coordinates coordinates3 = new Coordinates(0, 2);

            Board _board = _boardFactory.GenerateInitialBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", coordinates1, _board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", coordinates2, updatedBoard);
            Board updatedBoard2 = _boardFactory.GenerateUpdatedBoard("x", coordinates3, updatedBoard1);
            
            Assert.True(_result.CheckResults(updatedBoard2));
        }
        
        [Fact]
        public void given_rowIsCompleteWithO_when_CheckResults_then_return_true()
        {
            Coordinates coordinates1 = new Coordinates(0, 0);
            Coordinates coordinates2 = new Coordinates(0, 1);
            Coordinates coordinates3 = new Coordinates(0, 2);
            
            Board _board = _boardFactory.GenerateInitialBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("o", coordinates1, _board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("o", coordinates2, updatedBoard);
            Board updatedBoard2 = _boardFactory.GenerateUpdatedBoard("o", coordinates3, updatedBoard1);
        
            Assert.True(_result.CheckResults(updatedBoard2));
        }
        
        [Fact]
        public void given_rowIsNotComplete_when_CheckResults_then_return_false()
        {
            Coordinates coordinates1 = new Coordinates(0, 0);
            Coordinates coordinates2 = new Coordinates(0, 2);
       
            Board _board = _boardFactory.GenerateInitialBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", coordinates1, _board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", coordinates2, updatedBoard);
        
            Assert.False(_result.CheckResults(updatedBoard1));
        }
        
        [Fact]
        public void given_columnIsNotComplete_when_CheckResults_then_return_false()
        {
            Coordinates coordinates1 = new Coordinates(0, 0);
            Coordinates coordinates2 = new Coordinates(2, 0);
          
            Board _board = _boardFactory.GenerateInitialBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", coordinates1, _board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", coordinates2, updatedBoard);

            Assert.False(_result.CheckResults(updatedBoard1));
        }
        
        [Fact]
        public void given_columnIsComplete_when_CheckResults_then_return_true()
        {
            Coordinates coordinates1 = new Coordinates(0, 0);
            Coordinates coordinates2 = new Coordinates(1, 0);
            Coordinates coordinates3 = new Coordinates(2, 0);
            
            Board _board = _boardFactory.GenerateInitialBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", coordinates1, _board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", coordinates2, updatedBoard);
            Board updatedBoard2 = _boardFactory.GenerateUpdatedBoard("x", coordinates3, updatedBoard1);
        
            Assert.True(_result.CheckResults(updatedBoard2));
        }
        
        [Fact]
        public void given_diagonalSlopingRightIsComplete_when_CheckResults_then_return_true()
        {
            Coordinates coordinates1 = new Coordinates(0, 0);
            Coordinates coordinates2 = new Coordinates(1, 1);
            Coordinates coordinates3 = new Coordinates(2, 2);
            
            Board _board = _boardFactory.GenerateInitialBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", coordinates1, _board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", coordinates2, updatedBoard);
            Board updatedBoard2 = _boardFactory.GenerateUpdatedBoard("x", coordinates3, updatedBoard1);
        
            Assert.True(_result.CheckResults(updatedBoard2));
        }
        
        [Fact]
        public void given_diagonalSlopingLeftIsComplete_when_CheckResults_then_return_true()
        {
            Coordinates coordinates1 = new Coordinates(0, 2);
            Coordinates coordinates2 = new Coordinates(1, 1);
            Coordinates coordinates3 = new Coordinates(2, 0);
            
            Board _board = _boardFactory.GenerateInitialBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", coordinates1, _board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", coordinates2, updatedBoard);
            Board updatedBoard2 = _boardFactory.GenerateUpdatedBoard("x", coordinates3, updatedBoard1);
        
            Assert.True(_result.CheckResults(updatedBoard2));
        }
    }
}