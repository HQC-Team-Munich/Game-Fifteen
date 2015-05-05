namespace GameFifteen.Exceptions.PlayerExceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidPlayerMoveCountException : PlayerException
    {
        /// <summary>
        /// Invalid Player Move Count Exception Class
        /// </summary>
        public InvalidPlayerMoveCountException() : base()
        {
        }

        public InvalidPlayerMoveCountException(string message) 
            : base(message)
        {
        }

        public InvalidPlayerMoveCountException(string format, params object[] args) 
            : base(string.Format(format, args))
        {
        }

        public InvalidPlayerMoveCountException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        public InvalidPlayerMoveCountException(string format, Exception innerException, params object[] args)
                                          : base(string.Format(format, args), innerException)
        {
        }

        protected InvalidPlayerMoveCountException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}