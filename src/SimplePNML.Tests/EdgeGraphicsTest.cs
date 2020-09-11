using NUnit.Framework;

using System.Linq;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class EdgeGraphicsTest
    {
        private EdgeGraphics graphics;

        [SetUp]
        public void Setup()
        {
            graphics = new EdgeGraphics();
        }

        [Test]
        public void IsDefault_NewInstance_True()
        {
            var isDefault = graphics.IsDefault();

            Assert.IsTrue(isDefault);
        }

        [Test]
        public void IsDefault_PositionsNonEmpty_False()
        {
            graphics.Positions.Add(new Position(4.2, 1.3));

            var isDefault = graphics.IsDefault();

            Assert.IsFalse(isDefault);
        }

        [Test]
        public void Collect_NewInstance_ContainsOneThanMoreElement()
        {
            var children = graphics.Collect();

            Assert.Greater(children.Count(), 1);
        }
    }
}
