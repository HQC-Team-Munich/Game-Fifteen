namespace GameFifteen.Core
{
    using System;
    using System.Collections.Generic;

    using Enumerations;
    using Interfaces;
    using Constants;

    using GameFifteen.Core.Utils;
    using Models;

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
            this.tiles = new List<ITile>();
            this.movesCount = 0;
            this.gameState = State.Restart;
            this.isGameFinished = false;

            while (this.gameState != State.Exit)
            {
                if (!this.isGameFinished)
                {
                    this.ResolveGameState();
                }
                else
                {
                    this.ProceedGameOver();
                }
            }
        }

        private void ResolveGameState()
        {
            switch (this.gameState)
            {
                case State.Restart:
                    this.RestartGame();
                    break;

                case State.InGame:
                    this.isGameFinished = Gameplay.IsMatrixSolved(this.tiles);

                    Console.Write(Messages.MoveInput);
                    string input = Console.ReadLine();

                    this.ProceedMove(input);
                    break;

                case State.Top:
                    Scoreboard.PrintScoreboard();
                    this.gameState = State.InGame;
                    break;
            }
        }

        private void ProceedGameOver()
        {
            if (this.movesCount == 0)
            {
                Console.WriteLine(Messages.Lose);
            }
            else
            {
                Console.WriteLine(Messages.Win, this.movesCount);
                Console.Write(Messages.HighScore);

                string playerName = Console.ReadLine();
                IPlayer player = new Player(playerName, this.movesCount);
                Scoreboard.AddPlayer(player);
                Scoreboard.Save();
                Scoreboard.PrintScoreboard();
            }

            this.gameState = State.Restart;
            this.isGameFinished = false;
            this.movesCount = 0;
        }

        private void ProceedMove(string input)
        {
            int destinationTileValue;
            bool isSuccessfulParsing = int.TryParse(input, out destinationTileValue);

            if (isSuccessfulParsing)
            {
                try
                {
                    Gameplay.MoveTiles(this.tiles, destinationTileValue);
                    this.movesCount++;
                    Gameplay.PrintMatrix(this.tiles);
                    this.isGameFinished = Gameplay.IsMatrixSolved(this.tiles);
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
                    this.gameState = Command.CommandType(input);
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
            this.tiles = MatrixGenerator.GenerateMatrix();
            this.tiles = MatrixGenerator.ShuffleMatrix(this.tiles);
            this.isGameFinished = Gameplay.IsMatrixSolved(this.tiles);
            Gameplay.PrintMatrix(this.tiles);
            this.gameState = State.InGame;
        }
    }
}