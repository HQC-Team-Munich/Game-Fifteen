namespace GameFifteen.Tests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Exceptions.TileExceptions;
    using Interfaces;
    using Models;

    [TestClass]
    public class GameplayTests
    {
        [TestMethod]
        public void MatrixSolvedTest()
        {
            List<ITile> tiles = new List<ITile>();
            for (int index = 1; index < 16; index++)
            {
                tiles.Add(new Tile(index.ToString(), index - 1));
            }

            Assert.AreEqual(Gameplay.IsMatrixSolved(tiles), true);
        }

        [TestMethod]
        public void MoveTilesTest()
        {
            List<ITile> tiles = new List<ITile>();
            for (int index = 1; index < 16; index++)
            {
                tiles.Add(new Tile(index.ToString(), index - 1));
            }
            tiles.Add(new Tile("", 15));

            List<ITile> tilesAfterMoving = new List<ITile>();
            for (int index = 1; index < 16; index++)
            {
                if (index == 15)
                {
                    tilesAfterMoving.Add(new Tile("", index - 1));
                    tilesAfterMoving.Add(new Tile(index.ToString(), index));
                }
                else
                {
                    tilesAfterMoving.Add(new Tile(index.ToString(), index - 1));   
                }
            }

            tiles = Gameplay.MoveTiles(tiles, 15);
            for (int index = 0; index < tiles.Count; index++)
            {
                Assert.AreEqual(tiles[index].Label, tilesAfterMoving[index].Label);
                Assert.AreEqual(tiles[index].Position, tilesAfterMoving[index].Position);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(TilePositionOutOfRangeException))]
        public void MoveTileTest_NegativeTilePositionTest()
        {
            List<ITile> tiles = new List<ITile>();
            Gameplay.MoveTiles(tiles, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(TilePositionOutOfRangeException))]
        public void MoveTileTest_OutOfUpperLimitTilePostionTest()
        {
            List<ITile> tiles = new List<ITile>();
            Gameplay.MoveTiles(tiles, 16);
        }
    }
}
