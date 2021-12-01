using System;
using System.Collections.Generic;

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
        private IGameSetUp _gameSetUp;
        private string Quit = "q";
        private string Yes = "y";
        private string No = "n";

        public Gameplay(IUserInput input, IOutput output, IGameSetUp gameSetUp)
        {
            _input = input;
            _output = output;
            _gameSetUp = gameSetUp;
            _boardFactory = new BoardFactory();
            _resultChecker = new ResultChecker();
        }
        
        public GameState RunProgram()
        {
            SetUpInitialGame();
            _gameState = PlayOneGame();

            while (UserWantsToPlayAgain())
            {
                _gameState = ResetGameState();
                _gameState = PlayOneGame();
            }

            return _gameState;
        }

        public void SetUpInitialGame()
        {
            _output.DisplayMessage(OutputMessages.WelcomeMessage);
            _gameState = _gameSetUp.SetUpGame();
            
            _playerList = _gameState._playerList;
            _currentPlayer = _gameState.CurrentPlayer;
            _board = _gameState._board;
        }

        public GameState PlayOneGame()
        {
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

        private GameState PlayTurn()
        {
            _output.DisplayBoard(_board);

            _output.DisplayMessage(OutputMessages.EnterNextMove);
            string input = _currentPlayer.GetPlayerMove(_board);

            if (input == Quit)
            {
                return new GameState(_board, _currentPlayer, _playerList, GameStatus.Quit);
            }

            Coordinates coordinates = ConvertInputIntoCoordinates(input);

            _board = _boardFactory.GenerateUpdatedBoard(_currentPlayer.Marker, coordinates, _board);
            _output.DisplayBoard(_board);
            
            GameStatus gameStatus = _resultChecker.CheckResults(_board);
            
            return new GameState(_board, _currentPlayer, _playerList, gameStatus);
        }

        private Coordinates ConvertInputIntoCoordinates(string input)
        {
            string[] stringArray = input.Split(',');
            
            int row = Convert.ToInt32(stringArray[0]);
            int column = Convert.ToInt32(stringArray[1]);
            
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

        private bool UserWantsToPlayAgain()
        {
            _output.DisplayMessage(OutputMessages.PlayAnotherGameQuestion);
            string response = _input.GetUserInput();

            while (response != Yes && response != No)
            {
                _output.DisplayMessage(OutputMessages.InvalidInput);
                response = _input.GetUserInput();
            }
            
            return response == Yes;
        }

        private GameState ResetGameState()
        {
            _board = _boardFactory.GenerateInitialBoard(_board.SizeOfBoard);
            _currentPlayer = SwapPlayers(_currentPlayer);
            
            return new GameState(_board, _currentPlayer, _playerList, GameStatus.InPlay);
        }
    }
}