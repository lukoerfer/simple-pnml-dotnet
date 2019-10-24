
using AutoFixture.NUnit3;
using Moq;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class NetTest
    {
        [TestCase(null, null), TestCase("", ""), TestCase("   ", "    "), TestCase("test", "test")]
        public void CreateGivesValidIdAndType(string id, string type)
        {
            Net net = Net.Create(id, type);
            Assert.NotNull(net.Id);
            Assert.IsNotEmpty(net.Id);
            Assert.IsFalse(string.IsNullOrWhiteSpace(net.Id));
            Assert.NotNull(net.Type);
            Assert.IsNotEmpty(net.Type);
            Assert.IsFalse(string.IsNullOrWhiteSpace(net.Type));
        }

        [Test]
        public void WithPagesAddsPages()
        {
            Net net = new Net();
            net.WithPages(new Page());
            Assert.AreEqual(1, net.Pages.Count);
        }
    }
}
