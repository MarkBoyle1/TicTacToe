namespace TicTacToe
{
    public class Player
    {
        public string Name { get; }
        public string Marker { get; }
        public int Score { get; set; }
        public Player(string name, string marker)
        {
            Name = name;
            Marker = marker;
        }

        public void IncreaseScoreByOne()
        {
            Score += 1;
        }
    }
}