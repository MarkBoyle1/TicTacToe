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
            foreach (var row in board._board)
            {
                Console.WriteLine(String.Join(',', row).Replace(',', ' '));
            }
        }
    }
}