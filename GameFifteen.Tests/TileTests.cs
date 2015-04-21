namespace GameFifteen.Tests
{
    using Exceptions.TileExceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class TileTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidTileLabelException))]
        public void InvalidLabelTest()
        {
            Tile tile = new Tile("%", 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTilePositionException))]
        public void InvalidPositionTest()
        {
            Tile tile = new Tile("2", -5);
        }

        [TestMethod]
        public void TileComparisonTest()
        {
            Tile tile1 = new Tile("2", 5);
            Tile tile2 = new Tile("5", 5);
            Assert.IsTrue(tile1.CompareTo(tile2) == 0);

            tile1.Position = 7;
            Assert.IsTrue(tile1.CompareTo(tile2) > 0);

            tile2.Position = 9;
            Assert.IsTrue(tile1.CompareTo(tile2) < 0);
        }
    }
}
