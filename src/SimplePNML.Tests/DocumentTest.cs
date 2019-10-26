using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using AutoFixture;
using AutoFixture.Kernel;
using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class DocumentTest
    {
        [Test, DocumentAutoData]
        public void GeneratedDocumentEqualsAfterSerialization(Document document)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, document);
                stream.Position = 0;
                Document result = (Document) serializer.Deserialize(stream);
                Assert.AreEqual(document, result);
            }
        }

        [Test]
        public void CanImportExampleDocument()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            using (TextReader reader = Resource("Example.pnml"))
            {
                Document document = (Document) serializer.Deserialize(reader);
                Assert.AreEqual(1, document.Nets.Count);
            }
        }

        private static StreamReader Resource(string file)
        {
            return new StreamReader(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", file));
        }

        private class DocumentAutoDataAttribute : AutoDataAttribute
        {
            public DocumentAutoDataAttribute() : base(Setup) { }

            private static Fixture Setup()
            {
                Fixture fixture = new Fixture();
                fixture.Customizations.Add(new OmitXmlPropertiesSpecimenBuilder());
                return fixture;
            }

            private class OmitXmlPropertiesSpecimenBuilder : ISpecimenBuilder
            {
                public object Create(object request, ISpecimenContext context)
                {
                    PropertyInfo property = request as PropertyInfo;
                    bool isXmlProperty = property != null && property.Name.StartsWith("Xml");
                    return isXmlProperty ? (object)new OmitSpecimen() : new NoSpecimen();
                }
            }
        }

    }
}
