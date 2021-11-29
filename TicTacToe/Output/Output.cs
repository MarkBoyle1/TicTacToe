using System;
using System.Collections.Generic;

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
            for(int row = 0; row < board.SizeOfBoard; row++)
            {
                Console.WriteLine(String.Join(',', board.GetRow(row)).Replace(',', ' '));
            }
        }

        public void DisplayScores(List<Player> playerList)
        {
            Console.WriteLine("Current Scores:");
            Console.WriteLine(playerList[0].Name + ": " + playerList[0].Score);
            Console.WriteLine(playerList[1].Name + ": " + playerList[1].Score);
        }
    }
}