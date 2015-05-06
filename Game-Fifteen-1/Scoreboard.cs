namespace GameFifteen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Text.RegularExpressions;

    using GameFifteen.Models;
    using Interfaces;

    public static class Scoreboard
    {
        private static List<IPlayer> players = new List<IPlayer>();

        /// <summary>
        /// Adds a new player to the game
        /// </summary>
        /// <param name="player">The player object to be added</param>
        public static void AddPlayer(IPlayer player)
        {
            LoadData();
            players.Add(player);
            players = players.OrderBy(p => p.Moves).ToList();
            DeleteAllExceptTopPlayers();
        }

        /// <summary>
        /// Prints the scoreboard of the game in a friendly format.
        /// </summary>
        public static void PrintScoreboard()
        {
            LoadData();

            Console.WriteLine("Scoreboard:");
            foreach (IPlayer player in players)
            {
                string scoreboardLine = (players.IndexOf(player) + 1) +
                    ". " + player.Name + " --> " +
                    player.Moves + " moves";

                Console.WriteLine(scoreboardLine);
            }
        }

        private static void LoadData()
        {
            if (players.Count == 0)
            {
                if (!File.Exists("scoreboard.txt"))
                {
                    File.Create("scoreboard.txt");
                }

                using (StreamReader reader = new StreamReader("scoreboard.txt"))
                {
                    Regex regex = new Regex(@"\d+\.\s+(.+)\s+-->\s+(\d+).+");

                    string current = reader.ReadLine();

                    while (current != null)
                    {
                        Match match = regex.Match(current);
                        current = reader.ReadLine();

                        players.Add(new Player(match.Groups[1].Value, Int32.Parse(match.Groups[2].Value)));
                    }
                }

                players = players.OrderBy(player => player.Moves).ToList();
                DeleteAllExceptTopPlayers();
            }
        }

        public static void Save()
        {
            using (StreamWriter writer = new StreamWriter("scoreboard.txt"))
            {
                players.ForEach(player =>
                {
                    string scoreboardLine = (players.IndexOf(player) + 1) +
                       ". " + player.Name + " --> " +
                       player.Moves + " moves";

                    writer.WriteLine(scoreboardLine);
                });
            }
        }

        private static void DeleteAllExceptTopPlayers()
        {
            players = players.Take(5).ToList();
        }
    }
}