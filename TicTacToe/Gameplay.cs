using System;
using System.Collections.Generic;
using System.Globalization;
using TicTacToe.Exceptions;

namespace TicTacToe
{
    public class Gameplay
    {
        private IUserInput _input;
        private IOutput _output;
        private Board board;
        private List<Player> _playerList;
        private Player _currentPlayer;
        private ResultChecker _resultChecker;
        private int sizeOfBoard = 3;

        public Gameplay(IUserInput input, IOutput output)
        {
            _input = input;
            _output = output;
            board = new Board(sizeOfBoard);
            _resultChecker = new ResultChecker(sizeOfBoard);
        }
        
        public string PlayOneGame(List<Player> playerList)
        {
            _playerList = playerList;
            _currentPlayer = _playerList[0];
            
            _output.DisplayBoard(board, sizeOfBoard);

            board = MakeAMove();
            
            while(!_resultChecker.CheckResults(board))
            {
                _currentPlayer = SwapPlayers(_currentPlayer);
                board = MakeAMove();
            }

            if (_resultChecker.CheckForDraw(board))
            {
                return "Draw";
            }

            return _currentPlayer.Name;
        }
        public Board MakeAMove()
        {
            string input = CollectUserInput();
            Coordinates coordinates = ProcessCoordinates(input);
            
            while (!board.CheckMoveIsValid(coordinates))
            {
                _output.DisplayMessage("Move is not valid. Please try again.");
                input = CollectUserInput();
                coordinates = ProcessCoordinates(input);
            }
            
            board = board.UpdateBoard(_currentPlayer.Marker, coordinates.GetRow(), coordinates.GetColumn(), board);
            _output.DisplayBoard(board, sizeOfBoard);
            
            return board;
        }
        
        private string CollectUserInput()
        {
            string input = "";
            bool isValid = false;

            while (!isValid)
            {
                try
                {
                    _output.DisplayMessage($"{_currentPlayer.Name} please enter row,column to place your {_currentPlayer.Marker}: ");

                    input = _input.GetCoordinates();

                    string[] stringArray = ValidateInput(input);

                    bool rowIsNumber = ValidateNumber(stringArray[0]);
                    bool columnIsNumber = ValidateNumber(stringArray[1]);

                    if (rowIsNumber && columnIsNumber)
                    {
                        isValid = true;
                    }
                }
                catch (InvalidInputException error)
                {
                    _output.DisplayMessage(error.Message);
                }
                catch (NotANumberException error)
                {
                    _output.DisplayMessage(error.Message);
                }
            }

            return input;
        }
        
        private string[] ValidateInput(string input)
        {
            string[] stringArray = input.Split(',');

            if (stringArray.Length != 2)
            {
                throw new InvalidInputException(input);
            }

            return stringArray;
        }
        
        private bool ValidateNumber(string input)
        {
            int number;
            if (!int.TryParse(input, out number))
            {
                throw new NotANumberException(input);
            }

            return true;
        }

        private Coordinates ProcessCoordinates(string input)
        {
            string[] stringArray = input.Split(',');
            
            int row = Convert.ToInt32(stringArray[0]) - 1;
            int column = Convert.ToInt32(stringArray[1]) - 1;
            
            return  new Coordinates(row, column);
        }
        
        private Player SwapPlayers(Player currentPlayer)
        {
            return currentPlayer == _playerList[0] ? _playerList[1] : _playerList[0];
        }
    }
}