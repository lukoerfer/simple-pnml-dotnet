using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class TransitionTest
    {
        [TestCase(null), TestCase("test-id")]
        public void GeneratesIdIfNull(string id)
        {
            Transition transition = new Transition(id);
            Assert.NotNull(transition.Id);
        }

        [Test, AutoData]
        public void CanCreateTransition(string name)
        {
            NodeGraphics node = new NodeGraphics();
            Transition transition = new Transition()
            {
                Name = name,
                Graphics = node
            };
        }
    }
}
