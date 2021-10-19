using TicTacToe.Exceptions;

namespace TicTacToe
{
    public class Validations
    {
        public bool CheckMoveIsValid(Coordinates coordinates, Board board)
        {
            int sizeOfBoard = board.GetRow(0).Length;
            
            if (coordinates.GetRow() >= sizeOfBoard || coordinates.GetColumn() >= sizeOfBoard || coordinates.GetRow() < 0 || coordinates.GetColumn() < 0)
            {
                return false;
            }
            
            return board.GetPoint(coordinates.GetRow(), coordinates.GetColumn()) == ".";
        }
        
        public string[] ValidateInput(string input)
        {
            string[] stringArray = input.Split(',');

            if (stringArray.Length != 2)
            {
                throw new InvalidInputException(input);
            }

            return stringArray;
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
    }
}