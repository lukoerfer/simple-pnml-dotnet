using System.IO;
using System.Linq;
using System.Xml.Serialization;

using AutoFixture;
using AutoFixture.NUnit3;

using KellermanSoftware.CompareNetObjects;

using NUnit.Framework;

using SimplePNML.Tests.Resources;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class DocumentTest
    {
        [Ignore("")]
        [Test, DocumentAutoData]
        public void GeneratedDocumentEqualsAfterSerialization(Document document)
        {
            var serializer = new XmlSerializer(typeof(Document));
            using (var stream = new MemoryStream())
            {
                serializer.Serialize(stream, document);
                stream.Position = 0;
                var result = (Document) serializer.Deserialize(stream);
                Assert.AreEqual(document, result, new CompareLogic().Compare(document, result).DifferencesString);
            }
        }

        [Test]
        public void CanImportExampleDocument()
        {
            var serializer = new XmlSerializer(typeof(Document));
            using (var reader = Resource.Read("Example.pnml"))
            {
                var document = (Document) serializer.Deserialize(reader);
                Assert.AreEqual(1, document.Nets.Count);
            }
        }

        private class DocumentAutoDataAttribute : AutoDataAttribute
        {
            public DocumentAutoDataAttribute() : base(Setup) { }

            private static Fixture Setup()
            {
                var fixture = new Fixture();
                fixture.Behaviors.OfType<ThrowingRecursionBehavior>()
                    .ToList().ForEach(behavior => fixture.Behaviors.Remove(behavior));
                fixture.Behaviors.Add(new OmitOnRecursionBehavior());
                fixture.Customize<ToolSpecific>(customize =>
                    customize.Without(toolSpecific => toolSpecific.Contents));
                return fixture;
            }
        }
    }
}
