namespace GameFifteen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;

    public static class Scoreboard
    {
        private static readonly List<IPlayer> Players = new List<IPlayer>();

        public static void AddPlayer(IPlayer player)
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