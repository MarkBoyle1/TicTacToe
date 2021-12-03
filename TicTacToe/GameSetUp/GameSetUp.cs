using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace TicTacToe
{
    public class GameSetUp : IGameSetUp
    {
        private List<Player> _playerList;
        private IOutput _output;
        private IUserInput _userInput;
        private BoardFactory _boardFactory = new BoardFactory();
        private const string SavedBoardFilePath = "SavedBoardFile.json";
        private const string SavedGameStateFilePath = "SavedFile.json";

        public GameSetUp(IUserInput userInput, IOutput output)
        {
            _userInput = userInput;
            _output = output;
        }

        public GameState SetUpNewGame()
        {
            _playerList = CreatePlayerList();
            Player currentPlayer = ChoosePlayerToGoFirst(_playerList);
            int sizeOfBoard = GetSizeOfBoard();
            Board board = _boardFactory.GenerateInitialBoard(sizeOfBoard);

            return new GameState(board, currentPlayer, _playerList, GameStatus.InPlay);
        }

        public List<Player> CreatePlayerList()
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

        public string GetPlayerMarker(string playerName)
        {
            _output.DisplayMessage(OutputMessages.EnterMarkerForPlayer + $"{playerName}:");
            return _userInput.GetUserInput();
        }

        public Player ChoosePlayerToGoFirst(List<Player> playerList)
        {
            _output.DisplayMessage(OutputMessages.WhichPlayerGoesFirst);
            string response = _userInput.GetUserInput();
            int playerNumber = Convert.ToInt32(response);

            while (playerNumber < 1 || playerNumber > 2)
            {
                _output.DisplayMessage(OutputMessages.InvalidInput);
                response = _userInput.GetUserInput();
                playerNumber = Convert.ToInt32(response);
            }
            
            return playerList[playerNumber - 1];
        }

        public int GetSizeOfBoard()
        {
            _output.DisplayMessage("Please enter the size of the board:");
            string response = _userInput.GetUserInput();
            int boardSize = Convert.ToInt32(response);
            
            while (boardSize < 1 || boardSize > 10)
            {
                _output.DisplayMessage(OutputMessages.InvalidInput);
                response = _userInput.GetUserInput();
                boardSize = Convert.ToInt32(response);
            }

            return boardSize;
        }

        private PlayerType GetPlayerType(string playerName)
        {
            _output.DisplayMessage($"Please enter the player type for {playerName} " +
                                   $"(0 = Human, " +
                                   $"1 = Bad Computer Player, " +
                                   $"2 = Good Computer Player):");
            while (true)
            {
                string response = _userInput.GetUserInput();

                switch (response)
                {
                    case "0":
                        return PlayerType.Human;
                    case "1":
                        return PlayerType.BadComputer;
                    case "2":
                        return PlayerType.GoodComputer;
                    default:
                        _output.DisplayMessage(OutputMessages.InvalidInput);
                        break;
                }
            }
        }
        
        public GameState LoadPreviousGame()
        {
            var myBoard = File.ReadAllText(SavedBoardFilePath);
            Board board = 
                JsonSerializer.Deserialize<Board>(myBoard);

            var myJsonString = File.ReadAllText(SavedGameStateFilePath);
            var myJObject = JObject.Parse(myJsonString);

            List<Player> playerList = new List<Player>();
            
            List<JProperty> properties = myJObject.Properties().ToList();

            JProperty boardProperty = properties[0];
            JProperty playerListProperty = properties[1];
            JProperty currentPlayerProperty = properties[2];

            for (int i = 0; i <= 1; i++)
            {
                string playerName = playerListProperty.Value[i]["Name"].ToString();
                string playerMarker = playerListProperty.Value[i]["Marker"].ToString();
                string playerScore = playerListProperty.Value[i]["Score"].ToString();
                string playerType = playerListProperty.Value[i]["Type"].ToString();
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

                _playerList.Add(player);
            }
            
            Player currentPlayer = currentPlayerProperty.Name == _playerList[0].Name ?  _playerList[1] : _playerList[0];

            return new GameState(board, currentPlayer, playerList, GameStatus.InPlay);
        }
    }
}