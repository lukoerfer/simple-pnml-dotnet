using System;
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
        public void CannotSetArcsToNull()
        {
            Page page = new Page();
            Assert.Throws<ArgumentNullException>(() =>
            {
                page.Arcs = null;
            });
        }

        
    }
}
