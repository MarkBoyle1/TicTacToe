using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            GameSetUp gameplay = new GameSetUp(new UserInput(), new Output());
            gameplay.RunProgram();
        }
    }
}