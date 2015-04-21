﻿namespace GameFifteen
{
    using System;
    using System.Collections.Generic;

    using Enumerations;
    using Interfaces;
    using Constants;
    using Models;
    using Utils;

    public class Engine
    {
        private static Engine instance;

        private List<ITile> tiles;
        private int movesCount;
        private State gameState;
        private bool isGameFinished;

        public static Engine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Engine();
                }

                return instance;
            }
        }

        public void Run()
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

        private void ResolveGameState()
        {
            switch (gameState)
            {
                case State.Restart:
                    RestartGame();
                    break;

                case State.InGame:
                    isGameFinished = Gameplay.IsMatrixSolved(tiles);
                    break;

                case State.Top:
                    Scoreboard.PrintScoreboard();
                    break;
            }
        }

        private void ProceedGameOver()
        {
            if (movesCount == 0)
            {
                Console.WriteLine(Messages.Lose);
            }
            else
            {
                Console.WriteLine(Messages.Win, movesCount);
                Console.Write(Messages.HighScore);

                string playerName = Console.ReadLine();
                IPlayer player = new Player(playerName, movesCount);
                Scoreboard.AddPlayer(player);
                Scoreboard.PrintScoreboard();
            }

            gameState = State.Restart;
            isGameFinished = false;
            movesCount = 0;
        }

        private void ProceedMove(string input)
        {
            int destinationTileValue;
            bool isSuccessfulParsing = int.TryParse(input, out destinationTileValue);

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

        private void RestartGame()
        {
            Console.WriteLine(Messages.Welcome);
            tiles = MatrixGenerator.GenerateMatrix();
            tiles = MatrixGenerator.ShuffleMatrix(tiles);
            isGameFinished = Gameplay.IsMatrixSolved(tiles);
            Gameplay.PrintMatrix(tiles);
            gameState = State.InGame;
        }
    }
}