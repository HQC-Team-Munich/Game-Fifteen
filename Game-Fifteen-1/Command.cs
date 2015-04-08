using GameFifteen.Enumerations;

namespace GameFifteen
{
    using System;

    public static class Command
    {
        public static State CommandType(string input)
        {
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
                    throw new ArgumentException("Invalid Command!");
                    break;
            }

            return result;
        }
    }
}
