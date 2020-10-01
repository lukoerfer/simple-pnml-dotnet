using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class OffsetTest
    {
        private Offset offset;

        [SetUp]
        public void Setup()
        {
            offset = new Offset();
        }

        [Test]
        public void IsDefault_NewInstance_True()
        {
            Assert.True(offset.IsDefault());
        }

        [Test]
        public void IsDefault_XNotZero_True()
        {
            offset.X = 20.5;

            Assert.False(offset.IsDefault());
        }

        [Test]
        public void IsDefault_YNotZero_True()
        {
            offset.Y = 12.5;

            Assert.False(offset.IsDefault());
        }

    }
}
