
using System;

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
        
        public Coordinates ConvertInputIntoCoordinates(string input)
        {
            string[] stringArray = input.Split(',');
            
            int row = Convert.ToInt32(stringArray[0]);
            int column = Convert.ToInt32(stringArray[1]);
            
            return  new Coordinates(row, column);
        }

        public virtual Coordinates GetPlayerMove(Board _board)
        {
            return null;
        }
    }
}