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
            GameSetUp _gameSetUp = new GameSetUp(new TestUserInput(testInput), new Output());
            List<Player> playerList = new List<Player>()
            {
                new Player("Player1", "x"),
                new Player("Player2", "o"),
            };
            Player currentPlayer = _gameSetUp.ChoosePlayerToGoFirst(playerList);
            
            Assert.Equal("Player1", currentPlayer.Name);
        }
        
        [Fact]
        public void given_userInputEquals3_when_GetSizeOfBoard_then_return_3()
        {
            List<string> testInput = new List<string>() {"3"};
            GameSetUp _gameSetUp = new GameSetUp(new TestUserInput(testInput), new Output());

            Assert.Equal(3, _gameSetUp.GetSizeOfBoard());
        }
    }
}