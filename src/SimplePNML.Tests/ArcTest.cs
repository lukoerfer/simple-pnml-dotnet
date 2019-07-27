using System.IO;
using System.Xml.Serialization;

using AutoFixture.NUnit3;
using Moq;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class ArcTest
    {
        [Test, AutoData]
        public void EqualsAfterSerialization(Arc input)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Arc));
            MemoryStream stream = new MemoryStream();
            serializer.Serialize(stream, input);
            stream.Position = 0;
            Arc output = (Arc)serializer.Deserialize(stream);
            Assert.IsTrue(input.Equals(output));
        }

        [TestCase(null), TestCase(""), TestCase("   "), TestCase("test")]
        public void CorrectIdOnSetup(string value)
        {
            Arc arc = Arc.Create(id: value);
            Assert.NotNull(arc.Id);
            Assert.IsNotEmpty(arc.Id);
            Assert.IsFalse(string.IsNullOrWhiteSpace(arc.Id));
        }

        [Test]
        public void CanConnect()
        {
            Arc arc = new Arc();
            IConnectable source = Mock.Of<IConnectable>(obj => obj.Id == "source");
            IConnectable target = Mock.Of<IConnectable>(obj => obj.Id == "target");
            arc.Connect(source, target);
            Assert.AreEqual("source", arc.Source);
            Assert.AreEqual("target", arc.Target);
        }

        [Test]
        public void CanSetSource()
        {
            Arc arc = new Arc();
            IConnectable source = Mock.Of<IConnectable>(obj => obj.Id == "source");
            arc.SetSource(source);
            Assert.AreEqual("source", arc.Source);
        }

        [Test]
        public void CanSetTarget()
        {
            Arc arc = new Arc();
            IConnectable target = Mock.Of<IConnectable>(obj => obj.Id == "target");
            arc.SetTarget(target);
            Assert.AreEqual("target", arc.Target);
        }

    }
}
