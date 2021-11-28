using System.Collections.Generic;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameSetUpTests
    {
        [Fact]
        public void given_userInputEquals1_when_ChoosePlayerToGoFirst_then_currentPlayerEqualsPlayer1()
        {
            GameSetUp _gameSetUp = new GameSetUp(new TestUserInput("1"), new Output());
            List<Player> playerList = new List<Player>()
            {
                new Player("Player1", "x"),
                new Player("Player2", "o"),
            };
            Player currentPlayer = _gameSetUp.ChoosePlayerToGoFirst(playerList);
            
            Assert.Equal("Player1", currentPlayer.Name);
        }
    }
}