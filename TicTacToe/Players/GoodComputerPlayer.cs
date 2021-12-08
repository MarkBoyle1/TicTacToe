using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class GoodComputerPlayer : Player
    {
        private Random _random;
        
        public GoodComputerPlayer(string name, string marker, int score)
            : base(name, marker, score, PlayerType.GoodComputer)
        {
            _random = new Random();
        }
        
        public override Coordinates GetPlayerMove(Board board)
        {
            Coordinates answer = CheckColumns(board);
            answer = answer == null ? CheckRows(board) : answer;
            answer = answer == null ? CheckTopLeftToBottomRight(board) : answer;
            answer = answer == null ? CheckTopRightToBottomLeft(board) : answer;
            answer = answer == null ? GetNextMove(board) : answer;

            return answer;
        }
        
        private Coordinates CheckColumns(Board board)
        {
            for(int column = 0; column < board.SizeOfBoard; column++)
            {
                string[] columnArray = board.GetColumn(column);
                if (columnArray.Distinct().Count() == 2 && columnArray.Count(x => x == Constants.FreeSpace) == 1)
                {
                    int indexOfFreeSpace = Array.IndexOf(columnArray, Constants.FreeSpace);
                    return new Coordinates(indexOfFreeSpace, column);
                }
            }

            return null;
        }
        
        private Coordinates CheckRows(Board board)
        {
            for(int row = 0; row < board.SizeOfBoard; row++)
            {
                string[] rowArray = board.GetRow(row);
                if (rowArray.Distinct().Count() == 2 && rowArray.Count(x => x == Constants.FreeSpace) == 1)
                {
                    int indexOfFreeSpace = Array.IndexOf(rowArray, Constants.FreeSpace);
                    return new Coordinates(row, indexOfFreeSpace);
                }
            }

            return null;
        }
        
        private Coordinates CheckTopLeftToBottomRight(Board board)
        {
            string[] diagonalSlopeRight = board.GetDiangonalTopLeftToBottomRight();

            if (diagonalSlopeRight.Distinct().Count() == 2 && diagonalSlopeRight.Count(x => x == Constants.FreeSpace) == 1)
            {
                int indexOfFreeSpace = Array.IndexOf(diagonalSlopeRight, Constants.FreeSpace);
                return new Coordinates(indexOfFreeSpace, indexOfFreeSpace);
            }
            
            return null;
        }
        
        private Coordinates CheckTopRightToBottomLeft(Board board)
        {
            string[] diagonalSlopeLeft = board.GetDiangonalTopRightToBottomLeft();

            if (diagonalSlopeLeft.Distinct().Count() == 2 && diagonalSlopeLeft.Count(x => x == Constants.FreeSpace) == 1)
            {
                int indexOfFreeSpace = Array.IndexOf(diagonalSlopeLeft, Constants.FreeSpace);
                return new Coordinates(indexOfFreeSpace, (board.SizeOfBoard - indexOfFreeSpace - 1));
            }
            
            return null;
        }

        private Coordinates GetNextMove(Board board)
        {
            List<Coordinates> idealMoves = new List<Coordinates>()
            {
                new Coordinates(0,0),
                new Coordinates(0,(board.SizeOfBoard - 1)),
                new Coordinates((board.SizeOfBoard - 1),0),
                new Coordinates((board.SizeOfBoard - 1),(board.SizeOfBoard - 1))
            };

            if (board.SizeOfBoard % 2 != 0)
            {
                Coordinates middleSpace = new Coordinates((board.SizeOfBoard / 2),(board.SizeOfBoard / 2));
                idealMoves.Insert(0, middleSpace);
            }

            List<Coordinates> freeSpaces = board.GetAllFreeSpaces();

            foreach (var move in idealMoves)
            {
                foreach (var freeSpace in freeSpaces)
                {
                    if (freeSpace.GetRow() == move.GetRow() && freeSpace.GetColumn() == move.GetColumn())
                    {
                        return move;
                    }
                }
            }

            int randomIndex = _random.Next(0, freeSpaces.Count);
            return freeSpaces[randomIndex];
        }
    }
}