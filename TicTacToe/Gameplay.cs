using System;
using System.Collections.Generic;
using System.Globalization;

namespace TicTacToe
{
    public class Gameplay
    {
        private Board _board;
        private IUserInput _input;
        private IOutput _output;
        private BoardController boardController;
        private List<Player> _playerList;
        private Player _currentPlayer;
        public Result _result;
        private int sizeOfGrid = 3;

        public Gameplay(IUserInput input, IOutput output)
        {
            _input = input;
            _output = output;
            boardController = new BoardController();
            _result = new Result(sizeOfGrid);
        }
        
        public string PlayOneGame(List<Player> playerList)
        {
            _playerList = playerList;
            _currentPlayer = _playerList[0];
            
            _board = boardController.GenerateBoard();
            _output.DisplayBoard(_board);

            _board = MakeAMove(_currentPlayer);
            
            while(!_result.CheckResults(_board._board))
            {
                _currentPlayer = SwapPlayers(_currentPlayer);
                _board = MakeAMove(_currentPlayer);
            }

            if (_result.CheckForDraw(_board._board))
            {
                return "Draw";
            }

            return _currentPlayer.Name;
        }
        public Board MakeAMove(Player player)
        {
            string input = CollectUserInput();
            Coordinates coordinates = ProcessCoordinates(input);
            
            while (!CheckMoveIsValid(coordinates, _board))
            {
                _output.DisplayMessage("Move is not valid. Please try again.");
                input = CollectUserInput();
                coordinates = ProcessCoordinates(input);
            }
            
            _board = boardController.UpdateBoard(_currentPlayer.Marker, coordinates.Row, coordinates.Column, _board);
            _output.DisplayBoard(_board);
            
            return _board;
        }
        
        private string CollectUserInput()
        {
            string input = "";
            bool isValid = false;

            while (!isValid)
            {
                try
                {
                    _output.DisplayMessage("Please select coordinates: ");

                    input = _input.GetCoordinates();
                    string[] stringArray = input.Split(',');

                    bool rowIsNumber = ValidateNumber(stringArray[0]);
                    bool columnIsNumber = ValidateNumber(stringArray[1]);

                    if (rowIsNumber && columnIsNumber)
                    {
                        isValid = true;
                    }
                    else
                    {
                        _output.DisplayMessage("Invalid input.");
                    }
                }
                catch
                {
                    _output.DisplayMessage("Invalid input.");
                }
            }

            return input;
        }
        
        private bool ValidateNumber(string input)
        {
            int number;
            return (int.TryParse(input, out number));
        }

        private bool CheckMoveIsValid(Coordinates input, Board board)
        {
            if (input.Row >= sizeOfGrid || input.Column >= sizeOfGrid)
            {
                return false;
            }
            
            return board._board[input.Row][input.Column] == ".";
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