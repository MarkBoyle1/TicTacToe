using System;

namespace TicTacToe
{
    public class Output : IOutput
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayBoard(Board board)
        {
            for(int row = 0; row < board.SizeOfBoard; row++)
            {
                Console.WriteLine(String.Join(',', board.GetRow(row)).Replace(',', ' '));
            }
        }
    }
}