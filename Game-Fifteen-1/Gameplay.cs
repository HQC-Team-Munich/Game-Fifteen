namespace GameFifteen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;
    using Constants;

    public static class Gameplay
    {
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

        public static List<ITile> MoveTiles(List<ITile> tiles, int tileValue)
        {
            if (tileValue < 0 || tileValue > 15)
            {
                throw new ArgumentException("Invalid move!");
            }

            List<ITile> resultMatrix = tiles;
            ITile freeTile = tiles[GetFreeTilePosition(tiles)];
            ITile tile = tiles[GetDestinationTilePosition(tiles, tileValue)];

            bool areValidNeighbourTiles = AreValidNeighbourTiles(freeTile, tile);

            if (areValidNeighbourTiles)
            {
                int targetTilePosition = tile.Position;
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
            int count = 0;

            foreach (ITile tile in tiles)
            {
                int tileLabelInt = 0;
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

            for (int index = 0; index < tiles.Count; index++)
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

        private static bool AreValidNeighbourTiles(ITile freeTile, ITile tile)
        {
            int tilesDistance = freeTile.Position - tile.Position;
            int tilesAbsoluteDistance = Math.Abs(tilesDistance);
            // TODO: Fix
            bool isValidHorizontalNeighbour =
                (tilesAbsoluteDistance == Matrix.HorizontalNeighbourTile && 
                !(((tile.Position + 1) % Matrix.MatrixSize == 1 && tilesDistance == -1) 
                || ((tile.Position + 1) % Matrix.MatrixSize == 0 && tilesDistance == 1)));
            bool isValidVerticalNeighbour = (tilesAbsoluteDistance == Matrix.VerticalNeighbourTile);
            bool validNeigbour = isValidHorizontalNeighbour || isValidVerticalNeighbour;

            return validNeigbour;
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