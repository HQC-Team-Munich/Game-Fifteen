namespace GameFifteen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;

    public static class Gameplay
    {
        private const int HORIZONTAL_NEIGHBOUR_TILE = 1;
        private const int VERTICAL_NEIGHBOUR_TILE = 4;
        private const int MATRIX_SIZE = 4;

        public static void PrintMatrix(List<ITile> sourceMatrix)
        {
            Console.WriteLine("  ------------");
            Console.Write("| ");
            var rowCounter = 0;
            for (var index = 0; index < 16; index++)
            {
                var currentElement = sourceMatrix.ElementAt(index);
                
                if (currentElement.Label == string.Empty)
                {
                    Console.Write("   ");
                }
                else if (int.Parse(currentElement.Label) < 10)
                {
                    Console.Write(' ' + currentElement.Label + ' ');
                }
                else
                {
                    Console.Write(currentElement.Label + ' ');
                }

                rowCounter++;
                if (rowCounter != 4)
                {
                    continue;
                }

                Console.Write(" |");
                Console.WriteLine();
                if (index < 12)
                {
                    Console.Write("| ");
                }

                rowCounter = 0;
            }

            Console.WriteLine("  ------------");
        }

        public static List<ITile> MoveTiles(List<ITile> tiles, int tileValue)
        {
            if (tileValue < 0 || tileValue > 15)
            {
                throw new ArgumentException("Invalid move!");
            }

            var resultMatrix = tiles;
            var freeTile = tiles[GetFreeTilePosition(tiles)];
            var tile = tiles[GetDestinationTilePosition(tiles, tileValue)];

            var areValidNeighbourTiles = TilePositionValidation(tiles, freeTile, tile);

            if (areValidNeighbourTiles)
            {
                var targetTilePosition = tile.Position;
                resultMatrix[targetTilePosition].Position = freeTile.Position;
                resultMatrix[freeTile.Position].Position = targetTilePosition;
                resultMatrix.Sort();
            }
            else
            {
                throw new Exception("Invalid move!");
            }

            return resultMatrix;
        }

        public static bool IsMatrixSolved(List<ITile> tiles)
        {
            var count = 0;
            foreach (var tile in tiles)
            {
                var tileLabelInt = 0;
                int.TryParse(tile.Label,out tileLabelInt);
                if (tileLabelInt == (tile.Position + 1))
                {
                    count++;
                }
            }

            return count == 15;
        }

        private static int GetDestinationTilePosition(List<ITile> tiles, int tileValue)
        {
            var result = 0;
            for (var index = 0; index < tiles.Count; index++)
            {
                var parsedLabel = 0;
                var successfulParsing = int.TryParse(tiles[index].Label, out parsedLabel);
                if (successfulParsing && tileValue == parsedLabel)
                {
                    result = index;
                }
            }

            return result;
        }

        private static bool TilePositionValidation(List<ITile> tiles, ITile freeTile, ITile tile)
        {
            var areValidNeighbourTiles = AreValidNeighbourTiles(freeTile, tile);

            return areValidNeighbourTiles;
        }

        private static bool AreValidNeighbourTiles(ITile freeTile, ITile tile)
        {
            var tilesDistance = freeTile.Position - tile.Position;
            var tilesAbsoluteDistance = Math.Abs(tilesDistance);
            // TODO: Fix
            var isValidHorizontalNeighbour =
                (tilesAbsoluteDistance == HORIZONTAL_NEIGHBOUR_TILE && !(((tile.Position + 1) % MATRIX_SIZE == 1 && tilesDistance == -1) || ((tile.Position + 1) % MATRIX_SIZE == 0 && tilesDistance == 1)));
            var isValidVerticalNeighbour = (tilesAbsoluteDistance == VERTICAL_NEIGHBOUR_TILE);
            var validNeigbour = isValidHorizontalNeighbour || isValidVerticalNeighbour;

            return validNeigbour;
        }

        private static int GetFreeTilePosition(List<ITile> tiles)
        {
            var result = 0;
            for (var index = 0; index < tiles.Count; index++)
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