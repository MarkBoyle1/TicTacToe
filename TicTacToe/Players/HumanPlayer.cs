using System.Collections.Generic;

namespace TicTacToe
{
    public class HumanPlayer : Player
    {
        private IUserInput _input;

        public HumanPlayer(string name, string marker, int score, IUserInput input)
        : base(name, marker, score, PlayerType.Human)
        {
            _input = input;
        }
        
        public override string GetPlayerMove(Board board)
        {
            return _input.GetUserInput();
        }
    }
}