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
                new HumanPlayer("Player1", "x", 0, new TestUserInput(testInput), new Output()),
                new HumanPlayer("Player2", "o", 0, new TestUserInput(testInput), new Output()),
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
        
        [Fact]
        public void given_testSavedGameStateContainsSizeOfGridEqualsThree_when_LoadPreviousGame_then_sizeOfGridEqualsThree()
        {
            GameSetUp gameSetUp = new GameSetUp(new UserInput(), new Output());

            GameState gamestate = gameSetUp.LoadPreviousGame("../../../TestSavedGameState.json");

            Assert.Equal(3, gamestate.Board.SizeOfBoard);
        }
        
        [Fact]
        public void given_testSavedGameStateContainsCurrentPlayerEqualsPlayer2_when_LoadPreviousGame_then_currentPlayerEqualsPlayer2()
        {
            GameSetUp gameSetUp = new GameSetUp(new UserInput(), new Output());

            GameState gamestate = gameSetUp.LoadPreviousGame("../../../TestSavedGameState.json");

            Assert.Equal("Player2", gamestate.CurrentPlayer.Name);
        }
        
        [Fact]
        public void given_testSavedGameStateContainsBoardWithPointZeroZeroAsO_when_LoadPreviousGame_then_BoardZeroZeroEqualsO()
        {
            GameSetUp gameSetUp = new GameSetUp(new UserInput(), new Output());

            GameState gamestate = gameSetUp.LoadPreviousGame("../../../TestSavedGameState.json");

            Assert.Equal("o", gamestate.Board.GetPoint(0,0));
        }
    }
}