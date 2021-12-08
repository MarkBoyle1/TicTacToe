using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class BadComputerPlayer : Player
    {
        private Random _random;
        
        public BadComputerPlayer(string name, string marker, int score)
            : base(name, marker, score, PlayerType.BadComputer)
        {
            _random = new Random();
        }
        
        public override Coordinates GetPlayerMove(Board board)
        {
            List<Coordinates> freeSpaces = board.GetAllFreeSpaces();
            
            int randomIndex = _random.Next(0, freeSpaces.Count);

            return freeSpaces[randomIndex];
        }
    }
}