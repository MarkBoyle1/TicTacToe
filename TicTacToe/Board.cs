using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        public string[][] GenerateBoard()
        {
            string[][] board = new string[3][];
            board = board.Select(x => new string[3].Select(x => ".").ToArray()).ToArray();

            return board;
        }
    }
}