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
            for (int i = 0; i < _sizeOfGrid; i++)
            {
                if (board.GetRow(i).Distinct().Count() == 1 && !board.GetRow(i).Contains("."))
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

            for(int i = 0, column = _sizeOfGrid - 1; i < _sizeOfGrid; i++, column--)
            {
                diagonalSlopeLeft.Add(board.GetPoint(i, column));
            }
            
            return diagonalSlopeLeft.Distinct().Count() == 1 && !diagonalSlopeLeft.Contains(".");
        }
        
        public bool CheckForDraw(Board board)
        {
            List<bool> drawCheck = new List<bool>();

            for(int i = 0; i < _sizeOfGrid; i++)
            {
                drawCheck.Add(board.GetRow(i).Contains("."));
            }
            
            return !drawCheck.Contains(true);
        }
    }
}