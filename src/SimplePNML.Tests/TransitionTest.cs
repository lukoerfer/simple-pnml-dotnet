using AutoFixture.NUnit3;
using NUnit.Framework;
using System.Linq;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class TransitionTest
    {
        [Test]
        public void CanCreate()
        {
            Transition transition = new Transition();
            Assert.IsNotNull(transition.Id);
            Assert.IsNotEmpty(transition.Id);
            Assert.Greater(transition.Collect().Count(), 1);
        }

        [Test]
        public void CanCreateUsingInitializer()
        {
            string id = "my-transition";
            Transition transition = new Transition()
            {
                Id = id
            };
            Assert.AreEqual(id, transition.Id);
            Assert.Greater(transition.Collect().Count(), 1);
        }
    }
}
