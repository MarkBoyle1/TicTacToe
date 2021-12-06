using Xunit;

namespace TicTacToe.Tests
{
    public class ResultTests
    {
        private ResultChecker _result = new ResultChecker();
        private BoardFactory _boardFactory = new BoardFactory();

        [Fact]
        public void given_rowIsComplete_when_CheckResults_then_return_Win()
        {
            Coordinates coordinates1 = new Coordinates(0, 0);
            Coordinates coordinates2 = new Coordinates(0, 1);
            Coordinates coordinates3 = new Coordinates(0, 2);

            Board board = _boardFactory.GenerateEmptyBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", coordinates1, board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", coordinates2, updatedBoard);
            Board updatedBoard2 = _boardFactory.GenerateUpdatedBoard("x", coordinates3, updatedBoard1);
            
            Assert.Equal(GameStatus.Win,_result.CheckResults(updatedBoard2));
        }
        
        [Fact]
        public void given_rowIsCompleteWithO_when_CheckResults_then_return_Win()
        {
            Coordinates coordinates1 = new Coordinates(0, 0);
            Coordinates coordinates2 = new Coordinates(0, 1);
            Coordinates coordinates3 = new Coordinates(0, 2);
            
            Board board = _boardFactory.GenerateEmptyBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("o", coordinates1, board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("o", coordinates2, updatedBoard);
            Board updatedBoard2 = _boardFactory.GenerateUpdatedBoard("o", coordinates3, updatedBoard1);
        
            Assert.Equal(GameStatus.Win,_result.CheckResults(updatedBoard2));
        }
        
        [Fact]
        public void given_rowIsNotComplete_when_CheckResults_then_return_InPlay()
        {
            Coordinates coordinates1 = new Coordinates(0, 0);
            Coordinates coordinates2 = new Coordinates(0, 2);
       
            Board board = _boardFactory.GenerateEmptyBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", coordinates1, board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", coordinates2, updatedBoard);
        
            Assert.Equal(GameStatus.InPlay,_result.CheckResults(updatedBoard1));
        }
        
        [Fact]
        public void given_columnIsNotComplete_when_CheckResults_then_return_InPlay()
        {
            Coordinates coordinates1 = new Coordinates(0, 0);
            Coordinates coordinates2 = new Coordinates(2, 0);
          
            Board board = _boardFactory.GenerateEmptyBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", coordinates1, board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", coordinates2, updatedBoard);

            Assert.Equal(GameStatus.InPlay,_result.CheckResults(updatedBoard1));
        }
        
        [Fact]
        public void given_columnIsComplete_when_CheckResults_then_return_Win()
        {
            Coordinates coordinates1 = new Coordinates(0, 0);
            Coordinates coordinates2 = new Coordinates(1, 0);
            Coordinates coordinates3 = new Coordinates(2, 0);
            
            Board board = _boardFactory.GenerateEmptyBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", coordinates1, board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", coordinates2, updatedBoard);
            Board updatedBoard2 = _boardFactory.GenerateUpdatedBoard("x", coordinates3, updatedBoard1);
        
            Assert.Equal(GameStatus.Win, _result.CheckResults(updatedBoard2));
        }
        
        [Fact]
        public void given_diagonalSlopingRightIsComplete_when_CheckResults_then_return_Win()
        {
            Coordinates coordinates1 = new Coordinates(0, 0);
            Coordinates coordinates2 = new Coordinates(1, 1);
            Coordinates coordinates3 = new Coordinates(2, 2);
            
            Board board = _boardFactory.GenerateEmptyBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", coordinates1, board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", coordinates2, updatedBoard);
            Board updatedBoard2 = _boardFactory.GenerateUpdatedBoard("x", coordinates3, updatedBoard1);
        
            Assert.Equal(GameStatus.Win,_result.CheckResults(updatedBoard2));
        }
        
        [Fact]
        public void given_diagonalSlopingLeftIsComplete_when_CheckResults_then_return_Win()
        {
            Coordinates coordinates1 = new Coordinates(0, 2);
            Coordinates coordinates2 = new Coordinates(1, 1);
            Coordinates coordinates3 = new Coordinates(2, 0);
            
            Board board = _boardFactory.GenerateEmptyBoard(3);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", coordinates1, board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", coordinates2, updatedBoard);
            Board updatedBoard2 = _boardFactory.GenerateUpdatedBoard("x", coordinates3, updatedBoard1);
        
            Assert.Equal(GameStatus.Win,_result.CheckResults(updatedBoard2));
        }
        
        [Fact]
        public void given_sizeOfGridEquals5_and_diagonalSlopingLeftIsComplete_when_CheckResults_then_return_Win()
        {
            Coordinates coordinates1 = new Coordinates(0, 4);
            Coordinates coordinates2 = new Coordinates(1, 3);
            Coordinates coordinates3 = new Coordinates(2, 2);
            Coordinates coordinates4 = new Coordinates(3, 1);
            Coordinates coordinates5 = new Coordinates(4, 0);
            
            Board board = _boardFactory.GenerateEmptyBoard(5);

            Board updatedBoard = _boardFactory.GenerateUpdatedBoard("x", coordinates1, board);
            Board updatedBoard1 = _boardFactory.GenerateUpdatedBoard("x", coordinates2, updatedBoard);
            Board updatedBoard2 = _boardFactory.GenerateUpdatedBoard("x", coordinates3, updatedBoard1);
            Board updatedBoard3 = _boardFactory.GenerateUpdatedBoard("x", coordinates4, updatedBoard2);
            Board updatedBoard4 = _boardFactory.GenerateUpdatedBoard("x", coordinates5, updatedBoard3);
            
            Assert.Equal(GameStatus.Win,_result.CheckResults(updatedBoard4));
        }
    }
}