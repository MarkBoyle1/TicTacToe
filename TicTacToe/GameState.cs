using System.Collections.Generic;

namespace TicTacToe
{
    public class GameState
    {
        private Board _board;
        private List<Player> _playerList;
        public Player CurrentPlayer { get; }
        public string Status { get; }

        public GameState(Board board, Player currentPlayer, List<Player> playerList, string status)
        {
            _board = board;
            _playerList = playerList;
            CurrentPlayer = currentPlayer;
            Status = status;
        }
        
    }
}
