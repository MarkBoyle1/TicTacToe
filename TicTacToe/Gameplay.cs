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
        private IGameSetUp _gameSetUp;

        public Gameplay(IUserInput input, IOutput output, IGameSetUp gameSetUp)
        {
            _input = input;
            _output = output;
            _gameSetUp = gameSetUp;
            _boardFactory = new BoardFactory();
            _resultChecker = new ResultChecker();
            _validations = new Validations();
        }
        
        public GameState RunProgram()
        {
            SetUpInitialGame();
            _gameState = PlayTurn();
            
            while (_gameState.Status == GameStatus.InPlay)
            {
                _currentPlayer = SwapPlayers(_currentPlayer);
                _gameState = PlayTurn();
            }

            UpdateScoreForWinner(_gameState);
            _output.DisplayScores(_gameState._playerList);
            return _gameState;
        }

        public void SetUpInitialGame()
        {
            _output.DisplayMessage("Welcome to TicTacToe!");
            _gameState = _gameSetUp.SetUpGame();
            
            _playerList = _gameState._playerList;
            _currentPlayer = _gameState.CurrentPlayer;
            _board = _gameState._board;
        }

        private GameState PlayTurn()
        {
            _output.DisplayMessage("Please enter input (row/column or q for quit):");
            string input = _input.GetUserInput();
            
            if (input == "q")
            {
                //Save data to external file
                return new GameState(_board, _currentPlayer, _playerList, GameStatus.Quit);
            }
            
            if (_validations.InputIsACoordinate(input))
            {
                Coordinates coordinates = ProcessInputIntoCoordinates(input);
                if (_validations.CheckMoveIsValid(coordinates, _board))
                {
                    _board = _boardFactory.GenerateUpdatedBoard(_currentPlayer.Marker, coordinates, _board);
                    _output.DisplayBoard(_board);
                    
                    GameStatus gameStatus = _resultChecker.CheckResults(_board);

                    return new GameState(_board, _currentPlayer, _playerList, gameStatus);
                }
            }
            
            _output.DisplayMessage("Invalid Input");
            _currentPlayer = SwapPlayers(_currentPlayer);    //Swaps players to make sure current player gets another go.

            return new GameState(_board, _currentPlayer, _playerList, GameStatus.InPlay);
        }

        private Coordinates ProcessInputIntoCoordinates(string input)
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

        private void UpdateScoreForWinner(GameState gameState)
        {
            if (gameState.Status == GameStatus.Win)
            {
                gameState.CurrentPlayer.IncreaseScoreByOne();
            }
            else if (gameState.Status == GameStatus.Quit)
            {
                Player winner = SwapPlayers(gameState.CurrentPlayer);
                winner.IncreaseScoreByOne();
            }
        }
    }
}