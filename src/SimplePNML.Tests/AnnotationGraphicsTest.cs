using NUnit.Framework;

using System;
using System.Linq;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class AnnotationGraphicsTest
    {
        private AnnotationGraphics graphics;

        [SetUp]
        public void Setup()
        {
            graphics = new AnnotationGraphics();
        }

        [Test]
        public void SetOffset_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                graphics.Offset = null;
            });
        }

        [Test]
        public void SetFill_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                graphics.Fill = null;
            });
        }

        [Test]
        public void SetLine_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                graphics.Line = null;
            });
        }

        [Test]
        public void SetFont_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                graphics.Font = null;
            });
        }

        [Test]
        public void IsDefault_NewInstance_True()
        {
            Assert.IsTrue(graphics.IsDefault());
        }

        [Test]
        public void IsDefault_OffsetNotDefault_False()
        {
            graphics.Offset = new Offset(2.2, 5.6);

            Assert.IsFalse(graphics.IsDefault());
        }

        [Test]
        public void Collect_NewInstance_ContainsMoreThanOneElement()
        {
            Assert.Greater(graphics.Collect().Count(), 1);
        }
    }
}
