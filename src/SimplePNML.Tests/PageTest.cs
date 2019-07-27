using System.IO;
using System.Xml.Serialization;

using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class PageTest
    {
        [Test, AutoData]
        public void EqualsAfterSerialization(Page input)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Page));
            MemoryStream stream = new MemoryStream();
            serializer.Serialize(stream, input);
            stream.Position = 0;
            Page output = (Page) serializer.Deserialize(stream);
            Assert.IsTrue(input.Equals(output));
        }
    }
}
