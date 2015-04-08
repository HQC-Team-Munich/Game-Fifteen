namespace GameFifteenProject
{
    using System;

    class Tile : IComparable
    {
        public Tile()
        {
            
        }

        public Tile(string label, int position)
        {
            this.Label = label;
            this.Position = position;
        }

        public string Label { get; private set; }

        public int Position{ get; set; }

        public int CompareTo(object tile)
        {
            var currentTile = (Tile)tile;
            var result = this.Position.CompareTo(currentTile.Position);

            return result;
        }
    }
}