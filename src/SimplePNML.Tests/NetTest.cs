
using AutoFixture.NUnit3;
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

        [Test, XmlAutoData]
        public void WithPagesAddsPages(Page page1, Page page2)
        {
            Net net = new Net();
            Assert.AreEqual(2, net.WithPages(page1, page2).Pages.Count);
        }
    }
}
