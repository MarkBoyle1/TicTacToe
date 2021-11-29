using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        private string[][] _board;
        public int SizeOfBoard { get; }

        public Board(string[][] board)
        {
            SizeOfBoard = board[0].Length;
            _board = board;
        }
        
        public string[] GetRow(int row)
        {
            return _board[row];
        }
        
        public string[] GetColumn(int column)
        {
            string[] columnValues = new string[SizeOfBoard];
            
            for(int row = 0; row < SizeOfBoard; row++)
            {
                columnValues[row] = _board[row][column];
            }

            return columnValues;
        }

        public string GetPoint(int row, int column)
        {
            return _board[row][column];
        }
    }
}