namespace GameFifteen.Exceptions.PlayerExceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidPlayerMovesException : PlayerException
    {
        /// <summary>
        /// Invalid Player Moves Exception Class
        /// </summary>
        public InvalidPlayerMovesException() : base()
        {
        }

        public InvalidPlayerMovesException(string message) 
            : base(message)
        {
        }

        public InvalidPlayerMovesException(string format, params object[] args) 
            : base(string.Format(format, args))
        {
        }

        public InvalidPlayerMovesException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        public InvalidPlayerMovesException(string format, Exception innerException, params object[] args)
                                          : base(string.Format(format, args), innerException)
        {
        }

        protected InvalidPlayerMovesException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}