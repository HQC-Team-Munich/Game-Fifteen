namespace GameFifteen
{
    using System;
    using Constants;
    using Enumerations;
    using Exceptions.CommandExceptions;

    public static class Command
    {
        /// <summary>
        /// This method is processing the commands entered by the user.
        /// </summary>
        /// <exception cref="InvalidCommandException"></exception>
        /// <exception cref="CommandIsNullException"></exception>
        public static State CommandType(string input)
        {
            if(input == null)
            {
                throw new CommandIsNullException(Messages.CommandIsNullExceptionMessage);
            }

            input = input.ToLower();
            State result;

            switch (input)
            {
                case "restart":
                    result = State.Restart;
                    break;

                case "exit":
                    result = State.Exit;
                    break;

                case "top":
                    result = State.Top;
                    break;

                default:
                    throw new InvalidCommandException(Messages.InvalidCommandExceptionMessage);
                    
            }

            return result;
        }
    }
}