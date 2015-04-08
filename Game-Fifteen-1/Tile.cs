namespace GameFifteenProject
{
    using System;

    class Tile : IComparable
    {
        pripublic vate readonly string label;
        private int position;

        public Tile(string label, int position)
        {
            this.label = label;
            this.position = position;
        }

        public string Label
        {
            get { return this.label; }
        }

        public int Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public Tile()
        {
        }

        public int CompareTo(object tile)
        {
            var currentTile = (Tile)tile;
            var result = this.position.CompareTo(currentTile.Position);

            return result;
        }
    }
}