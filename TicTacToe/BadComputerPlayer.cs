using System;

namespace TicTacToe
{
    public class BadComputerPlayer : Player
    {
        private Random _random = new Random();

        public BadComputerPlayer(string name, string marker)
            : base(name, marker)
        {
        }
        
        public override string GetCoordinate(Board board)
        {
            int randomRow = _random.Next(1, board.SizeOfBoard + 1);
            int randomColumn= _random.Next(1, board.SizeOfBoard + 1);

            return randomRow + "," + randomColumn;
        }
    }
}