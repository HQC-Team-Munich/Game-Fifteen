namespace GameFifteen
{
    using System;
    using System.Collections.Generic;

    using Enumerations;
    using Interfaces;
    using Constants;
    using Models;

    public class Engine
    {
        private static List<ITile> tiles;
        private static int movesCount;
        private static State gameState;
        private static bool isGameFinished;

        private static Engine instance = null;

        public Engine()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                throw new Exception("You can only have one instance of this class.");
            }
        }

        private static void Menu()
        {
            tiles = new List<ITile>();
            movesCount = 0;
            gameState = State.Restart;
            isGameFinished = false;

            while (gameState != State.Exit)
            {
                if (!isGameFinished)
                {
                    ResolveGameState();

                    Console.Write(Messages.MoveInput);
                    string input = Console.ReadLine();

                    ProceedMove(input);
                }
                else
                {
                    ProceedGameOver();
                }
            }
        }

        private static void ResolveGameState()
        {
            switch (gameState)
            {
                case State.Restart:
                    tiles = RestartGame(tiles);
                    break;

                case State.InGame:
                    isGameFinished = Gameplay.IsMatrixSolved(tiles);
                    break;

                case State.Top:
                    Scoreboard.PrintScoreboard();
                    break;
            }
        }

        private static void ProceedGameOver()
        {
            if (movesCount == 0)
            {
                Console.WriteLine(Messages.Lose);
            }
            else
            {
                Console.WriteLine(Messages.Win, movesCount);
                Console.Write(Messages.HighScore);

                var playerName = Console.ReadLine();
                IPlayer player = new Player(playerName, movesCount);
                Scoreboard.AddPlayer(player);
                Scoreboard.PrintScoreboard();
            }

            gameState = State.Restart;
            isGameFinished = false;
            movesCount = 0;
        }

        private static void ProceedMove(string input)
        {
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
                catch (Exception exception) // bad practice Need to be more explicit
                {
                    Console.WriteLine(exception.Message);
                }
            }
            else
            {
                try
                {
                    gameState = Command.CommandType(input);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        private static List<ITile> RestartGame(List<ITile> tiles)
        {
            Console.WriteLine(Messages.Welcome);
            tiles = MatrixGenerator.GenerateMatrix();
            tiles = MatrixGenerator.ShuffleMatrix(tiles);
            isGameFinished = Gameplay.IsMatrixSolved(tiles);
            Gameplay.PrintMatrix(tiles);
            gameState = State.InGame;
            return tiles;
        }

        public void Run()
        {
            Menu();
        }
    }
}