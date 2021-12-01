
using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class GoodComputerPlayer : Player
    {
        public List<string> _movesList;
        public GoodComputerPlayer(string name, string marker)
            : base(name, marker)
        {
            _movesList = new List<string>() {"2,2", "1,1", "1,3", "3,3", "1,3", "1,2", "2,1", "3,2", "2,3"};

        }
        
        public override string GetCoordinate(Board board)
        {
            string answer = CheckColumns(board);
            answer = answer == null ? CheckRows(board) : answer;
            answer = answer == null ? CheckTopLeftToBottomRight(board) : answer;
            answer = answer == null ? CheckTopRightToBottomLeft(board) : answer;
            answer = answer == null ? GetNextMove(board) : answer;

            return answer;
        }
        
        private string CheckColumns(Board board)
        {
            for(int column = 0; column < board.SizeOfBoard; column++)
            {
                string[] columnArray = board.GetColumn(column);
                if (columnArray.Distinct().Count() == 2 && columnArray.Count(x => x == ".") == 1)
                {
                    int indexOfFreeSpace = Array.IndexOf(columnArray, ".") + 1;
                    return indexOfFreeSpace + "," + (column + 1);
                }
            }

            return null;
        }
        
        private string CheckRows(Board board)
        {
            for(int row = 0; row < board.SizeOfBoard; row++)
            {
                string[] rowArray = board.GetRow(row);
                if (rowArray.Distinct().Count() == 2 && rowArray.Count(x => x == ".") == 1)
                {
                    int indexOfFreeSpace = Array.IndexOf(rowArray, ".") + 1;
                    return (row + 1) + "," + indexOfFreeSpace;
                }
            }

            return null;
        }
        
        private string CheckTopLeftToBottomRight(Board board)
        {
            string[] diagonalSlopeRight = board.GetDiangonalTopLeftToBottomRight();

            if (diagonalSlopeRight.Distinct().Count() == 2 && diagonalSlopeRight.Count(x => x == ".") == 1)
            {
                int indexOfFreeSpace = Array.IndexOf(diagonalSlopeRight, ".") + 1;
                return indexOfFreeSpace + "," + indexOfFreeSpace;
            }
            
            return null;
        }
        
        private string CheckTopRightToBottomLeft(Board board)
        {
            string[] diagonalSlopeLeft = board.GetDiangonalTopRightToBottomLeft();

            if (diagonalSlopeLeft.Distinct().Count() == 2 && diagonalSlopeLeft.Count(x => x == ".") == 1)
            {
                int indexOfFreeSpace = Array.IndexOf(diagonalSlopeLeft, ".") + 1;
                return indexOfFreeSpace + "," + (board.SizeOfBoard - indexOfFreeSpace + 1);
            }
            
            return null;
        }

        private string GetNextMove(Board board)
        {
            ResetComputerMovesIfRequired(board);
            string move = _movesList[0];
            _movesList.RemoveAt(0);
            return move;
        }

        public void ResetComputerMovesIfRequired(Board board)
        {
            int positionsOnBoard = board.SizeOfBoard * board.SizeOfBoard;
            int freeSpaces = board.GetNumberOfFreeSpaces();
            if (freeSpaces == positionsOnBoard)
            {
                _movesList = new List<string>() {"2,2", "1,1", "1,3", "3,3", "1,3", "1,2", "2,1", "3,2", "2,3"};
            }
            else if (freeSpaces == positionsOnBoard - 1 && board.GetPoint(1,1) == ".")
            {
                _movesList = new List<string>() {"2,2", "1,1", "1,3", "3,3", "1,3", "1,2", "2,1", "3,2", "2,3"};
            }
            else if (freeSpaces == positionsOnBoard - 1)
            {
                _movesList = new List<string>() {"1,1", "1,3", "3,3", "1,3", "1,2", "2,1", "3,2", "2,3"};
            }
        }
    }
}