using System.IO;
using System.Xml.Serialization;

using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class GraphicsTest
    {
        [Test, AutoData]
        public void EqualsAfterSerialization(Graphics input)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Graphics));
            MemoryStream stream = new MemoryStream();
            serializer.Serialize(stream, input);
            stream.Position = 0;
            Graphics output = (Graphics)serializer.Deserialize(stream);
            Assert.IsTrue(input.Equals(output));
        }

        [Test, AutoData]
        public void ValidAbsolute(int x, int y)
        {
            Graphics absolute = Graphics.Absolute(x, y);
            Assert.IsNotNull(absolute.Position);
            Assert.IsNull(absolute.Offset);
        }

        [Test, AutoData]
        public void ValidRelative(int x, int y)
        {
            Graphics relative = Graphics.Relative(x, y);
            Assert.IsNull(relative.Position);
            Assert.IsNotNull(relative.Offset);
        }

    }
}
