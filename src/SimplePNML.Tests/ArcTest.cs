using NUnit.Framework;

using System.Linq;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class ArcTest
    {
        private Arc arc;

        [SetUp]
        public void Setup()
        {
            arc = new Arc();
        }

        [Test]
        public void Id_NewInstance_NotNullOrEmpty()
        {
            var id = arc.Id;

            Assert.IsNotNull(id);
            Assert.IsNotEmpty(id);
        }

        [Test]
        public void Collect_NewInstance_ContainsMoreThanOneElement()
        {
            var children = arc.Collect();

            Assert.Greater(children.Count(), 1);
        }
    }
}
