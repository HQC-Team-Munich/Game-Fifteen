using ConsoleApplication1.Enumerations;

namespace GameFifteenProject
{
    using System;

    static class Command
    {
        public static string CommandType(string input)
        {
            input = input.ToLower();
            string output;

            if (input == Commands.Exit.ToString() || input == Commands.Restart.ToString() || input == Commands.Top.ToString())
            {
                output = input;
            }
            else
            {
                throw new ArgumentException("Invalid Command!");
            }

            return output;
        }
    }
}
