using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInput input = new UserInput();
            IOutput output = new Output();
            Gameplay gameSetUp = new Gameplay(input, output, new GameSetUp(input, output));
            gameSetUp.RunProgram();
        }
    }
}