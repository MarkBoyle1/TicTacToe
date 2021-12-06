using System.Collections.Generic;

namespace TicTacToe
{
    public class HumanPlayer : Player
    {
        private IUserInput _input;
        private IOutput _output;
        
        public HumanPlayer(string name, string marker, int score, IUserInput input, IOutput output)
        : base(name, marker, score, PlayerType.Human)
        {
            _input = input;
            _output = output;
        }
        
        public override string GetPlayerMove(Board board)
        {
            string response = _input.GetUserInput();
            
            List<string> freeSpaces = board.GetAllFreeSpaces();
            
            while (!freeSpaces.Contains(response) && response != Constants.Quit && response != Constants.Save)
            {
                _output.DisplayMessage(OutputMessages.InvalidInput);
                response = _input.GetUserInput();
            }
            
            return response;
        }
    }
}