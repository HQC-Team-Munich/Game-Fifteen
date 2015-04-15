namespace GameFifteen.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;
    using Models;
    using Constants;

    public static class MatrixGenerator
    {
        private const int MinimumCycles = 20;
        private const int MaximumCycles = 50;
        private static readonly Random Random = new Random();

        public static List<ITile> GenerateMatrix()
        {
            List<ITile> tiles = new List<ITile>();
            Tile tempTile = null;
            string currentTileName = string.Empty;

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
            int cycleCount = Random.Next(MinimumCycles, MaximumCycles);
           
            for (int index = 0; index < cycleCount; index++)
            {
                startingMatrix = MoveFreeTile(startingMatrix);
            }

            return startingMatrix;
        }

        public static bool AreValidNeighbourTiles(ITile freeTile, ITile tile)
        {
            int tilesAbsoluteDistance = Math.Abs(freeTile.Position - tile.Position);

            bool isValidHorizontalNeighbour = (tilesAbsoluteDistance == Matrix.HorizontalNeighbourTile);

            bool isValidVerticalNeighbour = (tilesAbsoluteDistance == Matrix.VerticalNeighbourTile);

            return isValidHorizontalNeighbour || isValidVerticalNeighbour;
        }

        private static List<ITile> MoveFreeTile(List<ITile> resultMatrix)
        {
            ITile freeTile = DetermineFreeTile(resultMatrix);
            
            int switchedIndexNumber = Random.Next() % resultMatrix.Count();
            ITile targetTile = resultMatrix[switchedIndexNumber];

            int targetTilePosition = targetTile.Position;
            resultMatrix[targetTile.Position].Position = freeTile.Position;
            resultMatrix[freeTile.Position].Position = targetTilePosition;

            resultMatrix.Sort();

            return resultMatrix;
        }

        private static ITile DetermineFreeTile(IEnumerable<ITile> resultMatrix)
        {
            ITile freeTile = new Tile();

            foreach (ITile tile in resultMatrix)
            {
                if (tile.Label == string.Empty)
                {
                    freeTile = tile;
                }
            }

            return freeTile;
        }

        //This method is not used anywhere! Find usages if you can.
        #region Find usage if you can.
        //private static List<ITile> GenerateNeighbourTilesList(ITile freeTile, ITile tile, List<ITile> neighbourTiles)
        //{
        //    bool areValidNeighbourTiles = AreValidNeighbourTiles(freeTile, tile);

        //    if (areValidNeighbourTiles)
        //    {
        //        neighbourTiles.Add(tile);
        //    }

        //    return neighbourTiles;
        //}
        #endregion
    }
}