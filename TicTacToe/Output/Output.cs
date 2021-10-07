using System;

namespace TicTacToe
{
    public class Output : IOutput
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}