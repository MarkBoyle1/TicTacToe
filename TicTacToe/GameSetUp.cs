using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class GameSetUp
    {
        private Gameplay _gameplay;
        private List<Player> _playerList;
        private IOutput _output;
        private IUserInput _userInput;

        public GameSetUp(IUserInput userInput, IOutput output)
        {
            _userInput = userInput;
            _output = output;
        }
        public void RunProgram()
        {
            _output.DisplayMessage("Welcome to TicTacToe!");
            _playerList = AddPlayers();
            
            _gameplay = new Gameplay(_userInput, _output, _playerList);
            
            GameState result = _gameplay.PlayOneGame();
            // GameState result = _gameplay.RecursionPlayOneGame();
            _output.DisplayMessage(result.Status);
        }

        public List<Player> AddPlayers()
        {
            List<Player> playerList = new List<Player>()
            {
                new Player("Player1", "x"),
                new Player("Player2", "o")
            };

            return playerList;
        }
    }
}