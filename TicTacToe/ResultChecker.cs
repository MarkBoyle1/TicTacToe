using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class ResultChecker
    {
        private int _sizeOfGrid;

        public ResultChecker(int sizeOfGrid)
        {
            _sizeOfGrid = sizeOfGrid;
        }
        public bool CheckResults(Board board)
        {
            if (CheckRow(board))
                return true;

            if (CheckColumn(board))
                return true;

            if (CheckTopLeftToBottomRight(board))
                return true;

            if (CheckTopRightToBottomLeft(board))
                return true;
            
            if (CheckForDraw(board))
                return true;

            return false;
        }

        private bool CheckRow(Board board)
        {
            for (int row = 0; row < _sizeOfGrid; row++)
            {
                if (board.GetRow(row).Distinct().Count() == 1 && !board.GetRow(row).Contains("."))
                {
                    return true;
                }
            }
           
            return false;
        }

        private bool CheckColumn(Board board)
        {
            for(int column = 0; column < _sizeOfGrid; column++)
            {
                if (board.GetColumn(column).Distinct().Count() == 1 && !board.GetColumn(column).Contains("."))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckTopLeftToBottomRight(Board board)
        {
            List<string> diagonalSlopeRight = new List<string>();

            for(int i = 0; i < _sizeOfGrid; i++)
            {
                diagonalSlopeRight.Add(board.GetPoint(i,i));
            }
            
            return diagonalSlopeRight.Distinct().Count() == 1 && !diagonalSlopeRight.Contains(".");
            
        }
        
        private bool CheckTopRightToBottomLeft(Board board)
        {
            List<string> diagonalSlopeLeft = new List<string>();

            for(int row = 0, column = _sizeOfGrid - 1; row < _sizeOfGrid; row++, column--)
            {
                diagonalSlopeLeft.Add(board.GetPoint(row, column));
            }
            
            return diagonalSlopeLeft.Distinct().Count() == 1 && !diagonalSlopeLeft.Contains(".");
        }
        
        public bool CheckForDraw(Board board)
        {
            List<bool> drawCheck = new List<bool>();

            for(int row = 0; row < _sizeOfGrid; row++)
            {
                drawCheck.Add(board.GetRow(row).Contains("."));
            }
            
            return !drawCheck.Contains(true);
        }
    }
}