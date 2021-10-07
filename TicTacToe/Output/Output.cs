using System;

namespace TicTacToe
{
    public class Output : IOutput
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayBoard(string[][] board)
        {
            foreach (var row in board)
            {
                Console.WriteLine(String.Join(',', row).Replace(',', ' '));
            }
        }
    }
}