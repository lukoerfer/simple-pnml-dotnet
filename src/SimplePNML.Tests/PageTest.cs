
using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class PageTest
    {
        [TestCase(null), TestCase(""), TestCase("   "), TestCase("test")]
        public void CreateGivesValidId(string id)
        {
            Page page = Page.Create(id);
            Assert.NotNull(page.Id);
            Assert.IsNotEmpty(page.Id);
            Assert.IsFalse(string.IsNullOrWhiteSpace(page.Id));
        }

        [Test, XmlAutoData]
        public void WithPagesAddsPages(Page page1, Page page2)
        {
            Page page = new Page();
            Assert.AreEqual(2, page.WithPages(page1, page2).Pages.Count);
        }

        [Test, XmlAutoData]
        public void WithArcsAddsPages(Arc arc1, Arc arc2)
        {
            Page page = new Page();
            Assert.AreEqual(2, page.WithArcs(arc1, arc2).Arcs.Count);
        }

        [Test, XmlAutoData]
        public void WithPlacesAddsPages(Place place1, Place place2)
        {
            Page page = new Page();
            Assert.AreEqual(2, page.WithPlaces(place1, place2).Places.Count);
        }

        [Test, XmlAutoData]
        public void WithTransitionsAddsTransitions(Transition transition1, Transition transition2)
        {
            Page page = new Page();
            Assert.AreEqual(2, page.WithTransitions(transition1, transition2).Transitions.Count);
        }
    }
}
