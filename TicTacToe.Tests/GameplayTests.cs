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
        public GameplayTests()
        {
            _listOfMovesOWins = new List<string>() {"1,1", "1,2", "2,1", "2,2", "1,3", "3,2"};
            
            _gameSetUp = new GameSetUp(new TestUserInput(_listOfMovesOWins), new Output());
            _playerList = new List<Player>()
            {
                new Player("Player1", "x"),
                new Player("Player2", "o")
            };
            
            _gameplayOWins = new Gameplay(new TestUserInput(_listOfMovesOWins), new Output(), _playerList);
        }
        
        [Fact]
        public void when_AddPlayers_then_return_listOfTwoPlayers()
        {
            List<Player> playerList = _gameSetUp.AddPlayers();
                
            Assert.Equal(2, playerList.Count);
        }

        [Fact]
        public void given_listOfMovesXWins_when_PlayOneGame_then_return_Player1()
        {
            List<string> listOfMovesXWins = new List<string>() {"1,1", "1,2", "2,1", "1,3", "3,1"};
            Gameplay gameplayXWins = new Gameplay(new TestUserInput(listOfMovesXWins), new Output(), _playerList);
            GameState gameState = gameplayXWins.PlayOneGame();
            Assert.Equal("Player1 wins!", gameState.Status);
        }
        
        [Fact]
        public void given_listOfMovesOWins_when_PlayOneGame_then_return_Player2()
        {
            _listOfMovesOWins = new List<string>() {"1,1", "1,2", "2,1", "2,2", "1,3", "3,2"};
            _gameplayOWins = new Gameplay(new TestUserInput(_listOfMovesOWins), new Output(), _playerList);
            
            GameState gameState = _gameplayOWins.PlayOneGame();
            Assert.Equal("Player2 wins!", gameState.Status);
        }

        [Fact]
        public void given_listOfMovesCreatesDraw_when_PlayOneGame_then_return_Draw()
        {
            List<string> listOfMovesDraw = new List<string>() {"1,1", "1,2", "2,1", "2,3", "3,3", "2,2", "1,3", "3,1", "3,2"};
            Gameplay gameplayDraw = new Gameplay(new TestUserInput(listOfMovesDraw), new Output(), _playerList);
            
            GameState gameState = gameplayDraw.PlayOneGame();
            Assert.Equal("Draw", gameState.Status);
        }
    }
}