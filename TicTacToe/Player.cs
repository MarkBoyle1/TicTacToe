namespace TicTacToe
{
    public class Player
    {
        private string Name { get; }
        private string Marker { get; }
        private int Score { get; set; }
        public Player(string name, string marker)
        {
            Name = name;
            Marker = marker;
        }
    }
}