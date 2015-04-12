﻿namespace GameFifteen
{
    using System;
    using System.Collections.Generic;
    using Enumerations;
    using Interfaces;
    using Models;


    public class Engine
    {
        private static List<ITile> tiles;
        private static int movesCount;
        private static State gameState;
        private static bool isGameFinished;

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

                    Console.Write(Messages.MOVEINPUT);
                    string input = Console.ReadLine();

                    ProceedMove(input);
                }
                else
                {
                    ProceedGameOver();
                }
            }
        }

        private static void ProceedGameOver()
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
            Console.WriteLine(Messages.WELCOME);
            tiles = MatrixGenerator.GenerateMatrix();
            tiles = MatrixGenerator.ShuffleMatrix(tiles);
            isGameFinished = Gameplay.IsMatrixSolved(tiles);
            Gameplay.PrintMatrix(tiles);
            gameState = State.InGame;
            return tiles;
        }

        static void Main()
        {
            Menu();
        }
    }
}