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
            _testInput = "3";
        }

        public TestUserInput(string input)
        {
            _testInput = input;
        }
      

        public string GetUserInput()
        {
            string move = _listOfMoves[0];
            _listOfMoves.RemoveAt(0);
            
            return move;
        }
    }
}