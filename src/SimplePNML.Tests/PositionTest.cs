using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class PositionTest
    {
        private Position position;

        [SetUp]
        public void Setup()
        {
            position = new Position();
        }

        [Test]
        public void IsDefault_NewInstance_True()
        {
            Assert.True(position.IsDefault());
        }

        [Test]
        public void IsDefault_XNotZero_True()
        {
            position.X = 20.5;

            Assert.False(position.IsDefault());
        }

        [Test]
        public void IsDefault_YNotZero_True()
        {
            position.Y = 12.5;

            Assert.False(position.IsDefault());
        }

    }
}
