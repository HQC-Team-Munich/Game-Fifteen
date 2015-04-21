namespace GameFifteen.Tests
{
    using Enumerations;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void CommandRestartTest()
        {
            Assert.AreEqual(State.Restart, Command.CommandType("restart"));
        }

        [TestMethod]
        public void CommandExitTest()
        {
            Assert.AreEqual(State.Exit, Command.CommandType("exit"));
        }

        [TestMethod]
        public void CommandTopTest()
        {
            Assert.AreEqual(State.Top, Command.CommandType("top"));
        }
    }
}
