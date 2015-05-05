namespace GameFifteen.Exceptions.TileExceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidTileNeighbourException : InvalidTilePositionException
    {
        /// <summary>
        /// Invalid Tile Neighbour Exception Class
        /// </summary>
        public InvalidTileNeighbourException()
            : base()
        {
        }

        public InvalidTileNeighbourException(string message)
            : base(message)
        {
        }

        public InvalidTileNeighbourException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public InvalidTileNeighbourException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public InvalidTileNeighbourException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected InvalidTileNeighbourException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
