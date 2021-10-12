namespace TicTacToe
{
    public interface IOutput
    {
        public void DisplayMessage(string message);

        public void DisplayBoard(Board board, int sizeOfBoard);
    }
}