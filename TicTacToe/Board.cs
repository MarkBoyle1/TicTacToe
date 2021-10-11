namespace TicTacToe
{
    public class Board
    {
        public string[][] _board { get; set; }

        public Board(string[][] board)
        {
            _board = board;
        }
    }
}