using System.Collections.Generic;

namespace TicTacToe
{
    public class GameState
    {
        public Board Board { get; }
        public List<Player> PlayerList { get; }
        public Player CurrentPlayer { get; }
        public GameStatus Status { get; }

        public GameState(Board board, Player currentPlayer, List<Player> playerList, GameStatus status)
        {
            Board = board; 
            PlayerList = playerList;
            CurrentPlayer = currentPlayer;
            Status = status;
        }
    }
}
