namespace GameFifteen.Exceptions.CommandExceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class CommandIsNullException : InvalidCommandException
    {
        /// <summary>
        /// Command Is Null Exception Class
        /// This Exception is thrown when the user enters null as command.
        /// </summary>
        public CommandIsNullException()
            : base()
        {
        }

        public CommandIsNullException(string message)
            : base(message)
        {
        }

        public CommandIsNullException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public CommandIsNullException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public CommandIsNullException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected CommandIsNullException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}