using System.IO;
using System.Xml.Serialization;

using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class CoordinatesTest
    {
        [Test, AutoData]
        public void EqualsAfterSerialization(Coordinates input)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Coordinates));
            MemoryStream stream = new MemoryStream();
            serializer.Serialize(stream, input);
            stream.Position = 0;
            Coordinates output = (Coordinates) serializer.Deserialize(stream);
            Assert.IsTrue(input.Equals(output));
        }

    }
}
