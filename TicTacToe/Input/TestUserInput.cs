using System.Collections.Generic;

namespace TicTacToe
{
    public class TestUserInput : IUserInput
    {
        private List<string> _listOfMoves;
        public TestUserInput(List<string> listOfMoves)
        {
            _listOfMoves = listOfMoves;
        }
        public string GetCoordinates()
        {
            string move = _listOfMoves[0];
            _listOfMoves.RemoveAt(0);
            
            return move;
        }
    }
}