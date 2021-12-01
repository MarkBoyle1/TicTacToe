using System.Collections.Generic;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameplayTests
    {
        [Fact]
        public void given_listOfMovesXWins_when_PlayOneGame_then_return_Player1()
        {
            List<string> listOfMovesX = new List<string>() {"1,1", "2,1", "3,1", "n"};
            List<string> listOfMovesO = new List<string>() {"1,2", "1,3", "n"};

            List<Player> _playerList = new List<Player>()
            {
                new TestPlayer("Player1", "x", listOfMovesX),
                new TestPlayer("Player2", "o", listOfMovesO)
            };
            
            IGameSetUp _defaultGameSetUp = new TestGameSetUp(new BoardFactory(), 3, _playerList);
            
            Gameplay gameplayXWins = new Gameplay(new TestUserInput(new List<string>() {"n"}), new Output(), _defaultGameSetUp);
            
            GameState gameState = gameplayXWins.RunProgram();
            
            Assert.Equal(GameStatus.Win, gameState.Status);
            Assert.Equal("Player1", gameState.CurrentPlayer.Name);
        }
        
        [Fact]
        public void given_listOfMovesOWins_when_PlayOneGame_then_return_Player2()
        {
            List<string> listOfMovesX = new List<string>() {"1,1", "2,1", "1,3", "n"};
            List<string> listOfMovesO = new List<string>() {"1,2", "2,2", "3,2", "n"};

            List<Player> _playerList = new List<Player>()
            {
                new TestPlayer("Player1", "x", listOfMovesX),
                new TestPlayer("Player2", "o", listOfMovesO)
            };
            
            IGameSetUp gameSetUp = new TestGameSetUp(new BoardFactory(), 3, _playerList);
            Gameplay gameplayOWins = new Gameplay(new TestUserInput(new List<string>() {"n"}), new Output(), gameSetUp);
           
            GameState gameState = gameplayOWins.RunProgram();
            
            Assert.Equal(GameStatus.Win, gameState.Status);
            Assert.Equal("Player2", gameState.CurrentPlayer.Name);

        }

        [Fact]
        public void given_listOfMovesCreatesDraw_when_PlayOneGame_then_return_Draw()
        {
            List<string> listOfMovesX = new List<string>() {"1,1", "3,1", "3,2", "1,3", "2,3", "n"};
            List<string> listOfMovesO = new List<string>() {"1,2", "2,2", "3,3", "2,1", "n"};

            List<Player> _playerList = new List<Player>()
            {
                new TestPlayer("Player1", "x", listOfMovesX),
                new TestPlayer("Player2", "o", listOfMovesO)
            };
            
            IGameSetUp _defaultGameSetUp = new TestGameSetUp(new BoardFactory(), 3, _playerList);
            
            Gameplay gameplayDraw = new Gameplay(new TestUserInput(new List<string>() {"n"}), new Output(), _defaultGameSetUp);
            
            GameState gameState = gameplayDraw.RunProgram();
            
            Assert.Equal(GameStatus.Draw, gameState.Status);
        }
        
        [Fact]
        public void given_twoGamesArePlayed_when_RunProgram_then_PlayerOnesScoreEquals2()
        {
            List<string> listOfMovesX = new List<string>() {"1,1", "2,1", "3,1", "1,2", "2,2", "3,2"};
            List<string> listOfMovesO = new List<string>() {"1,2", "1,3", "1,1", "2,1", "1,3"};


            List<Player> _playerList = new List<Player>()
            {
                new TestPlayer("Player1", "x", listOfMovesX),
                new TestPlayer("Player2", "o", listOfMovesO)
            };
            
            IGameSetUp _defaultGameSetUp = new TestGameSetUp(new BoardFactory(), 3, _playerList);
            Gameplay gameplayTwoGames = new Gameplay(new TestUserInput(new List<string>() {"y", "n"}), new Output(), _defaultGameSetUp);
            
            GameState gameState = gameplayTwoGames.RunProgram();
            
            Assert.Equal(2, gameState._playerList[0].Score);
        }
    }
}