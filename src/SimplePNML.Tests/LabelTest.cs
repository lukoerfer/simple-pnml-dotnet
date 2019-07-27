using System.IO;
using System.Xml.Serialization;

using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class LabelTest
    {
        [Test, AutoData]
        public void EqualsAfterSerialization(Label input)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Label));
            MemoryStream stream = new MemoryStream();
            serializer.Serialize(stream, input);
            stream.Position = 0;
            Label output = (Label) serializer.Deserialize(stream);
            Assert.IsTrue(input.Equals(output));
        }
    }
}
