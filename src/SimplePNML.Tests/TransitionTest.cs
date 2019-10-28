using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class TransitionTest
    {
        [TestCase(null), TestCase(""), TestCase("   "), TestCase("test")]
        public void CreateGivesValidId(string id)
        {
            Transition transition = new Transition(id);
            Assert.NotNull(transition.Id);
            Assert.IsNotEmpty(transition.Id);
            Assert.IsFalse(string.IsNullOrWhiteSpace(transition.Id));
        }
    }
}
