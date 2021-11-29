using System;
using TicTacToe.Exceptions;

namespace TicTacToe
{
    public class Validations
    {
        public bool CheckMoveIsValid(Coordinates coordinates, Board board)
        {
            if (coordinates.GetRow() >= board.SizeOfBoard || coordinates.GetColumn() >= board.SizeOfBoard || coordinates.GetRow() < 0 || coordinates.GetColumn() < 0)
            {
                return false;
            }
            
            return board.GetPoint(coordinates.GetRow(), coordinates.GetColumn()) == ".";
        }

        public bool ValidateNumber(string input)
        {
            int number;
            if (!int.TryParse(input, out number))
            {
                throw new NotANumberException(input);
            }

            return true;
        }

        public bool InputIsACoordinate(string input)
        {
            string[] inputArray = input.Split(',', StringSplitOptions.RemoveEmptyEntries);

            if (ValidateNumber(inputArray[0]) && ValidateNumber(inputArray[1]))
            {
                return true;
            }

            return false;
        }
    }
}