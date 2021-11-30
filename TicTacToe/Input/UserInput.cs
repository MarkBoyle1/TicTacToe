using System;

namespace TicTacToe
{
    public class UserInput : IUserInput
    {
        public string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}