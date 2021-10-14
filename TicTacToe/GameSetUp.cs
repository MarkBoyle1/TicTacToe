using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class GameSetUp
    {
        private Gameplay _gameplay;
        private List<Player> _playerList;
        private IOutput _output;

        public GameSetUp(IUserInput userInput, IOutput output)
        {
            _gameplay = new Gameplay(userInput, output);
            _output = output;
        }
        public void RunProgram()
        {
            _output.DisplayMessage("Welcome to TicTacToe!");
            _playerList = AddPlayers();
            string result = _gameplay.PlayOneGame(_playerList);

            if (result == "Draw")
            {
                _output.DisplayMessage("Draw");
            }
            else
            {
                _output.DisplayMessage("The winner is " + result);
            }
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