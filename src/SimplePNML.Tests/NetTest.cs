using System.IO;
using System.Xml.Serialization;

using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class NetTest
    {
        [Test, AutoData]
        public void EqualsAfterSerialization(Net input)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Net));
            MemoryStream stream = new MemoryStream();
            serializer.Serialize(stream, input);
            stream.Position = 0;
            Net output = (Net)serializer.Deserialize(stream);
            Assert.IsTrue(input.Equals(output));
        }
    }
}
