using System;
using System.Collections.Generic;
using System.Globalization;

namespace TicTacToe
{
    public class Gameplay
    {
        private string[][] board;
        private IUserInput _input;
        private IOutput _output;
        private Board boardController;
        private List<Player> playerList;

        public Gameplay(IUserInput input, IOutput output)
        {
            _input = input;
            _output = output;
            boardController = new Board();
        }

        public void RunProgram()
        {
            board = boardController.GenerateBoard();
            board = MakeAMove();
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
        public string[][] MakeAMove()
        {
            _output.DisplayMessage("Please select coordinates: ");
            string input = _input.GetCoordinates();
            int[] coordinates = ProcessCoordinates(input);

            if (!CheckMoveIsValid(coordinates, board))
            {
                _output.DisplayMessage("Move is not valid. Please try again.");
                MakeAMove();
            }
            
            board = boardController.UpdateBoard("x", coordinates[0], coordinates[1], board);
            _output.DisplayBoard(board);
            return board;
        }

        public bool CheckMoveIsValid(int[] input, string[][] board)
        {
            if (input[0] > 2 || input[1] > 2)
            {
                return false;
            }
            
            return board[input[0]][input[1]] == ".";
        }

        private int[] ProcessCoordinates(string input)
        {
            string[] stringArray = input.Split(',');

            int row = ValidateInput(stringArray[0]);
            int column = ValidateInput(stringArray[1]);
            
            return  new int[] {row, column};
        }

        private int ValidateInput(string input)
        {
            int number;
            if (int.TryParse(input, out number))
            {
                number = Convert.ToInt32(input);
            }
            else
            {
                _output.DisplayMessage("Invalid Input.");
                MakeAMove();
            }

            return number;
        }
    }
}