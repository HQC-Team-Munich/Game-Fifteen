namespace GameFifteen.Models
{
    using System.Linq;

    using Constants;
    using Exceptions.TileExceptions;
    using Interfaces;

    public class Tile : ITile
    {
        #region Fields
        private string label;
        private int position;
        #endregion

        #region Constructors
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
                    throw new InvalidTileLabelException(Messages.InvalidTileLabelExceptionMessage);
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
                    throw new InvalidTilePositionException(Messages.InvalidTilePositionExceptionMessage);
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