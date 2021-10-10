using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Result
    {
        public bool CheckResults(string[][] board)
        {
            if (CheckRow(board))
                return true;

            if (CheckColumn(board, 0))
                return true;
            
            if (CheckColumn(board, 1))
                return true;
            
            if (CheckColumn(board, 2))
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
            if (board[0].Distinct().Count() == 1 && !board[0].Contains("."))
                return true;
            if (board[1].Distinct().Count() == 1 && !board[1].Contains("."))
                return true;
            if (board[2].Distinct().Count() == 1 && !board[2].Contains("."))
                return true;
            return false;
        }

        private bool CheckColumn(string[][] board, int column)
        {
            List<string> columnCheck = new List<string>()
            {
                board[0][column],
                board[1][column],
                board[2][column]
            };
            
            return columnCheck.Distinct().Count() == 1 && !columnCheck.Contains(".");
        }

        private bool CheckTopLeftToBottomRight(string[][] board)
        {
            List<string> diagonalSlopeRight= new List<string>()
            {
                board[0][0],
                board[1][1],
                board[2][2]
            };
            return diagonalSlopeRight.Distinct().Count() == 1 && !diagonalSlopeRight.Contains(".");
            
        }
        
        private bool CheckTopRightToBottomLeft(string[][] board)
        {
            List<string> diagonalSlopeLeft= new List<string>()
            {
                board[0][2],
                board[1][1],
                board[2][0]
            };
            
            return diagonalSlopeLeft.Distinct().Count() == 1 && !diagonalSlopeLeft.Contains(".");
        }
        
        public bool CheckForDraw(string[][] board)
        {
            List<bool> drawCheck= new List<bool>()
            {
                board[0].Contains("."),
                board[1].Contains("."),
                board[2].Contains(".")
            };
            
            return !drawCheck.Contains(true);
        }
    }
}