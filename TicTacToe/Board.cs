using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        public string[][] board { get; }
        public int SizeOfBoard { get; }

        public Board(string[][] board, int sizeOfBoard)
        {
            SizeOfBoard = sizeOfBoard;
            this.board = board;
        }
        
        public string[] GetRow(int row)
        {
            return board[row];
        }
        
        public string[] GetColumn(int column)
        {
            string[] columnValues = new string[SizeOfBoard];
            
            for(int row = 0; row < SizeOfBoard; row++)
            {
                columnValues[row] = board[row][column];
            }

            return columnValues;
        }
        
        public string[] GetDiangonalTopLeftToBottomRight()
        {
            List<string> diagonalSlopeRight = new List<string>();

            for(int i = 0; i < SizeOfBoard; i++)
            {
                diagonalSlopeRight.Add(GetPoint(i,i));
            }
            
            return diagonalSlopeRight.ToArray();
        }
        
        public string[] GetDiangonalTopRightToBottomLeft()
        {
            List<string> diagonalSlopeLeft = new List<string>();

            for(int row = 0, column = SizeOfBoard - 1; row < SizeOfBoard; row++, column--)
            {
                diagonalSlopeLeft.Add(GetPoint(row, column));
            }
            
            return diagonalSlopeLeft.ToArray();
        }

        public string GetPoint(int row, int column)
        {
            return board[row][column];
        }

        public int GetNumberOfFreeSpaces()
        {
            int numberOfFreeSpaces = 0;
            
            foreach (var row in board)
            {
                numberOfFreeSpaces += row.Count(x => x == ".");
            }

            return numberOfFreeSpaces;
        }

        public List<string> GetAllFreeSpaces()
        {
            List<string> freeSpaces = new List<string>();

            for (int i = 0; i < SizeOfBoard; i++)
            {
                for (int j = 0; j < SizeOfBoard; j++)
                {
                    if (board[i][j] == ".")
                    {
                        freeSpaces.Add(i + "," + j);
                    }
                }
            }

            return freeSpaces;
        }
    }
}