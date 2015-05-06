namespace GameFifteen.Interfaces
{
    using System;
    using Exceptions.TileExceptions;

    public interface ITile : IComparable
    {
        /// <summary>
        /// The current position of the tile in the game. Can be changed in-game.
        /// </summary>
        /// <exception cref="InvalidTilePositionException">
        /// Thrown when the position of the tile is a negative number.
        /// </exception>
        int Position { get;  set; }

        /// <summary>
        /// A string variable determining the label of the tile in the game. 
        /// </summary>
        /// <exception cref="InvalidTileLabelException">
        /// Thrown when the value is not a letter or digit.
        /// </exception>
        string Label { get; }
    }
}
