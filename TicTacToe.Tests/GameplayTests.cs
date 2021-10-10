using System.Collections.Generic;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameplayTests
    {
        private List<string> _listOfMovesXWins;
        private List<string> _listOfMovesYWins;
        private Gameplay _gameplayXWins;
        private Gameplay _gameplayYWins;
        private GameSetUp _gameSetUp;
        private List<Player> _playerList;
        public GameplayTests()
        {
            _listOfMovesXWins = new List<string>() {"1,1", "1,2", "2,1", "1,3", "3,1"};
            _listOfMovesYWins = new List<string>() {"1,1", "1,2", "2,1", "2,2", "1,3", "3,2"};
            
            _gameplayXWins = new Gameplay(new TestUserInput(_listOfMovesXWins), new Output());
            _gameplayYWins = new Gameplay(new TestUserInput(_listOfMovesYWins), new Output());

            _gameSetUp = new GameSetUp(new TestUserInput(_listOfMovesXWins), new Output());
            _playerList = new List<Player>()
            {
                new Player("Player1", "x"),
                new Player("Player2", "o")
            };
        }
        
        [Fact]
        public void when_AddPlayers_then_return_listOfTwoPlayers()
        {
            List<Player> playerList = _gameSetUp.AddPlayers();
                
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

            Assert.True(_gameplayXWins.CheckMoveIsValid(input, board));
        }
        
        [Fact]
        public void given_listOfMovesXWins_when_PlayOneGame_then_return_Player1()
        {
            Assert.Equal("Player1", _gameplayXWins.PlayOneGame(_playerList));
        }
        
        [Fact]
        public void given_listOfMovesYWins_when_PlayOneGame_then_return_Player2()
        {
            Assert.Equal("Player2", _gameplayYWins.PlayOneGame(_playerList));
        }
        
        [Fact]
        public void given_listOfMovesYWins_when_PlayOneGame_then_return_Plasdf2()
        {
            List<string> _listOfMovesNormal = new List<string>() {"1,1", "1,2", "2,1", "1,3", "3,1"};
            Gameplay _gameplayNormal = new Gameplay(new TestUserInput(_listOfMovesNormal), new Output());
            
            Assert.Equal("Player1", _gameplayNormal.PlayOneGame(_playerList));
        }
        
        [Fact]
        public void given_listOfMovesCreatesDraw_when_PlayOneGame_then_return_Draw()
        {
            List<string> _listOfMovesNormal = new List<string>() {"1,1", "1,2", "2,1", "2,3", "3,3", "2,2", "1,3", "3,1", "3,2"};
            Gameplay _gameplayNormal = new Gameplay(new TestUserInput(_listOfMovesNormal), new Output());
            
            Assert.Equal("Draw", _gameplayNormal.PlayOneGame(_playerList));
        }
    }
}