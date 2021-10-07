using System;
using System.Globalization;

namespace TicTacToe
{
    public class Gameplay
    {
        private string[][] board;
        private IUserInput _input;
        private IOutput _output;
        private Board boardController;

        public Gameplay(IUserInput input, IOutput output)
        {
            _input = input;
            _output = output;
            boardController = new Board();
        }

        public void RunProgram()
        {
            board = boardController.GenerateBoard();
        }
        public string[][] MakeAMove()
        {
            _output.DisplayMessage("Please select coordinates: ");
            string input = _input.GetCoordinates();
            int[] coordinates = ProcessCoordinates(input);
            return boardController.UpdateBoard("x", coordinates[0], coordinates[1], board);
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