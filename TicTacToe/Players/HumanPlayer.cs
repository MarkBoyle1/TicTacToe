using System.Collections.Generic;
using TicTacToe.Exceptions;

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
        
        public override Coordinates GetPlayerMove(Board board)
        {
            _output.DisplayBoard(board);

            _output.DisplayMessage(Name + OutputMessages.EnterNextMove);

            string input = _input.GetUserInput();

            if (input == Constants.Quit)
            {
                throw new InputIsQuitException();
            }
            
            if (input == Constants.Save)
            {
                throw new InputIsSaveException();
            }
            
            List<Coordinates> freeSpaces = board.GetAllFreeSpaces();

            List<string> possibleInputs = new List<string>();

            foreach (var freeSpace in freeSpaces)
            {
                string freeSpaceInput = freeSpace.GetRow() + "," + freeSpace.GetColumn();
                possibleInputs.Add(freeSpaceInput);
            }
            
            while (!possibleInputs.Contains(input))
            {
                _output.DisplayMessage(OutputMessages.InvalidInput);
                input = _input.GetUserInput();
            }
            
            Coordinates coordinates = ConvertInputIntoCoordinates(input);

            return coordinates;
        }
    }
}