using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class LabelTest
    {
        [Test, AutoData]
        public void CanCreateLabel(string text, double x, double y)
        {
            Label label = new Label(text, x, y);
            Assert.AreEqual(text, label.Text);
            Assert.AreEqual(x, label.Graphics.Offset.X);
            Assert.AreEqual(y, label.Graphics.Offset.Y);
        }

    }
}
