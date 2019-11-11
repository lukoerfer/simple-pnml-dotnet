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
            Connectable source = Mock.Of<Connectable>(obj => obj.Id == sourceId);
            Connectable target = Mock.Of<Connectable>(obj => obj.Id == targetId);
            Arc arc = new Arc();
            arc.Connect(source, target);
            Assert.AreEqual(sourceId, arc.Source);
            Assert.AreEqual(targetId, arc.Target);
        }

        [Test, AutoData]
        public void CanConnectFluently(string sourceId, string targetId)
        {
            Connectable source = Mock.Of<Connectable>(obj => obj.Id == sourceId);
            Connectable target = Mock.Of<Connectable>(obj => obj.Id == targetId);
            Arc arc = new Arc().Connecting(source, target);
            Assert.AreEqual(sourceId, arc.Source);
            Assert.AreEqual(targetId, arc.Target);
        }

        [Test, AutoData]
        public void CanSetSourceFluently(string sourceId)
        {
            Connectable source = Mock.Of<Connectable>(obj => obj.Id == sourceId);
            Arc arc = new Arc().WithSource(source);
            Assert.AreEqual(sourceId, source.Id);
        }

        [Test, AutoData]
        public void CanSetTargetFluently(string targetId)
        {
            Connectable target = Mock.Of<Connectable>(obj => obj.Id == targetId);
            Arc arc = new Arc().WithTarget(target);
            Assert.AreEqual(targetId, target.Id);
        }

        [Test, AutoData]
        public void CanSetInscription(int inscription)
        {
            Arc arc = new Arc()
            {
                Inscription = inscription
            };
            Assert.AreEqual(inscription.ToString(), arc.Inscription.Text);
        }
    }
}
