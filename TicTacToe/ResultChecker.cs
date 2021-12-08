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
                if (board.GetRow(row).Distinct().Count() == 1 && !board.GetRow(row).Contains(Constants.FreeSpace))
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
                if (board.GetColumn(column).Distinct().Count() == 1 && !board.GetColumn(column).Contains(Constants.FreeSpace))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckTopLeftToBottomRight(Board board)
        {
            string[] diagonalSlopeRight = board.GetDiangonalTopLeftToBottomRight();

            return diagonalSlopeRight.Distinct().Count() == 1 && !diagonalSlopeRight.Contains(Constants.FreeSpace);
            
        }
        
        private bool CheckTopRightToBottomLeft(Board board)
        {
            string[] diagonalSlopeLeft = board.GetDiangonalTopRightToBottomLeft();

            return diagonalSlopeLeft.Distinct().Count() == 1 && !diagonalSlopeLeft.Contains(Constants.FreeSpace);
        }
        
        public bool CheckForDraw(Board board)
        {
            return board.GetAllFreeSpaces().Count == 0;
        }
    }
}