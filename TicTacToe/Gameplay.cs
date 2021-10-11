using System;
using System.Collections.Generic;
using System.Globalization;

namespace TicTacToe
{
    public class Gameplay
    {
        private string[][] _board;
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
            _result = new Result();
        }
        
        public string PlayOneGame(List<Player> playerList)
        {
            _playerList = playerList;
            _currentPlayer = _playerList[0];
            
            _board = boardController.GenerateBoard();
            _board = MakeAMove(_currentPlayer);
            
            while(!_result.CheckResults(_board))
            {
                _currentPlayer = SwapPlayers(_currentPlayer);
                _board = MakeAMove(_currentPlayer);
            }

            if (_result.CheckForDraw(_board))
            {
                return "Draw";
            }

            return _currentPlayer.Name;
        }
        public string[][] MakeAMove(Player player)
        {
            _output.DisplayMessage("Please select coordinates: ");
            string input = _input.GetCoordinates();
            Coordinates coordinates = ProcessCoordinates(input);

            if (!CheckMoveIsValid(coordinates, _board))
            {
                _output.DisplayMessage("Move is not valid. Please try again.");
                MakeAMove(_currentPlayer);
            }
            
            _board = boardController.UpdateBoard(_currentPlayer.Marker, coordinates.Row, coordinates.Column, _board);
            _output.DisplayBoard(_board);
            
            return _board;
        }

        private bool CheckMoveIsValid(Coordinates input, string[][] board)
        {
            if (input.Row >= sizeOfGrid || input.Column >= sizeOfGrid)
            {
                return false;
            }
            
            return board[input.Row][input.Column] == ".";
        }

        private Coordinates ProcessCoordinates(string input)
        {
            string[] stringArray = input.Split(',');

            int row = ValidateInput(stringArray[0]);
            int column = ValidateInput(stringArray[1]);
            
            return  new Coordinates(row, column);
        }

        private int ValidateInput(string input)
        {
            int number;
            if (!int.TryParse(input, out number))
            {
                _output.DisplayMessage("Invalid Input.");
                MakeAMove(_currentPlayer);
            }

            number = Convert.ToInt32(input) - 1;

            if (number < 0 || number > 2)
            {
                _output.DisplayMessage("Invalid Input.");
                MakeAMove(_currentPlayer);
            }

            return number;
        }

        private Player SwapPlayers(Player currentPlayer)
        {
            return currentPlayer == _playerList[0] ? _playerList[1] : _playerList[0];
        }
    }
}