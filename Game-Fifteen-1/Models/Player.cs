namespace GameFifteen
{
    using System;

    public class Player : IComparable
    {
        public Player(string name, int moves)
        {
            this.Name = name;
            this.Moves = moves;
        }

        public string Name { get; private set; }

        public int Moves { get; private set; }

        public int CompareTo(object player)
        {
            var currentPlayer = (Player)player;
            var result = this.Moves.CompareTo(currentPlayer.Moves);
            return result;
        }
    }
}
