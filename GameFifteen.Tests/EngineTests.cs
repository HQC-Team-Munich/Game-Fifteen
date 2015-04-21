namespace GameFifteen.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        public void EngineSingleInstanceTest()
        {
            Engine engine1 = Engine.Instance;
            Engine engine2 = Engine.Instance;
            Assert.AreEqual(engine1, engine2);
        }
    }
}
