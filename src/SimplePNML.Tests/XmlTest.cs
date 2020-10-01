using AutoFixture;
using AutoFixture.NUnit3;

using KellermanSoftware.CompareNetObjects;

using NUnit.Framework;

using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace SimplePNML.Tests
{
    public class XmlTest
    {
        private static XmlSerializer serializer;

        [OneTimeSetUp]
        public static void Setup()
        {
            serializer = new XmlSerializer(typeof(Document));
        }

        [Test, GeneratedDocument]
        public void Serialization_GeneratedDocument_(Document expected)
        {
            using var stream = new MemoryStream();
            serializer.Serialize(Console.Out, expected);
        }

        [Test, GeneratedDocument]
        public void GeneratedDocumentEqualsAfterSerialization(Document expected)
        {
            using var stream = new MemoryStream();
            serializer.Serialize(stream, expected);
            stream.Position = 0;

            var actual = (Document) serializer.Deserialize(stream);
            var result = new CompareLogic().Compare(expected, actual);

            Assert.IsTrue(result.AreEqual, result.DifferencesString);
        }

        [TestCase("Resources/Example/philo.pnml")]
        [TestCase("Resources/Example/piscine.pnml")]
        [TestCase("Resources/Example/token-ring.pnml")]
        public void Deserialization_ExampleDocument_DoesNotFail(string file)
        {
            using var reader = new StreamReader(Path.Combine(TestContext.CurrentContext.TestDirectory, file));

            Assert.DoesNotThrow(() =>
            {
                serializer.Deserialize(reader);
            });
        }

        private class GeneratedDocumentAttribute : AutoDataAttribute
        {
            public GeneratedDocumentAttribute() : base(CreateFixture) { }

            private static Fixture CreateFixture()
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
