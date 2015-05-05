namespace GameFifteen.Exceptions.TileExceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TilePositionOutOfRangeException : InvalidTilePositionException
    {
        /// <summary>
        /// Tile Position Out Of Range Exception Class
        /// This Exception is thrown if the tile position is not in the [0-15] range.
        /// </summary>
        public TilePositionOutOfRangeException()
            : base()
        {
        }

        public TilePositionOutOfRangeException(string message)
            : base(message)
        {
        }

        public TilePositionOutOfRangeException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public TilePositionOutOfRangeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public TilePositionOutOfRangeException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected TilePositionOutOfRangeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
