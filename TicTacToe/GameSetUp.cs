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
            _playerList = CreatePlayerList();
            Player currentPlayer = ChoosePlayerToGoFirst(_playerList);

            _gameplay = new Gameplay(_userInput, _output, _playerList, currentPlayer);
            
            GameState result = _gameplay.PlayOneGame();
            _output.DisplayMessage(result.Status);
        }

        public void SetUpGame()
        {
            _playerList = CreatePlayerList();
            Player currentPlayer = ChoosePlayerToGoFirst(_playerList);
        }

        public List<Player> CreatePlayerList()
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

        public Player ChoosePlayerToGoFirst(List<Player> playerList)
        {
            _output.DisplayMessage("Which player will go first (enter 1 or 2):");
            string response = _userInput.GetUserInput();
            int playerNumber = Convert.ToInt32(response);
            return playerList[playerNumber - 1];
        }
    }
}