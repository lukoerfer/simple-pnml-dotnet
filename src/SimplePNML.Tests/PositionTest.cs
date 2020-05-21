using AutoFixture.NUnit3;
using NUnit.Framework;
using System.Linq;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class PositionTest
    {
        [Test]
        public void CanCreate()
        {
            Position position = new Position();
            Assert.IsTrue(position.IsDefault());
            Assert.AreEqual(1, position.Collect().Count());
        }

        [Test]
        public void CanCreateWithValues()
        {
            double x = 4.3, y = 5.6;
            Position position = new Position(x, y);
            Assert.AreEqual(x, position.X);
            Assert.AreEqual(y, position.Y);
            Assert.IsFalse(position.IsDefault());
            Assert.AreEqual(1, position.Collect().Count());
        }

    }
}
