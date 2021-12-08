using System.Collections.Generic;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameplayTests
    {
        [Fact]
        public void given_listOfMovesXWins_when_PlayOneGame_then_return_Player1()
        {
            List<string> listOfMovesX = new List<string>() {"0,0", "1,0", "2,0", "n"};
            List<string> listOfMovesO = new List<string>() {"0,1", "0,2", "n"};

            List<Player> _playerList = new List<Player>()
            {
                new TestPlayer("Player1", "x", 0, PlayerType.Human, listOfMovesX),
                new TestPlayer("Player2", "o", 0, PlayerType.Human, listOfMovesO)
            };
            
            IGameSetUp _defaultGameSetUp = new TestGameSetUp(new BoardFactory(), 3, _playerList);
            
            Gameplay gameplayXWins = new Gameplay(new TestUserInput(new List<string>() {"n", "n"}), new Output(), _defaultGameSetUp);
            
            GameState gameState = gameplayXWins.RunProgram();
            
            Assert.Equal(GameStatus.Win, gameState.Status);
            Assert.Equal("Player1", gameState.CurrentPlayer.Name);
        }
        
        [Fact]
        public void given_listOfMovesOWins_when_PlayOneGame_then_return_Player2()
        {
            List<string> listOfMovesX = new List<string>() {"0,0", "1,0", "0,2", "n"};
            List<string> listOfMovesO = new List<string>() {"0,1", "1,1", "2,1", "n"};

            List<Player> _playerList = new List<Player>()
            {
                new TestPlayer("Player1", "x", 0, PlayerType.Human, listOfMovesX),
                new TestPlayer("Player2", "o", 0, PlayerType.Human, listOfMovesO)
            };
            
            IGameSetUp gameSetUp = new TestGameSetUp(new BoardFactory(), 3, _playerList);
            Gameplay gameplayOWins = new Gameplay(new TestUserInput(new List<string>() {"n", "n"}), new Output(), gameSetUp);
           
            GameState gameState = gameplayOWins.RunProgram();
            
            Assert.Equal(GameStatus.Win, gameState.Status);
            Assert.Equal("Player2", gameState.CurrentPlayer.Name);

        }

        [Fact]
        public void given_listOfMovesCreatesDraw_when_PlayOneGame_then_return_Draw()
        {
            List<string> listOfMovesX = new List<string>() {"0,0", "2,0", "2,1", "0,2", "1,2", "n"};
            List<string> listOfMovesO = new List<string>() {"0,1", "1,1", "2,2", "1,0", "n"};

            List<Player> _playerList = new List<Player>()
            {
                new TestPlayer("Player1", "x", 0, PlayerType.Human, listOfMovesX),
                new TestPlayer("Player2", "o", 0, PlayerType.Human, listOfMovesO)
            };
            
            IGameSetUp _defaultGameSetUp = new TestGameSetUp(new BoardFactory(), 3, _playerList);
            
            Gameplay gameplayDraw = new Gameplay(new TestUserInput(new List<string>() {"n", "n"}), new Output(), _defaultGameSetUp);
            
            GameState gameState = gameplayDraw.RunProgram();
            
            Assert.Equal(GameStatus.Draw, gameState.Status);
        }
        
        [Fact]
        public void given_playerScoreEquals0_when_IncreaseScoreByOne_then_PlayerScoreEquals1()
        {
            Player player = new HumanPlayer("Player1", "x", 0, new TestUserInput(new List<string>() {"1"}), new Output());
            
            player.IncreaseScoreByOne();

            Assert.Equal(1, player.Score);
        }
        
        [Fact]
        public void given_twoGamesArePlayed_when_RunProgram_then_PlayerOnesScoreEquals2()
        {
            List<string> listOfMovesX = new List<string>() {"0,0", "1,0", "2,0", "0,1", "1,1", "2,1"};
            List<string> listOfMovesO = new List<string>() {"0,1", "0,2", "0,0", "1,0", "0,2"};


            List<Player> _playerList = new List<Player>()
            {
                new TestPlayer("Player1", "x", 0, PlayerType.Human, listOfMovesX),
                new TestPlayer("Player2", "o", 0, PlayerType.Human, listOfMovesO)
            };
            
            IGameSetUp _defaultGameSetUp = new TestGameSetUp(new BoardFactory(), 3, _playerList);
            Gameplay gameplayTwoGames = new Gameplay(new TestUserInput(new List<string>() {"y", "n"}), new Output(), _defaultGameSetUp);
            
            GameState gameState = gameplayTwoGames.RunProgram();
            
            Assert.Equal(2, gameState.PlayerList[0].Score);
        }
    }
}