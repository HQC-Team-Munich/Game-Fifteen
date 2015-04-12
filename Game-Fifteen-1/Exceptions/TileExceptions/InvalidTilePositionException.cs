namespace GameFifteen.Exceptions.TileExceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidTilePositionException : TileException
    {
        /// <summary>
        /// Invalid Tile Position Exception Class
        /// </summary>
        public InvalidTilePositionException() : base()
        {
        }

        public InvalidTilePositionException(string message) 
            : base(message)
        {
        }

        public InvalidTilePositionException(string format, params object[] args) 
            : base(string.Format(format, args))
        {
        }

        public InvalidTilePositionException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        public InvalidTilePositionException(string format, Exception innerException, params object[] args)
                                           : base(string.Format(format, args), innerException)
        {
        }

        protected InvalidTilePositionException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}