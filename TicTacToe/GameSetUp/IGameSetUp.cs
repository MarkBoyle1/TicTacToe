namespace TicTacToe
{
    public interface IGameSetUp
    {
        GameState SetUpNewGame();
        GameState LoadPreviousGame();
    }
}