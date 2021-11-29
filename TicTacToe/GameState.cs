using System.Collections.Generic;

namespace TicTacToe
{
    public class GameState
    {
        public Board _board { get; }
        public List<Player> _playerList { get; }
        public Player CurrentPlayer { get; }
        public GameStatus Status { get; }

        public GameState(Board board, Player currentPlayer, List<Player> playerList, GameStatus status)
        {
            _board = board;
            _playerList = playerList;
            CurrentPlayer = currentPlayer;
            Status = status;
        }
        
    }
}
