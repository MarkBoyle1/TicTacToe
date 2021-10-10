namespace TicTacToe
{
    public class Player
    {
        public string Name { get; }
        public string Marker { get; }
        public Player(string name, string marker)
        {
            Name = name;
            Marker = marker;
        }
    }
}