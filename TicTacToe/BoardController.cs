using System;
using System.Linq;

namespace TicTacToe
{
    public class BoardController
    {
        public string[][] GenerateBoard()
        {
            string[][] board = new string[3][];
            board = board.Select
                (
                    x => new string[3].Select(x => ".").ToArray()
                )
                .ToArray();

            return board;
        }
        
        public string[][] UpdateBoard(string marker, int row, int column, string[][] board)
        {
            board[row][column] = marker;
            
            return board;
        }
    }
}