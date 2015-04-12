namespace GameFifteen.Exceptions.PlayerExceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidPlayerNameException : PlayerException
    {
        /// <summary>
        /// Invalid Player Name Exception Class
        /// </summary>
        public InvalidPlayerNameException() 
            : base()
        {
        }

        public InvalidPlayerNameException(string message) 
            : base(message)
        {
        }

        public InvalidPlayerNameException(string format, params object[] args) 
            : base(string.Format(format, args))
        {
        }

        public InvalidPlayerNameException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        public InvalidPlayerNameException(string format, Exception innerException, params object[] args)
                                         : base(string.Format(format, args), innerException)
        {
        }

        protected InvalidPlayerNameException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}