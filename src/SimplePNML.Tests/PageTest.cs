using Moq;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class PageTest
    {
        [TestCase(null), TestCase(""), TestCase("   "), TestCase("test")]
        public void DefaultsToValidId(string id)
        {
            Page page = new Page(id);
            Assert.NotNull(page.Id);
            Assert.IsNotEmpty(page.Id);
            Assert.IsFalse(string.IsNullOrWhiteSpace(page.Id));
        }

        [Test]
        public void WithPagesAddsPages()
        {
            Page page = new Page()
                .WithPages(new Page());
            Assert.AreEqual(1, page.Pages.Count);
        }

        [Test]
        public void WithArcsAddsArcs()
        {
            Page page = new Page()
                .WithArcs(new Arc());
            Assert.AreEqual(1, page.Arcs.Count);
        }

        [Test]
        public void WithPlacesAddsPlaces()
        {
            Page page = new Page()
                .WithPlaces(new Place());
            Assert.AreEqual(1, page.Places.Count);
        }

        [Test]
        public void WithTransitionsAddsTransitions()
        {
            Page page = new Page()
                .WithTransitions(new Transition());
            Assert.AreEqual(1, page.Transitions.Count);
        }
    }
}
