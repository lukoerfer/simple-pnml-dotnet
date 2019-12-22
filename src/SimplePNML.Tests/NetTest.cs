using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class NetTest
    {
        [TestCase(null, null), TestCase("", ""), TestCase(" ", " "), TestCase("test", "test")]
        public void DefaultsToValidIdAndDefaultType(string id, string type)
        {
            Net net = new Net(id, type);
            Assert.NotNull(net.Id);
            Assert.IsNotEmpty(net.Id);
            Assert.IsFalse(string.IsNullOrWhiteSpace(net.Id));
            Assert.NotNull(net.Type);
            Assert.IsNotEmpty(net.Type);
            Assert.IsFalse(string.IsNullOrWhiteSpace(net.Type));
        }

        
    }
}
