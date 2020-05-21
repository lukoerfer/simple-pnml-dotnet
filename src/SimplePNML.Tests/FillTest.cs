using System.Linq;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class FillTest
    {
        [Test]
        void CanCreate()
        {
            Fill fill = new Fill();
            Assert.IsTrue(fill.IsDefault());
            Assert.AreEqual(1, fill.Collect().Count());
        }

        [Test]
        void CanCreateUsingInitializer()
        {
            string color = "red";
            Fill fill = new Fill()
            {
                Color = color
            };
            Assert.AreEqual(color, fill.Color);
            Assert.IsFalse(fill.IsDefault());
            Assert.AreEqual(1, fill.Collect().Count());
        }
    }
}
