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
            Dimension dimension = new Dimension(x, y);
            Assert.AreEqual(x, dimension.X);
            Assert.AreEqual(y, dimension.Y);
        }
    }
}

