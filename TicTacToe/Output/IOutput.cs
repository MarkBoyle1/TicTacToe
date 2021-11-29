using System.Collections.Generic;

namespace TicTacToe
{
    public interface IOutput
    {
        public void DisplayMessage(string message);

        public void DisplayBoard(Board board);
        public void DisplayScores(List<Player> playerList);
    }
}