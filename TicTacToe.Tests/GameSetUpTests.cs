using System.Collections.Generic;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameSetUpTests
    {
        [Fact]
        public void given_userInputEquals1_when_ChoosePlayerToGoFirst_then_currentPlayerEqualsPlayer1()
        {
            List<string> testInput = new List<string>() {"1"};
            GameSetUp gameSetUp = new GameSetUp(new TestUserInput(testInput), new Output());
            List<Player> playerList = new List<Player>()
            {
                new HumanPlayer("Player1", "x",new TestUserInput(testInput), new Output()),
                new HumanPlayer("Player2", "o",new TestUserInput(testInput), new Output()),
            };
            Player currentPlayer = gameSetUp.ChoosePlayerToGoFirst(playerList);
            
            Assert.Equal("Player1", currentPlayer.Name);
        }
        
        [Fact]
        public void given_userInputEquals3_when_GetSizeOfBoard_then_return_3()
        {
            List<string> testInput = new List<string>() {"3"};
            GameSetUp gameSetUp = new GameSetUp(new TestUserInput(testInput), new Output());

            Assert.Equal(3, gameSetUp.GetSizeOfBoard());
        }
    }
}