using System.Linq;

namespace TicTacToe
{
    public class BoardFactory
    {
        public Board GenerateInitialBoard(int sizeOfBoard)
        {
            string[][] board = new string[sizeOfBoard][];
            board = board.Select
                (
                    x => new string[sizeOfBoard].Select(x => ".").ToArray()
                )
                .ToArray();
            
            return new Board(board, sizeOfBoard);
        }
        
        public Board GenerateUpdatedBoard(string marker, Coordinates coordinates, Board board)
        {
            int sizeOfBoard = board.GetRow(0).Length;

            string[][] updatedBoard = new string[sizeOfBoard][];
            updatedBoard = updatedBoard.Select(x => new string[sizeOfBoard]).ToArray();
                
            for(int i = 0; i < sizeOfBoard; i++)
            {
                for (int j = 0; j < sizeOfBoard; j++)
                {
                    updatedBoard[i][j] = board.GetPoint(i, j);
                }
            }

            updatedBoard[coordinates.GetRow()][coordinates.GetColumn()] = marker;
            
            return new Board(updatedBoard, sizeOfBoard);
        }
    }
}