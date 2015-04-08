namespace GameFifteenProject
{
    using System;

    public class Player : IComparable
    {
        private readonly string name;
        private readonly int moves;

        public Player(string name, int moves)
        {
            this.name = name;
            this.moves = moves;
        }

        public string Name
        {
            get { return this.name; }
        }

        public int Moves
        {
            get { return this.moves; }
        }

        public int CompareTo(object player)
        {
            var currentPlayer = (Player)player;
            var result = this.moves.CompareTo(currentPlayer.Moves);
            return result;
        }
    }
}
