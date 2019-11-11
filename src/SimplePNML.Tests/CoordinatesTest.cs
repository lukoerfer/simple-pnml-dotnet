using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class CoordinatesTest
    {
        [Test, AutoData]
        public void CanCreateCoordinates(double x, double y)
        {
            Coordinates coordinates = new Coordinates(x, y);
            Assert.AreEqual(x, coordinates.X);
            Assert.AreEqual(y, coordinates.Y);
        }

    }
}
