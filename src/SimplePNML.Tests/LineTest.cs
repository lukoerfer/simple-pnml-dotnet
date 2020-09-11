using NUnit.Framework;

using System.Linq;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class LineTest
    {
        private Line line;

        [SetUp]
        public void Setup()
        {
            line = new Line();
        }
        
        [Test]
        public void IsDefault_NewInstance_True()
        {
            var isDefault = line.IsDefault();

            Assert.IsTrue(isDefault);
        }

        [Test]
        public void IsDefault_ColorNotEmpty_False()
        {
            line.Color = "green";

            var isDefault = line.IsDefault();

            Assert.IsFalse(isDefault);
        }

        [Test]
        public void Collect_NewInstance_ContainsOneElement()
        {
            var children = line.Collect();

            Assert.AreEqual(1, children.Count());
        }

        [Test]
        public void Collect_ColorNotEmpty_ContainsOneElement()
        {
            line.Color = "green";

            var children = line.Collect();

            Assert.AreEqual(1, children.Count());
        }
    }
}

