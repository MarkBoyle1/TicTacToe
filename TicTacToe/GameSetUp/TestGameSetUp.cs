using System.Collections.Generic;

namespace TicTacToe
{
    public class TestGameSetUp : IGameSetUp
    {
        private List<Player> _playerList;
        private Player _currentPlayer;
        private Board _board;

        public TestGameSetUp(BoardFactory boardFactory, int sizeOfBoard, List<Player> playerList)
        {
            _board = boardFactory.GenerateInitialBoard(sizeOfBoard);
            _playerList = playerList;
            _currentPlayer = playerList[0];
        }

        public GameState SetUpGame()
        {
            return new GameState(_board, _currentPlayer, _playerList, GameStatus.InPlay);
        }
    }
}