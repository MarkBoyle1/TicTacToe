using System;

namespace TicTacToe
{
    public class BadComputerInput : IUserInput
    {
        private int _sizeOfBoard;
        private Board _board;
        private Random _random = new Random();
        private Validations _validations = new Validations();
        
        public BadComputerInput(Board board)
        {
            _sizeOfBoard = board.SizeOfBoard;
            _board = board;
        }
        public string GetUserInput()
        {
            int randomRow = _random.Next(1, _sizeOfBoard + 1);
            int randomColumn= _random.Next(1, _sizeOfBoard + 1);

            Coordinates coordinates = new Coordinates(randomRow - 1, randomColumn - 1);

            while (!_validations.CheckMoveIsValid(coordinates, _board))
            {
                randomRow = _random.Next(1, _sizeOfBoard + 1);
                randomColumn= _random.Next(1, _sizeOfBoard + 1);

                coordinates = new Coordinates(randomRow - 1, randomColumn - 1);
            }

            return randomRow + "," + randomColumn;
        }
    }
}