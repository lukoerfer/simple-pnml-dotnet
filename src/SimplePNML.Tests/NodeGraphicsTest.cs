using NUnit.Framework;

using System;
using System.Linq;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class NodeGraphicsTest
    {
        private NodeGraphics graphics;

        [SetUp]
        public void Setup()
        {
            graphics = new NodeGraphics();
        }

        [Test]
        public void SetPosition_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                graphics.Position = null;
            });
        }

        [Test]
        public void SetSize_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                graphics.Size = null;
            });
        }

        [Test]
        public void SetFill_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                graphics.Fill = null;
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
        public void Collect_NewInstance_ContainsMoreThenOneElement()
        {
            Assert.Greater(graphics.Collect().Count(), 1);
        }

        [Test]
        public void IsDefault_NewInstance_True()
        {
            Assert.True(graphics.IsDefault());
        }

        [Test]
        public void IsDefault_PositionNotDefault_False()
        {
            graphics.Position = new Position(10.5, 20.5);

            Assert.False(graphics.IsDefault());
        }

        [Test]
        public void IsDefault_SizeNotDefault_False()
        {
            graphics.Size.Height = 20.5;

            Assert.False(graphics.IsDefault());
        }

        [Test]
        public void IsDefault_FillNotDefault_False()
        {
            graphics.Fill.Color = "red";

            Assert.False(graphics.IsDefault());
        }

        [Test]
        public void IsDefault_LineNotDefault_False()
        {
            graphics.Line.Shape = LineShape.Curve;

            Assert.False(graphics.IsDefault());
        }
    }
}
