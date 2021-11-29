using System.Collections.Generic;
using Moq;
using Xunit;

namespace TicTacToe.Tests
{
    public class PlayerTests
    {
        private GameSetUp _gameSetUp = new GameSetUp(new UserInput(), new Output());
        
        [Fact]
        public void given_userInputEqualsX_when_GetPlayerMarker_then_PlayerMarkerEqualsX()
        {
            List<string> testInput = new List<string>() {"x"};
            GameSetUp _gameSetUp = new GameSetUp(new TestUserInput(testInput), new Output());

            Assert.Equal("x", _gameSetUp.GetPlayerMarker("Player1"));
        }
    }
}