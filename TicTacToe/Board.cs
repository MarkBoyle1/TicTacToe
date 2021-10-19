using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        private string[][] _board;
        private int _sizeOfBoard;

        public Board(string[][] board)
        {
            _sizeOfBoard = board[0].Length;
            _board = board;
        }
        
        public string[] GetRow(int row)
        {
            return _board[row];
        }
        
        public string[] GetColumn(int column)
        {
            string[] columnValues = new string[_sizeOfBoard];
            
            for(int row = 0; row < _sizeOfBoard; row++)
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