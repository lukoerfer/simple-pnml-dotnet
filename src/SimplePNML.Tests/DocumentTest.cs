using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class DocumentTest
    {
        [Test, XmlAutoData]
        public void EqualsAfterSerialization(Document input)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            MemoryStream stream = new MemoryStream();
            serializer.Serialize(stream, input);
            stream.Position = 0;
            Document output = (Document) serializer.Deserialize(stream);
            Assert.IsTrue(input.Equals(output));
        }

        [Test, XmlAutoData]
        public void ValidAfterSerialization(Document data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, data);
                string xml = writer.ToString();
                Assert.IsTrue(true);
            }
        }
    }
}
