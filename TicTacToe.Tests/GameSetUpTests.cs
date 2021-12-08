using System.Collections.Generic;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameSetUpTests
    {
        private GameSetUp _defaultGameSetUpForNewGame;
        private List<string> _defaultNewGameInput;
        private GameSetUp _defaultGameSetUpForLoadedGame;
        private List<string> _defaultLoadedGameInput;

        public GameSetUpTests()
        {
            _defaultNewGameInput = new List<string>(){"n", "x", "0", "o", "2", "1", "3"};
            _defaultGameSetUpForNewGame = new GameSetUp(new TestUserInput(_defaultNewGameInput), new Output(), "../../../TestSavedGameState.json");
            
            _defaultLoadedGameInput = new List<string>(){"y"};
            _defaultGameSetUpForLoadedGame = new GameSetUp(new TestUserInput(_defaultLoadedGameInput), new Output(), "../../../TestSavedGameState.json");
        }
        
        [Fact]
        public void given_userInputEqualsX_when_AskedForPlayerMarker_then_PlayerMarkerEqualsX()
        {
            GameState gameState = _defaultGameSetUpForNewGame.GetInitialGameState();

            Assert.Equal("x", gameState.PlayerList[0].Marker);
        }
        
        [Fact]
        public void given_userInputEquals0_when_AskedForPlayerType_then_PlayerTypeEqualsHuman()
        {
            GameState gameState = _defaultGameSetUpForNewGame.GetInitialGameState();

            Assert.Equal(PlayerType.Human, gameState.PlayerList[0].Type);
        }
        
        [Fact]
        public void given_userInputEqualsO_when_AskedForPlayerMarker_then_PlayerMarkerEqualsO()
        {
            GameState gameState = _defaultGameSetUpForNewGame.GetInitialGameState();

            Assert.Equal("o", gameState.PlayerList[1].Marker);
        }
        
        [Fact]
        public void given_userInputEquals2_when_AskedForPlayerType_then_PlayerTypeEqualsGoodComputer()
        {
            GameState gameState = _defaultGameSetUpForNewGame.GetInitialGameState();

            Assert.Equal(PlayerType.GoodComputer, gameState.PlayerList[1].Type);
        }
        
        [Fact]
        public void given_userInputEquals1_when_AskedForStartingPlayer_then_CurrentPlayerEqualsPlayer1()
        {
            GameState gameState = _defaultGameSetUpForNewGame.GetInitialGameState();

            Assert.Equal("Player1", gameState.CurrentPlayer.Name);
        }
        
        [Fact]
        public void given_userInputEqualsThree_when_AskedForGridSize_then_SizeOfGridEqualsThree()
        {
            GameState gameState = _defaultGameSetUpForNewGame.GetInitialGameState();

            Assert.Equal(3, gameState.Board.SizeOfBoard);
        }
        
        [Fact]
        public void given_testSavedGameStateContainsSizeOfGridEqualsThree_when_LoadPreviousGame_then_sizeOfGridEqualsThree()
        {
            GameState gamestate = _defaultGameSetUpForLoadedGame.GetInitialGameState();

            Assert.Equal(3, gamestate.Board.SizeOfBoard);
        }
        
        [Fact]
        public void given_testSavedGameStateContainsCurrentPlayerEqualsPlayer2_when_LoadPreviousGame_then_currentPlayerEqualsPlayer2()
        {
            GameState gamestate = _defaultGameSetUpForLoadedGame.GetInitialGameState();

            Assert.Equal("Player2", gamestate.CurrentPlayer.Name);
        }
        
        [Fact]
        public void given_testSavedGameStateContainsBoardWithPointZeroZeroAsO_when_LoadPreviousGame_then_BoardZeroZeroEqualsO()
        {
            GameState gamestate = _defaultGameSetUpForLoadedGame.GetInitialGameState();

            Assert.Equal("o", gamestate.Board.GetPoint(0,0));
        }
    }
}