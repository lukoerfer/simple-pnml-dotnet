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
        public void IsDefault_NewInstance_True()
        {
            Assert.IsTrue(fill.IsDefault());
        }

        [Test]
        public void IsDefault_ColorNonEmpty_False()
        {
            fill.Color = "red";

            Assert.IsFalse(fill.IsDefault());
        }

        [Test]
        public void Collect_NewInstance_HasOneElement()
        {
            var children = fill.Collect();

            Assert.AreEqual(1, children.Count());
        }

        public void Collect_ColorNonEmpty_HasOneElement()
        {
            fill.Color = "red";

            var children = fill.Collect();

            Assert.AreEqual(1, children.Count());
        }
    }
}
