namespace GameFifteen
{
    using System;

    static class Command
    {
        public static string CommandType(string input)
        {
            input = input.ToLower();
            string output;

            switch (input)
            {
                case "restart":
                case "exit":
                case "top":
                    output = input;
                    break;
                default:
                    throw new ArgumentException("Invalid Command!");
            }

            return output;
        }
    }
}
