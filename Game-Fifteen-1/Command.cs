namespace GameFifteenProject
{
    using System;

    static class Command
    {
        private enum Commands
        {
            Restart,
            Top,
            Exit
        }

        public static string CommandType(string input)
        {
            var inputToLower = input.ToLower();
            string output;

            if (inputToLower == Commands.Exit.ToString() || inputToLower == Commands.Restart.ToString() || inputToLower == Commands.Top.ToString())
            {
                output = inputToLower;
            }
            else
            {
                throw new ArgumentException("Invalid Command!");
            }

            return output;
        }
    }
}
