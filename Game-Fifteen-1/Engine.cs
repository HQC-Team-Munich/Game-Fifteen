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
            var state = State.Restart;
            var gameFinished = false;

            while (state != State.Exit)
            {
                if (gameFinished == false)
                {
                    switch (state)
                    {
                        case State.Restart:
                        {
                            Console.WriteLine(Messages.WELCOME);
                            tiles = MatrixGenerator.GenerateMatrix();
                            tiles = MatrixGenerator.ShuffleMatrix(tiles);
                            gameFinished = Gameplay.IsMatrixSolved(tiles);
                            Gameplay.PrintMatrix(tiles);
                            state = State.InGame;
                            break;
                        }

                        case State.InGame:
                        {
                            gameFinished = Gameplay.IsMatrixSolved(tiles);
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

                    state = State.Restart;
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
