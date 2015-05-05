namespace GameFifteen.Exceptions.CommandExceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidCommandException : GameException
    {
        /// <summary>
        /// Main Invalid Command Exception Class
        /// This Exception is thrown when an invalid command is entered.
        /// </summary>
        public InvalidCommandException()
            : base()
        {
        }

        public InvalidCommandException(string message)
            : base(message)
        {
        }

        public InvalidCommandException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public InvalidCommandException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public InvalidCommandException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected InvalidCommandException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}