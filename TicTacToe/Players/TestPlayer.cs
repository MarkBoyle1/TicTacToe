using System.Collections.Generic;

namespace TicTacToe
{
    public class TestPlayer : Player
    {
        private List<string> _listOfMoves;
        
        public TestPlayer(string name, string marker, int score, PlayerType type, List<string> moves)
            : base(name, marker, score, type)
        {
            _listOfMoves = moves;
        }
        
        public override Coordinates GetPlayerMove(Board board)
        {
            string move = _listOfMoves[0];
            _listOfMoves.RemoveAt(0);
            
            return ConvertInputIntoCoordinates(move);
        }
    }
}