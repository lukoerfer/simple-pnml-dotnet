using NUnit.Framework;

using System;
using System.Linq;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class LabelTest
    {
        private Label label;

        [SetUp]
        public void Setup()
        {
            label = new Label();
        }

        [Test]
        public void SetText_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                label.Text = null;
            });
        }

        [Test]
        public void SetGraphics_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                label.Graphics = null;
            });
        }

        [Test]
        public void Collect_NewInstance_ContainsOneThanOneElement()
        {
            Assert.Greater(label.Collect().Count(), 1);
        }

        [Test]
        public void IsDefault_NewInstance_True()
        {
            Assert.IsTrue(label.IsDefault());
        }

        [Test]
        public void IsDefault_TextNotEmpty_False()
        {
            label.Text = "Lorem ipsum";

            Assert.IsFalse(label.IsDefault());
        }

        [Test]
        public void IsDefault_GraphicsNotDefault_False()
        {
            label.Graphics.Line.Color = "red";

            Assert.IsFalse(label.IsDefault());
        }
    }
}
