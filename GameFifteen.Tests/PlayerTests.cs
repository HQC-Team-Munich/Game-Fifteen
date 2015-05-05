namespace GameFifteen.Tests
{
    using Exceptions.PlayerExceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidPlayerMoveCountException))]
        public void NegativeMovesTest()
        {
            Player player = new Player("Gosho", -5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlayerNameException))]
        public void EmptyNameTest()
        {
            Player player = new Player("", 5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlayerNameException))]
        public void InvalidNameTest()
        {
            Player player = new Player("%@#%^", 5);
        }
    }
}
