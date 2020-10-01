using NUnit.Framework;

using System;
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
        public void SetPositions_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                graphics.Positions = null;
            });
        }

        [Test]
        public void SetLine_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                graphics.Line = null;
            });
        }

        [Test]
        public void IsDefault_NewInstance_True()
        {
            Assert.IsTrue(graphics.IsDefault());
        }

        [Test]
        public void IsDefault_PositionsNonEmpty_False()
        {
            graphics.Positions.Add(new Position(4.2, 1.3));

            Assert.IsFalse(graphics.IsDefault());
        }

        [Test]
        public void IsDefault_LineNotDefault_False()
        {
            graphics.Line.Color = "red";

            Assert.IsFalse(graphics.IsDefault());
        }

        [Test]
        public void Collect_NewInstance_ContainsMoreThanOneElement()
        {
            var children = graphics.Collect();

            Assert.Greater(children.Count(), 1);
        }
    }
}
