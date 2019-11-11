using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class FontTest
    {
        [Test, AutoData]
        public void CanCreateFont(string family, string style, string weight, string size,
            FontDecoration decoration, FontAlign align, double rotation)
        {
            Font font = new Font(family, style, weight, size, decoration, align, rotation);
            Assert.AreEqual(family, font.Family);
            Assert.AreEqual(style, font.Style);
            Assert.AreEqual(weight, font.Weight);
            Assert.AreEqual(size, font.Size);
            Assert.AreEqual(decoration, font.Decoration);
            Assert.AreEqual(align, font.Align);
            Assert.AreEqual(rotation, font.Rotation);
        }
    }
}
