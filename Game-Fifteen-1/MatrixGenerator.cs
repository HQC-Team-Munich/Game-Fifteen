namespace GameFifteen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;

    public static class MatrixGenerator
    {
        private const int HORIZONTAL_NEIGHBOUR_TILE = 1;
        private const int VERTICAL_NEIGHBOUR_TILE = 4;
        private const int MATRIX_SIZE = 4;
        private const int MINIMUM_CYCLES = 20;
        private const int MAXIMUM_CYCLES = 50;
        private static Random random;

        public static List<ITile> GenerateMatrix()
        {
            var tiles = new List<ITile>();

            for (var index = 0; index < 15; index++)
            {
                var tileName = (index + 1).ToString();

                var tempTile = new Tile(tileName, index);
                tiles.Add(tempTile);
            }

            var emptyTile = new Tile(string.Empty, 15);
            tiles.Add(emptyTile);

            return tiles;
        }

        public static List<ITile> ShuffleMatrix(List<ITile> startingMatrix)
        {
            random = new Random();
            var cycleCount = random.Next(MINIMUM_CYCLES, MAXIMUM_CYCLES);
            var resultMatrix = new List<ITile>();
            resultMatrix = startingMatrix;

            for (var index = 0; index < cycleCount; index++)
            {
                resultMatrix = MoveFreeTile(resultMatrix);
            }

            return resultMatrix;
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
            var isValidHorizontalNeighbour =
                ((tilesAbsoluteDistance == HORIZONTAL_NEIGHBOUR_TILE) && !(((tile.Position + 1) % MATRIX_SIZE == 1 && tilesDistance == -1) || ((tile.Position + 1) % MATRIX_SIZE == 0 && tilesDistance == 1)));
            var isValidVerticalNeighbour = (tilesAbsoluteDistance == VERTICAL_NEIGHBOUR_TILE);
            var validNeigbour = isValidHorizontalNeighbour || isValidVerticalNeighbour;

            return validNeigbour;
        }
    }
}