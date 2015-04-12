namespace GameFifteen.Exceptions.TileExceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidTileLabelException : TileException
    {
        /// <summary>
        /// Invalid Tile Label Exception Class
        /// </summary>
        public InvalidTileLabelException() : base()
        {
        }

        public InvalidTileLabelException(string message) 
            : base(message)
        {
        }

        public InvalidTileLabelException(string format, params object[] args) 
            : base(string.Format(format, args))
        {
        }

        public InvalidTileLabelException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        public InvalidTileLabelException(string format, Exception innerException, params object[] args)
                                        : base(string.Format(format, args), innerException)
        {
        }

        protected InvalidTileLabelException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}