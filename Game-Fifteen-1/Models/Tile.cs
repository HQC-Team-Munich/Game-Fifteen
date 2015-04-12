namespace GameFifteen.Models
{
    using System;
    using System.Linq;
    using Exceptions.TileExceptions;

    public class Tile : IComparable
    {
        #region Fields
        private string label;
        private int position;
        #endregion

        #region Contructors
        public Tile()
        {

        }

        public Tile(string label, int position)
        {
            this.Label = label;
            this.Position = position;
        }
        #endregion


        #region Properties
        public string Label
        {
            get { return this.label; }

            private set
            {
                if (!value.All(char.IsLetterOrDigit))
                {
                    throw new InvalidTileLabelException("The tile label should consist of only letters and digits.");
                }

                this.label = value;
            }
        }

        public int Position
        {
            get
            {
                return this.position;
            }

            set
            {
                if (value < 0)
                {
                    throw new InvalidTilePositionException("The position of the title can not be a negative number.");
                }

                this.position = value;
            }
        }
        #endregion

        #region Methods
        public int CompareTo(object tile)
        {
            var currentTile = (Tile) tile;
            var result = this.Position.CompareTo(currentTile.Position);

            return result;
        }
        #endregion
    }
}