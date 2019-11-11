using System.Drawing;
using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class LineTest
    {
        [Test, AutoData]
        public void CanCreateLine(Color color, double width, LineShape shape, LineStyle style)
        {
            Line line = new Line(color, width, shape, style);
            Assert.AreEqual(color, line.Color);
            Assert.AreEqual(width, line.Width);
            Assert.AreEqual(shape, line.Shape);
            Assert.AreEqual(style, line.Style);
        }
    }
}

