
using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class GoodComputerPlayer : Player
    {
        public List<string> _movesList;
        private Random _random = new Random();
        public GoodComputerPlayer(string name, string marker)
            : base(name, marker)
        {
            _movesList = new List<string>() {"2,2", "1,1", "1,3", "3,3", "1,3", "1,2", "2,1", "3,2", "2,3"};

        }
        
        public override string GetPlayerMove(Board board)
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
                    int indexOfFreeSpace = Array.IndexOf(columnArray, ".");
                    return indexOfFreeSpace + "," + (column);
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
                    int indexOfFreeSpace = Array.IndexOf(rowArray, ".");
                    return (row) + "," + indexOfFreeSpace;
                }
            }

            return null;
        }
        
        private string CheckTopLeftToBottomRight(Board board)
        {
            string[] diagonalSlopeRight = board.GetDiangonalTopLeftToBottomRight();

            if (diagonalSlopeRight.Distinct().Count() == 2 && diagonalSlopeRight.Count(x => x == ".") == 1)
            {
                int indexOfFreeSpace = Array.IndexOf(diagonalSlopeRight, ".");
                return indexOfFreeSpace + "," + indexOfFreeSpace;
            }
            
            return null;
        }
        
        private string CheckTopRightToBottomLeft(Board board)
        {
            string[] diagonalSlopeLeft = board.GetDiangonalTopRightToBottomLeft();

            if (diagonalSlopeLeft.Distinct().Count() == 2 && diagonalSlopeLeft.Count(x => x == ".") == 1)
            {
                int indexOfFreeSpace = Array.IndexOf(diagonalSlopeLeft, ".");
                return indexOfFreeSpace + "," + (board.SizeOfBoard - 1 - indexOfFreeSpace);
            }
            
            return null;
        }

        private string GetNextMove(Board board)
        {
            string middleSpace = null;

            if (board.SizeOfBoard % 2 != 0)
            {
                middleSpace = (board.SizeOfBoard / 2) + "," + (board.SizeOfBoard / 2);
            }
            
            List<string> idealMoves = new List<string>()
            {
                middleSpace,
                "0,0",
                "0," + (board.SizeOfBoard - 1),
                (board.SizeOfBoard - 1) + ",0",
                (board.SizeOfBoard - 1) + "," + (board.SizeOfBoard - 1)
            };
            
            List<string> freeSpaces = board.GetAllFreeSpaces();

            foreach (var move in idealMoves)
            {
                if (freeSpaces.Contains(move))
                {
                    return move;
                }
            }

            int randomIndex = _random.Next(0, freeSpaces.Count);
            return freeSpaces[randomIndex];
        }
    }
}