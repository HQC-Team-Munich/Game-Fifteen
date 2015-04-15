namespace GameFifteen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;

    public static class MatrixGenerator
    {
        private const int HorizontalNeighbourTile = 1;
        private const int VerticalNeighbourTile = 4;
        private const int MatrixSize = 4;
        private const int MinimumCycles = 20;
        private const int MaximumCycles = 50;
        private static Random random;

        public static List<ITile> GenerateMatrix()
        {
            List<ITile> tiles = new List<ITile>();
            Tile tempTile = null;
            string currentTileName = String.Empty;

            for (int index = 0; index < 15; index++)
            {
                currentTileName = (index + 1).ToString();
                tempTile = new Tile(currentTileName, index);

                tiles.Add(tempTile);
            }
            
            tempTile = new Tile(string.Empty, 15);

            tiles.Add(tempTile);

            return tiles;
        }

        public static List<ITile> ShuffleMatrix(List<ITile> startingMatrix)
        {
            random = new Random();
            int cycleCount = random.Next(MinimumCycles, MaximumCycles);
            //var resultMatrix = startingMatrix;
           
            for (int index = 0; index < cycleCount; index++)
            {
                startingMatrix = MoveFreeTile(startingMatrix);
            }

            return startingMatrix;
        }

        private static List<ITile> MoveFreeTile(List<ITile> resultMatrix)
        {
            var freeTile = DetermineFreeTile(resultMatrix);

            List<ITile> neighbourTiles = new List<ITile>();

            neighbourTiles = resultMatrix.Aggregate(
                neighbourTiles,
                (current, tile) => GenerateNeighbourTilesList(freeTile, tile, current));

            var switchedindexNumber = random.Next() % (neighbourTiles.Count());
            var targetTile = neighbourTiles[switchedindexNumber];

            var targetTilePosition = targetTile.Position;
            resultMatrix[targetTile.Position].Position = freeTile.Position;
            resultMatrix[freeTile.Position].Position = targetTilePosition;

            resultMatrix.Sort();

            return resultMatrix;
        }

        private static ITile DetermineFreeTile(IEnumerable<ITile> resultMatrix)
        {
            ITile freeTile = new Tile();

            foreach (var tile in resultMatrix.Where(tile => tile.Label == string.Empty))
            {
                freeTile = tile;
            }

            return freeTile;
        }

        private static List<ITile> GenerateNeighbourTilesList(
            ITile freeTile,
            ITile tile,
            List<ITile> neighbourTiles)
        {
            var areValidNeighbourTiles = AreValidNeighbourTiles(freeTile, tile);
            if (areValidNeighbourTiles)
            {
                neighbourTiles.Add(tile);
            }

            return neighbourTiles;
        }

        private static bool AreValidNeighbourTiles(ITile freeTile, ITile tile)
        {
            var tilesDistance = freeTile.Position - tile.Position;
            var tilesAbsoluteDistance = Math.Abs(tilesDistance);
            // TODO: Fix
            var isValidHorizontalNeighbour =
                ((tilesAbsoluteDistance == HorizontalNeighbourTile) && !(((tile.Position + 1) % MatrixSize == 1 && tilesDistance == -1) || ((tile.Position + 1) % MatrixSize == 0 && tilesDistance == 1)));
            var isValidVerticalNeighbour = (tilesAbsoluteDistance == VerticalNeighbourTile);
            var validNeigbour = isValidHorizontalNeighbour || isValidVerticalNeighbour;

            return validNeigbour;
        }
    }
}