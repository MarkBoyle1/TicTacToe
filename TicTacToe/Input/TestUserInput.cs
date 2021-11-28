using System.Collections.Generic;

namespace TicTacToe
{
    public class TestUserInput : IUserInput
    {
        private List<string> _listOfMoves;
        private string _testInput;
        public TestUserInput(List<string> listOfMoves)
        {
            _listOfMoves = listOfMoves;
        }

        public TestUserInput(string input)
        {
            _testInput = input;
        }
        public string GetCoordinates()
        {
            string move = _listOfMoves[0];
            _listOfMoves.RemoveAt(0);
            
            return move;
        }

        public string GetUserInput()
        {
            return _testInput;
        }
    }
}