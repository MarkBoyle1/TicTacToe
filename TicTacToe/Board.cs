using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        private string[][] _board;
        private int _sizeOfBoard;

        public Board(int sizeOfBoard)
        {
            _sizeOfBoard = sizeOfBoard;
            _board = GenerateBoard(sizeOfBoard);
        }
        
        public string[][] GenerateBoard(int sizeOfBoard)
        {
            string[][] board = new string[sizeOfBoard][];
            board = board.Select
                (
                    x => new string[sizeOfBoard].Select(x => ".").ToArray()
                )
                .ToArray();
            
            return board;
        }
        
        public bool CheckMoveIsValid(Coordinates input)
        {
            if (input.GetRow() >= _sizeOfBoard || input.GetColumn() >= _sizeOfBoard || input.GetRow() < 0 || input.GetColumn() < 0)
            {
                return false;
            }
            
            return _board[input.GetRow()][input.GetColumn()] == ".";
        }
        
        public Board UpdateBoard(string marker, int row, int column, Board board)
        {
            board._board[row][column] = marker;

            return board;
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