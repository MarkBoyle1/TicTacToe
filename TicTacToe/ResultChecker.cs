using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class ResultChecker
    {
        public GameStatus CheckResults(Board board)
        {
            if (CheckRow(board))
                return GameStatus.Win;

            if (CheckColumn(board))
                return GameStatus.Win;

            if (CheckTopLeftToBottomRight(board))
                return GameStatus.Win;

            if (CheckTopRightToBottomLeft(board))
                return GameStatus.Win;
            
            if (CheckForDraw(board))
                return GameStatus.Draw;

            return GameStatus.InPlay;
        }

        private bool CheckRow(Board board)
        {
            for (int row = 0; row < board.SizeOfBoard; row++)
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
            for(int column = 0; column < board.SizeOfBoard; column++)
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

            for(int i = 0; i < board.SizeOfBoard; i++)
            {
                diagonalSlopeRight.Add(board.GetPoint(i,i));
            }
            
            return diagonalSlopeRight.Distinct().Count() == 1 && !diagonalSlopeRight.Contains(".");
            
        }
        
        private bool CheckTopRightToBottomLeft(Board board)
        {
            List<string> diagonalSlopeLeft = new List<string>();

            for(int row = 0, column = board.SizeOfBoard - 1; row < board.SizeOfBoard; row++, column--)
            {
                diagonalSlopeLeft.Add(board.GetPoint(row, column));
            }
            
            return diagonalSlopeLeft.Distinct().Count() == 1 && !diagonalSlopeLeft.Contains(".");
        }
        
        public bool CheckForDraw(Board board)
        {
            List<bool> drawCheck = new List<bool>();

            for(int row = 0; row < board.SizeOfBoard; row++)
            {
                drawCheck.Add(board.GetRow(row).Contains("."));
            }
            
            return !drawCheck.Contains(true);
        }
    }
}