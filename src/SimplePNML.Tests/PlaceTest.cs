using System.IO;
using System.Xml.Serialization;

using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    public class PlaceTest
    {
        [Test, AutoData]
        public void EqualsAfterSerialization(Place input)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Place));
            MemoryStream stream = new MemoryStream();
            serializer.Serialize(stream, input);
            stream.Position = 0;
            Place output = (Place) serializer.Deserialize(stream);
            Assert.IsTrue(input.Equals(output));
        }
    }
}
