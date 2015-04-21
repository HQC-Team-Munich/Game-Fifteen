namespace GameFifteen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;

    public static class Scoreboard
    {
        private static List<IPlayer> players = new List<IPlayer>();

        public static void AddPlayer(IPlayer player)
        {
            players.Add(player);
            players.Sort();
            DeleteAllExceptTopPlayers();
        }

        public static void PrintScoreboard()
        {
            Console.WriteLine("Scoreboard:");
            foreach (IPlayer player in players)
            {
                string scoreboardLine = (players.IndexOf(player) + 1) +
                    ". " + player.Name + " --> " +
                    player.Moves + " moves";

                Console.WriteLine(scoreboardLine);
            }
        }

        private static void DeleteAllExceptTopPlayers()
        {
            players = players.Take(4).ToList();
        }
    }
}