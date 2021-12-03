
namespace TicTacToe
{
    public abstract class Player
    {
        public string Name { get; }
        public string Marker { get; }
        public int Score { get; set; }
        public PlayerType Type { get; }
        
        public Player(string Name, string Marker, int score, PlayerType type)
        {
            this.Name = Name;
            this.Marker = Marker;
            Score = score;
            Type = type;
        }

        public void IncreaseScoreByOne()
        {
            Score += 1;
        }

        public virtual string GetPlayerMove(Board _board)
        {
            return "0";
        }
    }
}