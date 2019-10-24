using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using AutoFixture;
using AutoFixture.Kernel;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class DocumentTest
    {
        private Fixture Fixture;

        private XmlSerializer Serializer;

        [SetUp]
        public void SetupFixture()
        {
            Fixture = new Fixture();
            Fixture.Customizations.Add(new OmitXmlPropertiesSpecimenBuilder());
            Serializer = new XmlSerializer(typeof(Document));
        }

        private class OmitXmlPropertiesSpecimenBuilder : ISpecimenBuilder
        {
            public object Create(object request, ISpecimenContext context)
            {
                PropertyInfo property = request as PropertyInfo;
                bool isXmlProperty = property != null && property.Name.StartsWith("Xml");
                return isXmlProperty ? (object) new OmitSpecimen() : new NoSpecimen();
            }
        }

        [Test]
        public void ModelEqualsAfterSerialization()
        {
            Document input = Fixture.Create<Document>();
            using (MemoryStream stream = new MemoryStream())
            {
                Serializer.Serialize(stream, input);
                stream.Position = 0;
                Document output = (Document) Serializer.Deserialize(stream);
                Assert.IsTrue(input.Equals(output));
            }
        }

        [Test]
        public void CanImportExampleDocument()
        {
            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Example.pnml");
            using (TextReader reader = new StreamReader(path))
            {
                Document document = (Document) Serializer.Deserialize(reader);
                Assert.AreEqual(1, document.Nets.Count);
            }
        }

    }
}
