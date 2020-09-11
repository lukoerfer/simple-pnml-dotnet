using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class FontTest
    {
        private Font font;

        [SetUp]
        public void Setup()
        {
            font = new Font();
        }

        [Test]
        public void IsDefault_NewInstance_True()
        {
            var isDefault = font.IsDefault();

            Assert.IsTrue(isDefault);
        }

        [Test]
        public void IsDefault_RotationNotZero_False()
        {
            font.Rotation = 180.0;

            var isDefault = font.IsDefault();

            Assert.IsFalse(isDefault);
        }


    }
}
