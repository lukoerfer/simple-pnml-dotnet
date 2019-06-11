using Moq;
using NUnit.Framework;
using System;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class ArcTest
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("test")]
        public void IdNeverNullOnSetup(string value)
        {
            Arc arc = Arc.Create(value);
            Assert.NotNull(arc.Id);
        }

        [Test]
        public void CanConnect()
        {
            Arc arc = new Arc();
            IConnectable source = Mock.Of<IConnectable>(obj => obj.Id == "source");
            IConnectable target = Mock.Of<IConnectable>(obj => obj.Id == "target");
            arc.Connect(source, target);
            Assert.AreEqual(arc.Source, "source");
            Assert.AreEqual(arc.Target, "target");
        }

        private readonly string TEST_SERIALIZATION = @"
            
        ";

        [Test]
        [Ignore("Not implemented")]
        public void CanSerialize()
        {
            Arc arc = new Arc()
            {
                Id = "id",
                Source = "source",
                Target = "target"
            };
            string serialized = "";
            Assert.AreEqual(TEST_SERIALIZATION, serialized);
        }

        [Test]
        [Ignore("Not implemented")]
        public void CanDeserialize()
        {

        }

    }
}
