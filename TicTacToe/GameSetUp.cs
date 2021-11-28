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
            _output.DisplayMessage(result.Status);
        }

        public List<Player> AddPlayers()
        {
            List<Player> playerList = new List<Player>();

            for (int i = 1; i <= 2; i++)
            {
                string playerName = "Player" + i;
                string marker = GetPlayerMarker(playerName);

                playerList.Add(new Player(playerName, marker));
            }
            return playerList;
        }

        public string GetPlayerMarker(string playerName)
        {
            _output.DisplayMessage($"Please enter the marker for {playerName}:");
            return _userInput.GetUserInput();
        }
    }
}