namespace GameFifteen.Core.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Constants;
    using Interfaces;
    using Models;
    
    public static class MatrixGenerator
    {
        private const int MinimumCycles = 20;
        private const int MaximumCycles = 50;
        private static readonly Random Random = new Random();

        /// <summary>
        /// Generates a new game matrix to be used in-game.
        /// </summary>
        /// <returns>A List of ITiles which represents the generated matrix</returns>
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

        /// <summary>
        /// Randomizes the positions of the tiles in the input matrix.
        /// </summary>
        /// <param name="startingMatrix">The input matrix to be shuffled</param>
        /// <returns>The shuffled matrix</returns>
        public static List<ITile> ShuffleMatrix(List<ITile> startingMatrix)
        {
            List<ITile> currentMatrix = CloneMatrix(startingMatrix);

            int cycleCount = Random.Next(MinimumCycles, MaximumCycles);
           
            for (int index = 0; index < cycleCount; index++)
            {
                currentMatrix = MoveFreeTile(currentMatrix);
            }

            return currentMatrix;
        }

        /// <summary>
        /// Checks whether two given tiles are valid neighbours in the game.
        /// </summary>
        /// <param name="freeTile">The input tile which has no value as it is unoccupied</param>
        /// <param name="tile">The tile to check</param>
        /// <returns>A boolean statement determining whether the input tiles are valid neighbours</returns>
        public static bool AreValidNeighbourTiles(ITile freeTile, ITile tile)
        {
            int tilesAbsoluteDistance = Math.Abs(freeTile.Position - tile.Position);

            bool isValidHorizontalNeighbour = (tilesAbsoluteDistance == Matrix.HorizontalNeighbourTile);

            bool isValidVerticalNeighbour = (tilesAbsoluteDistance == Matrix.VerticalNeighbourTile);

            return isValidHorizontalNeighbour || isValidVerticalNeighbour;
        }

        private static List<ITile> MoveFreeTile(List<ITile> resultMatrix)
        {
            List<ITile> currentMatrix = CloneMatrix(resultMatrix);
            ITile freeTile = DetermineFreeTile(resultMatrix);
            
            int switchedIndexNumber = Random.Next() % resultMatrix.Count();
            ITile targetTile = resultMatrix[switchedIndexNumber];

            int targetTilePosition = targetTile.Position;

            currentMatrix[targetTile.Position].Position = freeTile.Position;
            currentMatrix[freeTile.Position].Position = targetTilePosition;

            currentMatrix.Sort();

            return currentMatrix;
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

        private static List<ITile> CloneMatrix(List<ITile> matrix)
        {
            List<ITile> clonedMatrix = new List<ITile>();
            for (int index = 0; index < matrix.Count; index++)
            {
                ITile tile = new Tile(matrix[index].Label, matrix[index].Position);
                clonedMatrix.Add(tile);
            }

            return clonedMatrix;
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