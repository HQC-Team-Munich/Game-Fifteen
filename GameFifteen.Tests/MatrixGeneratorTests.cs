namespace GameFifteen.Tests
{
    using System.Collections.Generic;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Core;
    using Core.Utils;

    [TestClass]
    public class MatrixGeneratorTests
    {
        [TestMethod]
        public void GenerateMatrixTest()
        {
            IList<ITile> tiles = new List<ITile>();
            for (int index = 1; index < 16; index++)
            {
                tiles.Add(new Tile(index.ToString(), index - 1));
            }
            tiles.Add(new Tile(string.Empty, 15));

            IList<ITile> generatedTiles = MatrixGenerator.GenerateMatrix();
            for (int index = 0; index < generatedTiles.Count; index++)
            {
                Assert.AreEqual(generatedTiles[index].Position, tiles[index].Position);
                Assert.AreEqual(generatedTiles[index].Label, tiles[index].Label);
            }
        }

        [TestMethod]
        public void ValidNeighbourTilesTest()
        {
            IList<ITile> tiles = new List<ITile>();
            for (int index = 1; index < 16; index++)
            {
                tiles.Add(new Tile(index.ToString(), index - 1));
            }
            tiles.Add(new Tile(string.Empty, 15));

            Assert.IsTrue(MatrixGenerator.AreValidNeighbourTiles(tiles[0], tiles[1]));
            Assert.IsTrue(MatrixGenerator.AreValidNeighbourTiles(tiles[4], tiles[5]));
            Assert.IsTrue(MatrixGenerator.AreValidNeighbourTiles(tiles[9], tiles[8]));
        }

        [TestMethod]
        public void InvalidNeighbourTilesTest()
        {
            IList<ITile> tiles = new List<ITile>();
            for (int index = 1; index < 16; index++)
            {
                tiles.Add(new Tile(index.ToString(), index - 1));
            }
            tiles.Add(new Tile(string.Empty, 15));

            Assert.IsFalse(MatrixGenerator.AreValidNeighbourTiles(tiles[0], tiles[5]));
        }

        [TestMethod]
        public void ShuffleMatrixTest()
        {
            List<ITile> tiles = new List<ITile>();
            for (int index = 1; index < 16; index++)
            {
                tiles.Add(new Tile(index.ToString(), index - 1));
            }
            tiles.Add(new Tile(string.Empty, 15));

            int occurrencesCount = 0;
            IList<ITile> shuffledTiles = MatrixGenerator.ShuffleMatrix(tiles);
            for (int index = 0; index < tiles.Count; index++)
            {
                if (tiles[index].Label == shuffledTiles[index].Label)
                {
                    occurrencesCount++;
                }
            }

            Assert.AreNotEqual(occurrencesCount, tiles.Count);
        }
    }
}
