using System.Collections.Generic;
using System.IO;
using TicTacToe.Exceptions;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
            _gameState = _gameSetUp.GetInitialGameState();
            
            _playerList = _gameState.PlayerList;
            _currentPlayer = _gameState.CurrentPlayer;
            _board = _gameState.Board;

            _gameState = PlayOneRound();

            while (UserWantsToPlayAgain())
            {
                _gameState = ResetGameState();
                _gameState = PlayOneRound();
            }

            return _gameState;
        }

        private GameState PlayOneRound()
        {
            _gameState = PlayTurn();
            
            while (_gameState.Status == GameStatus.InPlay)
            {
                _currentPlayer = SwapPlayers(_currentPlayer);
                _gameState = PlayTurn();
            }

            if (_gameState.Status is GameStatus.Win or GameStatus.Quit)
            {
                UpdateScoreForWinner(_gameState);
                _output.DisplayScores(_gameState.PlayerList);
            }

            return _gameState;
        }

        private GameState PlayTurn()
        {
            Coordinates coordinates;

            try
            {
                coordinates = _currentPlayer.GetPlayerMove(_board);
            }
            catch (InputIsQuitException)
            {
                return new GameState(_board, _currentPlayer, _playerList, GameStatus.Quit);
            }
            catch (InputIsSaveException)
            {
                _gameState = new GameState(_board, _currentPlayer, _playerList, GameStatus.Saved);
                SaveGameState();
                return _gameState;
            }

            _board = _boardFactory.GenerateUpdatedBoard(_currentPlayer.Marker, coordinates, _board);
            _output.DisplayBoard(_board);
            
            GameStatus gameStatus = _resultChecker.CheckResults(_board);
            
            return new GameState(_board, _currentPlayer, _playerList, gameStatus);
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

            while (response != Constants.Yes && response != Constants.No)
            {
                _output.DisplayMessage(OutputMessages.InvalidInput);
                response = _input.GetUserInput();
            }

            return response == Constants.Yes;
        }

        private GameState ResetGameState()
        {
            _board = _boardFactory.GenerateEmptyBoard(_board.SizeOfBoard);
            _currentPlayer = SwapPlayers(_currentPlayer);
            
            return new GameState(_board, _currentPlayer, _playerList, GameStatus.InPlay);
        }

        private void SaveGameState()
        {
            string gameStateJsonString = JsonSerializer.Serialize(_gameState);
            File.WriteAllText(Constants.SavedGameStateFilePath, gameStateJsonString);
        }
    }
}