﻿using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Gameplay gameplay = new Gameplay(new UserInput(), new Output());
            gameplay.RunProgram();
        }
    }
}