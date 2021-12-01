using System.Collections.Generic;

namespace TicTacToe
{
    public class TestPlayer : Player
    {
        private List<string> _listOfMoves;
        
        public TestPlayer(string name, string marker, List<string> moves)
            : base(name, marker)
        {
            _listOfMoves = moves;
        }
        
        public override string GetPlayerMove(Board board)
        {
            string move = _listOfMoves[0];
            _listOfMoves.RemoveAt(0);
            
            return move;
        }
    }
}