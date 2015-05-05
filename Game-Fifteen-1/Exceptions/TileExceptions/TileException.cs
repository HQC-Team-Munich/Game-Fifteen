namespace GameFifteen.Exceptions.TileExceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TileException : GameException
    {
        /// <summary>
        /// Main Tile Exception Class
        /// </summary>
        public TileException() : base()
        {
        }

        public TileException(string message) 
            : base(message)
        {
        }

        public TileException(string format, params object[] args) 
            : base(string.Format(format, args))
        {
        }

        public TileException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        public TileException(string format, Exception innerException, params object[] args)
                            : base(string.Format(format, args), innerException)
        {
        }

        protected TileException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}