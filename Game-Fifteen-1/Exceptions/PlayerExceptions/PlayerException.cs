namespace GameFifteen.Exceptions.PlayerExceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class PlayerException : GameException
    {
        /// <summary>
        /// Main Player Exception Class
        /// </summary>
        public PlayerException() : base()
        {
        }

        public PlayerException(string message) 
            : base(message)
        {
        }

        public PlayerException(string format, params object[] args) 
            : base(string.Format(format, args))
        {
        }

        public PlayerException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        public PlayerException(string format, Exception innerException, params object[] args) 
            : base(string.Format(format, args), innerException)
        {
        }

        protected PlayerException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}