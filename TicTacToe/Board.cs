using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        private string[][] _board;
        private ResultChecker _resultChecker;
        private int _sizeOfBoard;

        public Board(int sizeOfBoard)
        {
            _resultChecker = new ResultChecker(3);
            _sizeOfBoard = sizeOfBoard;
        }
        
        public bool CheckMoveIsValid(Coordinates input)
        {
            if (input.Row >= _sizeOfBoard || input.Column >= _sizeOfBoard || input.Row < 0 || input.Column < 0)
            {
                return false;
            }
            
            return _board[input.Row][input.Column] == ".";
        }
        
        public Board GenerateBoard(Board board)
        {
            board._board = new string[3][];
            board._board = board._board.Select
                (
                    x => new string[3].Select(x => ".").ToArray()
                )
                .ToArray();
            
            return board;
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