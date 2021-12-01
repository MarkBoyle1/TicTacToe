using System;

namespace TicTacToe
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name, string marker)
        : base(name, marker)
        {
        }
        
        public override string GetCoordinate(Board _board)
        {
            return Console.ReadLine();
        }
    }
}