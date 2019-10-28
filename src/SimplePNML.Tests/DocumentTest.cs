using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AutoFixture;
using AutoFixture.NUnit3;
using KellermanSoftware.CompareNetObjects;
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
                Assert.AreEqual(document, result, new CompareLogic().Compare(document, result).DifferencesString);
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
                fixture.Behaviors.OfType<ThrowingRecursionBehavior>()
                    .ToList().ForEach(behavior => fixture.Behaviors.Remove(behavior));
                fixture.Behaviors.Add(new OmitOnRecursionBehavior());
                fixture.Customize<Line>(customize => 
                    customize.Without(line => line.ColorValue));
                fixture.Customize<Fill>(customize => 
                    customize.Without(fill => fill.ColorValue)
                        .Without(fill => fill.GradientColorValue)
                        .Without(fill => fill.ImageValue));
                fixture.Customize<ToolSpecific>(customize =>
                    customize.Without(toolSpecific => toolSpecific.Content));
                return fixture;
            }
        }
    }
}
