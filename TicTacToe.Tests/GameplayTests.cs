using Xunit;

namespace TicTacToe.Tests
{
    public class GameplayTests
    {
        private Board _board = new Board();
        private Gameplay _gameplay = new Gameplay(new TestUserInput());

        [Fact]
        public void when_MakeAMove_then_return_updatedBoard()
        {
            IUserInput inputType = new TestUserInput();
            
            string[][] expectedBoard = new string[][]
            {
                new string[] {"x", ".", "."},
                new string[] {".", ".", "."},
                new string[] {".", ".", "."},
            };

            _gameplay.RunProgram();

            Assert.Equal(expectedBoard, _gameplay.MakeAMove());
        }
    }
}