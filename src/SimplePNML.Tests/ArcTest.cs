using AutoFixture.NUnit3;
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
            Arc arc = new Arc(id);
            Assert.NotNull(arc.Id);
            Assert.IsNotEmpty(arc.Id);
            Assert.IsFalse(string.IsNullOrWhiteSpace(arc.Id));
        }

        [Test, AutoData]
        public void CanConnect(string sourceId, string targetId)
        {
            Arc arc = new Arc();
            IConnectable source = Mock.Of<IConnectable>(obj => obj.Id == sourceId);
            IConnectable target = Mock.Of<IConnectable>(obj => obj.Id == targetId);
            arc.Connect(source, target);
            Assert.AreEqual(sourceId, arc.Source);
            Assert.AreEqual(targetId, arc.Target);
        }

        [Test, AutoData]
        public void CanSetSource(string sourceId)
        {
            Arc arc = new Arc();
            IConnectable source = Mock.Of<IConnectable>(obj => obj.Id == sourceId);
            arc.SetSource(source);
            Assert.AreEqual(sourceId, arc.Source);
        }

        [Test, AutoData]
        public void CanSetTarget(string targetId)
        {
            Arc arc = new Arc();
            IConnectable target = Mock.Of<IConnectable>(obj => obj.Id == targetId);
            arc.SetTarget(target);
            Assert.AreEqual(targetId, arc.Target);
        }

    }
}
