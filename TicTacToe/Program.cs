﻿
namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInput input = new UserInput();
            IOutput output = new Output();
            Gameplay gamePlay = new Gameplay(input, output, new GameSetUp(input, output, Constants.SavedGameStateFilePath));
            gamePlay.RunProgram();
        }
    }
}