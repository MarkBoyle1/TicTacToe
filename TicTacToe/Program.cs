using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInput input = new UserInput();
            IOutput output = new Output();
            Gameplay gamePlay = new Gameplay(input, output, new GameSetUp(input, output));
            gamePlay.RunProgram();
        }
    }
}