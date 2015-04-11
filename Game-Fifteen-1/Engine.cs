namespace GameFifteen
{
    using System;
    using System.Collections.Generic;

    using Enumerations;

    public class Engine
    {
        private static void Menu()
        {
            var tiles = new List<Tile>();
            var movesCount = 0;
            var state = State.Restart;
            var isGameFinished = false;

            while (state != State.Exit)
            {
                if (isGameFinished == false)
                {
                    switch (state)
                    {
                        case State.Restart:
                        {
                            Console.WriteLine(Messages.WELCOME);
                            tiles = MatrixGenerator.GenerateMatrix();
                            tiles = MatrixGenerator.ShuffleMatrix(tiles);
                            isGameFinished = Gameplay.IsMatrixSolved(tiles);
                            Gameplay.PrintMatrix(tiles);
                            state = State.InGame;
                            break;
                        }

                        case State.InGame:
                        {
                            isGameFinished = Gameplay.IsMatrixSolved(tiles);
                            break;
                        }
                        case State.Top:
                        {
                            Scoreboard.PrintScoreboard();
                            break;
                        }
                    }

                    Console.Write(Messages.MOVEINPUT);
                    string input = Console.ReadLine();

                    int destinationTileValue;

                    var isSuccessfulParsing = int.TryParse(input, out destinationTileValue);

                    if (isSuccessfulParsing)
                    {
                        try
                        {
                            Gameplay.MoveTiles(tiles, destinationTileValue);
                            movesCount++;
                            Gameplay.PrintMatrix(tiles);
                            isGameFinished = Gameplay.IsMatrixSolved(tiles);
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
                            state = Command.CommandType(input);
                        }
                        catch (ArgumentException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                    }
                }
                else
                {
                    if (movesCount == 0)
                    {
                        Console.WriteLine(Messages.LOSE);
                    }
                    else
                    {
                        Console.WriteLine(Messages.WIN, movesCount);
                        Console.Write(Messages.HIGHSCORE);
                        var playerName = Console.ReadLine();
                        var player = new Player(playerName, movesCount);
                        Scoreboard.AddPlayer(player);
                        Scoreboard.PrintScoreboard();
                    }

                    state = State.Restart;
                    isGameFinished = false;
                    movesCount = 0;
                }
            }
        }

        static void Main()
        {
            Menu();
        }
    }
}