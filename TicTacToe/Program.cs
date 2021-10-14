using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            GameSetUp gameSetUp = new GameSetUp(new UserInput(), new Output());
            gameSetUp.RunProgram();
        }
    }
}