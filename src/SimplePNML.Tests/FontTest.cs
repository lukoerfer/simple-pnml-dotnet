using NUnit.Framework;

using System;
using System.Linq;

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
        public void SetFamily_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                font.Family = null;
            });
        }

        [Test]
        public void SetStyle_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                font.Style = null;
            });
        }

        [Test]
        public void SetWeight_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                font.Weight = null;
            });
        }

        [Test]
        public void SetSize_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                font.Size = null;
            });
        }

        [Test]
        public void Collect_NewInstance_ContainsOneElement()
        {
            Assert.AreEqual(1, font.Collect().Count());
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
