using System.Collections.Generic;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameplayTests
    {
        private Board _board = new Board();
        private Gameplay _gameplay = new Gameplay(new TestUserInput(), new Output());

        [Fact]
        public void when_MakeAMove_then_return_updatedBoard()
        {
            string[][] expectedBoard = new string[][]
            {
                new string[] {"x", ".", "."},
                new string[] {".", ".", "."},
                new string[] {".", ".", "."},
            };

            _gameplay.RunProgram();

            Assert.Equal(expectedBoard, _gameplay.MakeAMove());
        }

        [Fact]
        public void when_AddPlayers_then_return_listOfTwoPlayers()
        {
            List<Player> playerList = _gameplay.AddPlayers();
                
            Assert.Equal(2, playerList.Count);
        }

        [Fact]
        public void when_CheckMoveIsValid_and_coordinatesPointToFreeSpace_then_return_true()
        {
            string[][] board = new string[][]
            {
                new string[] {".", ".", "."},
                new string[] {".", ".", "."},
                new string[] {".", ".", "."},
            };

            int[] input = new int[] {1,1};

            Assert.True(_gameplay.CheckMoveIsValid(input, board));
        }
    }
}