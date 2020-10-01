using System;
using System.Linq;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class FillTest
    {
        private Fill fill;

        [SetUp]
        public void Setup()
        {
            fill = new Fill();
        }

        [Test]
        public void SetColor_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                fill.Color = null;
            });
        }

        [Test]
        public void SetGradientColor_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                fill.GradientColor = null;
            });
        }

        [Test]
        public void SetImage_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                fill.Image = null;
            });
        }

        [Test]
        public void IsDefault_NewInstance_True()
        {
            Assert.IsTrue(fill.IsDefault());
        }

        [Test]
        public void IsDefault_ColorNotEmpty_False()
        {
            fill.Color = "red";

            Assert.IsFalse(fill.IsDefault());
        }

        [Test]
        public void IsDefault_GradientColorNotEmpty_False()
        {
            fill.GradientColor = "green";

            Assert.IsFalse(fill.IsDefault());
        }

        [Test]
        public void IsDefault_GradientRotationNotNone_False()
        {
            fill.GradientRotation = GradientRotation.Vertical;

            Assert.IsFalse(fill.IsDefault());
        }

        [Test]
        public void IsDefault_ImageNotEmpty_False()
        {
            fill.Image = "http://example.com/image.png";

            Assert.IsFalse(fill.IsDefault());
        }

        [Test]
        public void Collect_NewInstance_HasOneElement()
        {
            var children = fill.Collect();

            Assert.AreEqual(1, children.Count());
        }

        [Test]
        public void Collect_ColorNonEmpty_HasOneElement()
        {
            fill.Color = "red";

            var children = fill.Collect();

            Assert.AreEqual(1, children.Count());
        }
    }
}
