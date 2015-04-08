namespace GameFifteenProject
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private static void Menu()
        {
            var tiles = new List<Tile>();
            var cnt = 0;
            var state = "restart";
            var flag = false;

            while (state != "exit")
            {
                if (!flag)
                {
                    switch (state)
                    {
                        case "restart":
                            {
                                var welcomeMessage = "Welcome to the game “15”. Please try to arrange the numbers sequentially. ";
                                welcomeMessage = welcomeMessage + "\nUse 'top' to view the top scoreboard, 'restart' to start a new game and 'exit'";
                                welcomeMessage = welcomeMessage + " \nto quit the game.";
                                Console.WriteLine();
                                Console.WriteLine(welcomeMessage);
                                tiles = MatrixGenerator.GenerateMatrix();
                                tiles = MatrixGenerator.ShuffleMatrix(tiles);
                                flag = Gameplay.IsMatrixSolved(tiles);
                                Gameplay.PrintMatrix(tiles);
                                break;
                            }

                        case "top":
                            {
                                Scoreboard.PrintScoreboard();
                                break;
                            }
                    }

                    if (flag)
                    {
                        continue;
                    }

                    Console.Write("Enter a number to move: ");
                    state = Console.ReadLine();

                    int destinationTileValue;

                    var isSuccessfulParsing = int.TryParse(state, out destinationTileValue);

                    if (isSuccessfulParsing)
                    {
                        try
                        {
                            Gameplay.MoveTiles(tiles, destinationTileValue);
                            cnt++;
                            Gameplay.PrintMatrix(tiles);
                            flag = Gameplay.IsMatrixSolved(tiles);
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            state = Command.CommandType(state);
                        }
                        catch (ArgumentException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                    }
                }
                else
                {
                    if (cnt == 0)
                    {
                        Console.WriteLine("Your matrix was solved by default :) Come on - NEXT try");
                    }
                    else
                    {
                        Console.WriteLine("Congratulations! You won the game in {0} moves.", cnt);
                        Console.Write("Please enter your name for the top scoreboard: ");
                        var playerName = Console.ReadLine();
                        var player = new Player(playerName, cnt);
                        Scoreboard.AddPlayer(player);
                        Scoreboard.PrintScoreboard();
                    }

                    state = "restart";
                    flag = false;
                    cnt = 0;
                }
            }
        }

        static void Main()
        {
            Menu();
        }
    }
}
