using System;
using System.Collections.Generic;
using System.Threading;

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
            Console.Clear();
            for(int row = 0; row < board.SizeOfBoard; row++)
            {
                Console.WriteLine(String.Join(',', board.GetRow(row)).Replace(',', ' '));
            }
            Thread.Sleep(200);
        }

        public void DisplayScores(List<Player> playerList)
        {
            Console.WriteLine(OutputMessages.CurrentScores);
            Console.WriteLine(playerList[0].Name + ": " + playerList[0].Score);
            Console.WriteLine(playerList[1].Name + ": " + playerList[1].Score);
        }
    }
}