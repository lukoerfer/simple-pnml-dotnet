using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class DimensionTest
    {
        [Test, AutoData]
        public void CanCreateDimension(double x, double y)
        {
            Size dimension = new Size(x, y);
            Assert.AreEqual(x, dimension.Width);
            Assert.AreEqual(y, dimension.Height);
        }
    }
}

