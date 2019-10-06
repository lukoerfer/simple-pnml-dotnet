using Moq;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class ArcTest
    {
        [TestCase(null), TestCase(""), TestCase("   "), TestCase("test")]
        public void CreateGivesValidId(string id)
        {
            Arc arc = Arc.Create(id);
            Assert.NotNull(arc.Id);
            Assert.IsNotEmpty(arc.Id);
            Assert.IsFalse(string.IsNullOrWhiteSpace(arc.Id));
        }

        [Test, XmlAutoData]
        public void CanConnect(Arc arc, string sourceId, string targetId)
        {
            IConnectable source = Mock.Of<IConnectable>(obj => obj.Id == sourceId);
            IConnectable target = Mock.Of<IConnectable>(obj => obj.Id == targetId);
            arc.Connect(source, target);
            Assert.AreEqual(sourceId, arc.Source);
            Assert.AreEqual(targetId, arc.Target);
        }

        [Test, XmlAutoData]
        public void CanSetSource(Arc arc, string sourceId)
        {
            IConnectable source = Mock.Of<IConnectable>(obj => obj.Id == sourceId);
            arc.SetSource(source);
            Assert.AreEqual(sourceId, arc.Source);
        }

        [Test, XmlAutoData]
        public void CanSetTarget(Arc arc, string targetId)
        {
            IConnectable target = Mock.Of<IConnectable>(obj => obj.Id == targetId);
            arc.SetTarget(target);
            Assert.AreEqual(targetId, arc.Target);
        }

    }
}
