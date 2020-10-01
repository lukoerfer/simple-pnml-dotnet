using NUnit.Framework;

using System;
using System.Linq;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class LineTest
    {
        private Line line;

        [SetUp]
        public void Setup()
        {
            line = new Line();
        }
        
        [Test]
        public void SetColor_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                line.Color = null;
            });
        }

        [Test]
        public void IsDefault_NewInstance_True()
        {
            Assert.IsTrue(line.IsDefault());
        }

        [Test]
        public void IsDefault_ColorNotEmpty_False()
        {
            line.Color = "green";

            Assert.IsFalse(line.IsDefault());
        }

        [Test]
        public void IsDefault_WidthNotZero_False()
        {
            line.Width = 2.5;

            Assert.IsFalse(line.IsDefault());
        }

        [Test]
        public void IsDefault_ShapeNotLine_False()
        {
            line.Shape = LineShape.Curve;

            Assert.IsFalse(line.IsDefault());
        }

        [Test]
        public void IsDefault_StyleNotSolid_False()
        {
            line.Style = LineStyle.Dot;

            Assert.IsFalse(line.IsDefault());
        }

        [Test]
        public void Collect_NewInstance_ContainsOneElement()
        {
            var children = line.Collect();

            Assert.AreEqual(1, children.Count());
        }
    }
}

