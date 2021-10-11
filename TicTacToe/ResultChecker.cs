using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Result
    {
        private int _sizeOfGrid;

        public Result(int sizeOfGrid)
        {
            _sizeOfGrid = sizeOfGrid;
        }
        public bool CheckResults(string[][] board)
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

        private bool CheckRow(string[][] board)
        {
            for (int i = 0; i < _sizeOfGrid; i++)
            {
                if (board[i].Distinct().Count() == 1 && !board[i].Contains("."))
                {
                    return true;
                }
            }
           
            return false;
        }

        private bool CheckColumn(string[][] board)
        {
            List<string> columnCheck = new List<string>();

            for(int column = 0; column < _sizeOfGrid; column++)
            {
                for(int row = 0; row < _sizeOfGrid; row++)
                {
                    columnCheck.Add(board[row][column]);
                }

                if (columnCheck.Distinct().Count() == 1 && !columnCheck.Contains("."))
                {
                    return true;
                }
                columnCheck.Clear();
            }

            return false;
        }

        private bool CheckTopLeftToBottomRight(string[][] board)
        {
            List<string> diagonalSlopeRight = new List<string>();

            for(int i = 0; i < _sizeOfGrid; i++)
            {
                diagonalSlopeRight.Add(board[i][i]);
            }
            
            return diagonalSlopeRight.Distinct().Count() == 1 && !diagonalSlopeRight.Contains(".");
            
        }
        
        private bool CheckTopRightToBottomLeft(string[][] board)
        {
            List<string> diagonalSlopeLeft = new List<string>();

            for(int i = 0, column = _sizeOfGrid - 1; i < _sizeOfGrid; i++, column--)
            {
                diagonalSlopeLeft.Add(board[i][column]);
            }
            
            return diagonalSlopeLeft.Distinct().Count() == 1 && !diagonalSlopeLeft.Contains(".");
        }
        
        public bool CheckForDraw(string[][] board)
        {
            List<bool> drawCheck = new List<bool>();

            for(int i = 0; i < _sizeOfGrid; i++)
            {
                drawCheck.Add(board[i].Contains("."));
            }
            
            return !drawCheck.Contains(true);
        }
    }
}