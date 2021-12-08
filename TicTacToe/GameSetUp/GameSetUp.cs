using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace TicTacToe
{
    public class GameSetUp : IGameSetUp
    {
        private List<Player> _playerList;
        private IOutput _output;
        private IUserInput _userInput;
        private BoardFactory _boardFactory;
        private string _filePath;

        public GameSetUp(IUserInput userInput, IOutput output, string filePath)
        {
            _userInput = userInput;
            _output = output;
            _boardFactory = new BoardFactory();
            _filePath = filePath;
        }
        
        public GameState GetInitialGameState()
        {
            _output.DisplayMessage(OutputMessages.WelcomeMessage);
            _output.DisplayMessage(OutputMessages.NewOrPreviousGame);
            string response = _userInput.GetUserInput();

            while (response != Constants.Yes && response != Constants.No)
            {
                _output.DisplayMessage(OutputMessages.InvalidInput);
                response = _userInput.GetUserInput();
            }

            GameState gameState = response == Constants.Yes 
                ? LoadPreviousGame() 
                : SetUpNewGame();

            return gameState;
        }

        private GameState SetUpNewGame()
        {
            _playerList = CreatePlayerList();
            Player currentPlayer = ChoosePlayerToGoFirst(_playerList);
            int sizeOfBoard = GetSizeOfBoard();
            Board board = _boardFactory.GenerateEmptyBoard(sizeOfBoard);

            return new GameState(board, currentPlayer, _playerList, GameStatus.InPlay);
        }

        private List<Player> CreatePlayerList()
        {
            List<Player> playerList = new List<Player>();

            for (int i = 1; i <= 2; i++)
            {
                string playerName = "Player" + i;
                string marker = GetPlayerMarker(playerName);
                PlayerType type = GetPlayerType(playerName);

                if (type == PlayerType.Human)
                {
                    playerList.Add(new HumanPlayer(playerName, marker, 0, _userInput, _output));
                }
                else if (type == PlayerType.BadComputer)
                {
                    playerList.Add(new BadComputerPlayer(playerName, marker, 0));
                }
                else if (type == PlayerType.GoodComputer)
                {
                    playerList.Add(new GoodComputerPlayer(playerName, marker, 0));
                }
            }
            return playerList;
        }

        private string GetPlayerMarker(string playerName)
        {
            List<string> usedMarker = new List<string>();

            if (usedMarker.Count > 0)
            {
                return usedMarker[0] == Constants.XMarker ? Constants.OMarker : Constants.XMarker;
            }
            
            _output.DisplayMessage(OutputMessages.EnterMarkerForPlayer + $" {playerName}:");
            string marker = _userInput.GetUserInput();

            while (marker != Constants.XMarker && marker != Constants.OMarker)
            {
                _output.DisplayMessage(OutputMessages.InvalidInput);
                marker = _userInput.GetUserInput();
            }

            usedMarker.Add(marker);
            return marker;
        }

        private Player ChoosePlayerToGoFirst(List<Player> playerList)
        {
            _output.DisplayMessage(OutputMessages.WhichPlayerGoesFirst);
            string response = _userInput.GetUserInput();

            int playerNumber = ConvertInputToNumber(response);

            while (playerNumber < 1 || playerNumber > 2)
            {
                _output.DisplayMessage(OutputMessages.InvalidInput);
                response = _userInput.GetUserInput();
                playerNumber = Convert.ToInt32(response);
            }
            
            return playerList[playerNumber - 1];
        }

        private int GetSizeOfBoard()
        {
            _output.DisplayMessage(OutputMessages.EnterSizeOfBoard);
            string response = _userInput.GetUserInput();

            int boardSize = ConvertInputToNumber(response);
            
            while (boardSize < 1)
            {
                _output.DisplayMessage(OutputMessages.InvalidInput);
                response = _userInput.GetUserInput();
                boardSize = Convert.ToInt32(response);
            }

            return boardSize;
        }

        private int ConvertInputToNumber(string response)
        {
            int number = 0;

            while (!int.TryParse(response, out number))
            {
                _output.DisplayMessage(OutputMessages.InvalidInput);
                response = _userInput.GetUserInput();
            }
            
            return Convert.ToInt32(response);
        }

        private PlayerType GetPlayerType(string playerName)
        {
            _output.DisplayMessage(OutputMessages.GivePlayerTypeOptions(playerName));

            while (true)
            {
                string response = _userInput.GetUserInput();
                
                switch (response)
                {
                    case Constants.InputForHumanPlayer:
                        return PlayerType.Human;
                    case Constants.InputForBadComputerPlayer:
                        return PlayerType.BadComputer;
                    case Constants.InputForGoodComputerPlayer:
                        return PlayerType.GoodComputer;
                    default:
                        _output.DisplayMessage(OutputMessages.InvalidInput);
                        break;
                }
            }
        }
        
        private GameState LoadPreviousGame()
        {
            var myJsonString = File.ReadAllText(_filePath);
            var myJObject = JObject.Parse(myJsonString);
            List<JProperty> properties = myJObject.Properties().ToList();
            
            JProperty boardProperty = properties[0];
            JProperty playerListProperty = properties[1];
            JProperty currentPlayerProperty = properties[2];

            Board board = new Board
                (
                    boardProperty.Value[Constants.Board].ToObject<string[][]>(), 
                    boardProperty.Value[Constants.SizeOfBoard].ToObject<int>()
                );
            
            List<Player> playerList = new List<Player>();

            for (int i = 0; i < playerListProperty.Value.Count(); i++)
            {
                string playerName = playerListProperty.Value[i][Constants.Name].ToString();
                string playerMarker = playerListProperty.Value[i][Constants.Marker].ToString();
                string playerScore = playerListProperty.Value[i][Constants.Score].ToString();
                string playerType = playerListProperty.Value[i][Constants.Type].ToString();
                PlayerType type = (PlayerType) Convert.ToInt16(playerType);

                Player player;
                switch (type)
                {
                    case PlayerType.GoodComputer:
                        player = new GoodComputerPlayer(playerName, playerMarker, Convert.ToInt16(playerScore));
                        break;
                    case PlayerType.BadComputer:
                        player = new BadComputerPlayer(playerName, playerMarker, Convert.ToInt16(playerScore));
                        break;
                    default:
                        player = new HumanPlayer(playerName, playerMarker, Convert.ToInt16(playerScore), _userInput, _output);
                        break;
                }

                playerList.Add(player);
            }

            Player currentPlayer = currentPlayerProperty.Value[Constants.Name].ToString() == playerList[0].Name ?  playerList[0] : playerList[1];

            return new GameState(board, currentPlayer, playerList, GameStatus.InPlay);
        }
    }
}