namespace GameFifteenProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Scoreboard
    {
        private static readonly List<Player> Players = new List<Player>();

        public static void AddPlayer(Player player)
        {
            Players.Add(player);
            Players.Sort();
            DeleteAllExceptTopPlayers();
        }

        public static void PrintScoreboard()
        {
            Console.WriteLine("Scoreboard:");
            foreach (var scoreboardLine in Players.Select(player => (Players.IndexOf(player) + 1).ToString() + ". " + player.Name + " --> " + player.Moves.ToString() + " moves"))
            {
                Console.WriteLine(scoreboardLine);
            }
        }

        private static void DeleteAllExceptTopPlayers()
        {
            for (var index = 0; index < Players.Count(); index++)
            {
                if (index > 4)
                {
                    Players.Remove(Players[index]);
                }
            }
        }
    }
}