namespace GameFifteen.Tests
{
    using Enumerations;
    using Exceptions.CommandExceptions;
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

        [TestMethod]
        [ExpectedException(typeof(CommandIsNullException))]
        public void InputIsNullTest()
        {
            Command.CommandType(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void InvalidCommandTest()
        {
            Command.CommandType("invalid command");
        }
    }
}
