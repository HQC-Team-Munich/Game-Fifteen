namespace GameFifteen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Constants;
    using Core.Utils;
    using Exceptions.TileExceptions;
    using Interfaces;

    public static class Gameplay
    {
        /// <summary>
        /// Prints the given matrix in a friendly format on the console.
        /// </summary>
        /// <param name="sourceMatrix">The matrix to be printed</param>
        public static void PrintMatrix(List<ITile> sourceMatrix)
        {
            const string Line = "  -------------";
            const string LeftPipe = "| ";
            const string RightPipe = " |";
            const string Spacing = " ";
            const string Margin = "   ";

            Console.WriteLine(Line);
            Console.Write(LeftPipe);

            int rowCounter = 0;

            for (int index = 0; index < 16; index++)
            {
                ITile currentElement = sourceMatrix.ElementAt(index);
                
                if (currentElement.Label == string.Empty)
                {
                    Console.Write(Margin);
                }
                else if (int.Parse(currentElement.Label) < 10)
                {
                    Console.Write(Spacing + currentElement.Label + Spacing);
                }
                else
                {
                    Console.Write(currentElement.Label + Spacing);
                }

                rowCounter++;

                if (rowCounter == 4)
                {
                    Console.WriteLine(RightPipe);
                    if (index < 12)
                    {
                        Console.Write(LeftPipe);
                    }

                    rowCounter = 0;
                }
            }

            Console.WriteLine(Line);
        }

        /// <summary>
        /// This method is handling the movement of the tiles in-game.
        /// </summary>
        /// <exception cref="TilePositionOutOfRangeException">
        /// Thrown when the position of the tile is a negative number or exceeds the scope of the matrix
        /// </exception>
        /// <exception cref="InvalidTileNeighbourException">
        /// Thrown when two given tiles are not valid neighbours.
        /// </exception>
        public static List<ITile> MoveTiles(List<ITile> tiles, int tileValue)
        {
            if (tileValue < 0 || tileValue > 15)
            {
                throw new TilePositionOutOfRangeException(Messages.TileOutOfRangeExceptionMessage);
            }

            List<ITile> resultMatrix = tiles;
            ITile freeTile = tiles[GetFreeTilePosition(tiles)];
            ITile tile = tiles[GetDestinationTilePosition(tiles, tileValue)];

            bool areValidNeighbourTiles = MatrixGenerator.AreValidNeighbourTiles(freeTile, tile);

            if (!areValidNeighbourTiles)
            {
                throw new InvalidTileNeighbourException(Messages.InvalidTileNeighbourExceptionMessage);
            }

            int targetTilePosition = tile.Position;
            resultMatrix[targetTilePosition].Position = freeTile.Position;
            resultMatrix[freeTile.Position].Position = targetTilePosition;
            resultMatrix.Sort();

            return resultMatrix;
        }

        /// <summary>
        /// Checks whether the matrix is solved and every tile is in the right position.
        /// </summary>
        /// <param name="tiles">The tiles of the matrix</param>
        /// <returns></returns>
        public static bool IsMatrixSolved(List<ITile> tiles)
        {
            int count = 0;
            int tileLabelInt;

            foreach (ITile tile in tiles)
            {
                int.TryParse(tile.Label, out tileLabelInt);

                if (tileLabelInt == (tile.Position + 1))
                {
                    count++;
                }
            }

            return count == 15;
        }

        private static int GetDestinationTilePosition(List<ITile> tiles, int tileValue)
        {
            int result = 0;
            int parsedLabel;
            bool successfulParsing;

            for (int index = 0; index < tiles.Count; index++)
            {
                successfulParsing = int.TryParse(tiles[index].Label, out parsedLabel);

                if (successfulParsing && tileValue == parsedLabel)
                {
                    result = index;
                }
            }

            return result;
        }

        private static int GetFreeTilePosition(List<ITile> tiles)
        {
            int result = 0;

            for (int index = 0; index < tiles.Count; index++)
            {
                if (tiles[index].Label == string.Empty)
                {
                    result = index;
                }
            }

            return result;
        }
    }
}