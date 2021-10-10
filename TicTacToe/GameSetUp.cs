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
            string winner = _gameplay.PlayOneGame(_playerList);

            if (winner == "Draw")
            {
                _output.DisplayMessage("Draw");
            }
            else
            {
                _output.DisplayMessage("The winner is " + winner);
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