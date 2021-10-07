namespace TicTacToe
{
    public interface IOutput
    {
        public void DisplayMessage(string message);

        public void DisplayBoard(string[][] board);
    }
}