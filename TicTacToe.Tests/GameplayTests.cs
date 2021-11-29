using System.Collections.Generic;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameplayTests
    {
        private List<string> _listOfMovesOWins;
        private Gameplay _gameplayOWins;
        private GameSetUp _gameSetUp;
        private List<Player> _playerList;
        private IGameSetUp _defaultGameSetUp;
        public GameplayTests()
        {
            _listOfMovesOWins = new List<string>() {"1,1", "1,2", "2,1", "2,2", "1,3", "3,2", "n"};
            
            _gameSetUp = new GameSetUp(new TestUserInput(_listOfMovesOWins), new Output());
            _playerList = new List<Player>()
            {
                new Player("Player1", "x"),
                new Player("Player2", "o")
            };
            
            _defaultGameSetUp = new TestGameSetUp(new BoardFactory(), 3, _playerList);
            _gameplayOWins = new Gameplay(new TestUserInput(_listOfMovesOWins), new Output(), _defaultGameSetUp);
        }
        
        [Fact]
        public void when_AddPlayers_then_return_listOfTwoPlayers()
        {
            List<Player> playerList = _gameSetUp.CreatePlayerList();
                
            Assert.Equal(2, playerList.Count);
        }

        [Fact]
        public void given_listOfMovesXWins_when_PlayOneGame_then_return_Player1()
        {
            List<string> listOfMovesXWins = new List<string>() {"1,1", "1,2", "2,1", "1,3", "3,1", "n"};
            Gameplay gameplayXWins = new Gameplay(new TestUserInput(listOfMovesXWins), new Output(), _defaultGameSetUp);
            
            GameState gameState = gameplayXWins.RunProgram();
            
            Assert.Equal(GameStatus.Win, gameState.Status);
            Assert.Equal("Player1", gameState.CurrentPlayer.Name);
        }
        
        [Fact]
        public void given_listOfMovesOWins_when_PlayOneGame_then_return_Player2()
        {
            _listOfMovesOWins = new List<string>() {"1,1", "1,2", "2,1", "2,2", "1,3", "3,2", "n"};
            _gameplayOWins = new Gameplay(new TestUserInput(_listOfMovesOWins), new Output(), _defaultGameSetUp);
           
            GameState gameState = _gameplayOWins.RunProgram();
            
            Assert.Equal(GameStatus.Win, gameState.Status);
            Assert.Equal("Player2", gameState.CurrentPlayer.Name);

        }

        [Fact]
        public void given_listOfMovesCreatesDraw_when_PlayOneGame_then_return_Draw()
        {
            List<string> listOfMovesDraw = new List<string>() {"1,1", "1,2", "2,1", "2,3", "3,3", "2,2", "1,3", "3,1", "3,2", "n"};
            Gameplay gameplayDraw = new Gameplay(new TestUserInput(listOfMovesDraw), new Output(), _defaultGameSetUp);
            
            GameState gameState = gameplayDraw.RunProgram();
            
            Assert.Equal(GameStatus.Draw, gameState.Status);
        }
        
        [Fact]
        public void given_twoGamesArePlayed_when_RunProgram_then_PlayerOnesScoreEquals2()
        {
            List<string> listOfMovesTwoGames = new List<string>() {"1,1", "1,2", "2,1", "1,3", "3,1", "y", "1,1", "1,2", "2,1", "2,2", "1,3", "3,2", "n"};
            Gameplay gameplayTwoGames = new Gameplay(new TestUserInput(listOfMovesTwoGames), new Output(), _defaultGameSetUp);
            
            GameState gameState = gameplayTwoGames.RunProgram();
            
            Assert.Equal(2, gameState._playerList[0].Score);
        }
    }
}