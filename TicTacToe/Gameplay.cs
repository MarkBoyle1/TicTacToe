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
        private Board _board;
        private List<Player> _playerList;
        private Player _currentPlayer;
        private ResultChecker _resultChecker;
        private BoardFactory _boardFactory;
        private GameState _gameState;
        private Validations _validations;
        private int _sizeOfBoard = 3;

        public Gameplay(IUserInput input, IOutput output, List<Player> playerList, Player currentPlayer)
        {
            _input = input;
            _output = output;
            _playerList = playerList;
            _currentPlayer = currentPlayer;
            _boardFactory = new BoardFactory();
            _board = _boardFactory.GenerateInitialBoard(_sizeOfBoard);
            _resultChecker = new ResultChecker(_sizeOfBoard);
            _validations = new Validations();
            _gameState = new GameState(_board, _currentPlayer, _playerList, "In Play");
        }
        
        public GameState PlayOneGame()
        {
            _output.DisplayBoard(_board, _sizeOfBoard);
            
            _gameState = PlayTurn();

            while(!_resultChecker.CheckResults(_board))
            {
                _currentPlayer = SwapPlayers(_currentPlayer);
                _gameState = PlayTurn();
            }

            if (_resultChecker.CheckForDraw(_board))
            {
                return new GameState(_board, _currentPlayer, _playerList, "Draw");
            }

            return new GameState(_board, _currentPlayer, _playerList, $"{_currentPlayer.Name} wins!");
        }

        private GameState PlayTurn()
        {
            Coordinates coordinates = GetPlayerMove();
            _board = MakeAMove(coordinates);

            _output.DisplayBoard(_board, _sizeOfBoard);

            return new GameState(_board, _currentPlayer, _playerList, "In Play");
        }

        public Board MakeAMove(Coordinates coordinates)
        {
            Board updatedBoard = _boardFactory.GenerateUpdatedBoard(_currentPlayer.Marker, coordinates, _board);

            return updatedBoard;
        }

        private Coordinates GetPlayerMove()
        {
            string input = CollectUserInput();
            Coordinates coordinates = ProcessCoordinates(input);
            
            while (!_validations.CheckMoveIsValid(coordinates, _board))
            {
                _output.DisplayMessage("Move is not valid. Please try again.");
                input = CollectUserInput();
                coordinates = ProcessCoordinates(input);
            }

            return coordinates;
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

                    string[] stringArray = _validations.ValidateInput(input);

                    bool rowIsNumber = _validations.ValidateNumber(stringArray[0]);
                    bool columnIsNumber = _validations.ValidateNumber(stringArray[1]);

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