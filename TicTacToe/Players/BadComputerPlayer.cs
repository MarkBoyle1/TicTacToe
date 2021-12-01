using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class BadComputerPlayer : Player
    {
        private Random _random = new Random();

        public BadComputerPlayer(string name, string marker)
            : base(name, marker)
        {
        }
        
        public override string GetPlayerMove(Board board)
        {
            List<string> freeSpaces = board.GetAllFreeSpaces();
            
            int randomIndex = _random.Next(0, freeSpaces.Count);

            return freeSpaces[randomIndex];
        }
    }
}