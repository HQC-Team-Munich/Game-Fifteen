namespace GameFifteen
{
    using System;
    using System.Collections.Generic;

    using GameFifteen.Enumerations;

    public class Engine
    {
        private static void Menu()
        {
            var tiles = new List<Tile>();
            var moves = 0;
            var state = "restart";
            var gameFinished = false;

            while (state != "exit")
            {
                if (gameFinished == false)
                {
                    switch (state)
                    {
                        case "restart":
                            {
                                Console.WriteLine(Messages.WELCOME);
                                tiles = MatrixGenerator.GenerateMatrix();
                                tiles = MatrixGenerator.ShuffleMatrix(tiles);
                                gameFinished = Gameplay.IsMatrixSolved(tiles);
                                Gameplay.PrintMatrix(tiles);
                                break;
                            }

                        case "top":
                            {
                                Scoreboard.PrintScoreboard();
                                break;
                            }
                    }

                    if (gameFinished)
                    {
                        continue;
                    }

                    Console.Write(Messages.MOVEINPUT);
                    state = Console.ReadLine();

                    int destinationTileValue;

                    var isSuccessfulParsing = int.TryParse(state, out destinationTileValue);

                    if (isSuccessfulParsing)
                    {
                        try
                        {
                            Gameplay.MoveTiles(tiles, destinationTileValue);
                            moves++;
                            Gameplay.PrintMatrix(tiles);
                            gameFinished = Gameplay.IsMatrixSolved(tiles);
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
                    if (moves == 0)
                    {
                        Console.WriteLine(Messages.LOSE);
                    }
                    else
                    {
                        Console.WriteLine(Messages.WIN, moves);
                        Console.Write(Messages.HIGHSCORE);
                        var playerName = Console.ReadLine();
                        var player = new Player(playerName, moves);
                        Scoreboard.AddPlayer(player);
                        Scoreboard.PrintScoreboard();
                    }

                    state = "restart";
                    gameFinished = false;
                    moves = 0;
                }
            }
        }

        static void Main()
        {
            Menu();
        }
    }
}
