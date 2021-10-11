using System;
using System.Linq;

namespace TicTacToe
{
    public class BoardController
    {
        public Board GenerateBoard()
        {
            string[][] board = new string[3][];
            board = board.Select
                (
                    x => new string[3].Select(x => ".").ToArray()
                )
                .ToArray();

            return new Board(board);
        }
        
        public Board UpdateBoard(string marker, int row, int column, Board board)
        {
            board._board[row][column] = marker;
            
            return board;
        }
    }
}