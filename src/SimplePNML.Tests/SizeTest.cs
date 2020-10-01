using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class SizeTest
    {
        private Size size;

        [SetUp]
        public void Setup()
        {
            size = new Size();
        }

        [Test]
        public void IsDefault_NewInstance_True()
        {
            Assert.True(size.IsDefault());
        }

        [Test]
        public void IsDefault_WidthNotZero_True()
        {
            size.Width = 20.5;

            Assert.False(size.IsDefault());
        }

        [Test]
        public void IsDefault_HeightNotZero_True()
        {
            size.Height = 12.5;

            Assert.False(size.IsDefault());
        }
    }
}

