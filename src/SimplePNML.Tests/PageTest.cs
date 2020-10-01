using NUnit.Framework;

using System;
using System.Linq;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class PageTest
    {
        private Page page;

        [SetUp]
        public void Setup()
        {
            page = new Page();
        }

        [Test]
        public void GetId_NewInstance_NotNullOrEmpty()
        {
            string id = page.Id;

            Assert.IsNotNull(id);
            Assert.IsNotEmpty(id);
        }

        [Test]
        public void SetId_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                page.Id = null;
            });
        }

        [Test]
        public void SetName_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                page.Name = null;
            });
        }

        [Test]
        public void SetGraphics_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                page.Graphics = null;
            });
        }

        [Test]
        public void SetPages_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                page.Pages = null;
            });
        }

        [Test]
        public void SetPlaces_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                page.Places = null;
            });
        }

        [Test]
        public void SetTransitions_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                page.Transitions = null;
            });
        }

        [Test]
        public void SetArcs_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                page.Arcs = null;
            });
        }

        [Test]
        public void SetToolSpecifics_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                page.ToolSpecifics = null;
            });
        }

        [Test]
        public void Collect_NewInstance_ContainsMoreThanOneElement()
        {
            Assert.Greater(page.Collect().Count(), 1);
        }

        [Test]
        public void Collect_WithAdditionalSubPage_ContainsMoreElements()
        {
            var countBefore = page.Collect().Count();

            page.Pages.Add(new Page());

            Assert.Greater(page.Collect().Count(), countBefore);
        }

        [Test]
        public void Collect_WithAdditionalPlace_ContainsMoreElements()
        {
            var countBefore = page.Collect().Count();

            page.Places.Add(new Place());

            Assert.Greater(page.Collect().Count(), countBefore);
        }

        [Test]
        public void Collect_WithAdditionalTransition_ContainsMoreElements()
        {
            var countBefore = page.Collect().Count();

            page.Transitions.Add(new Transition());

            Assert.Greater(page.Collect().Count(), countBefore);
        }

        [Test]
        public void Collect_WithAdditionalArc_ContainsMoreElements()
        {
            var countBefore = page.Collect().Count();

            page.Arcs.Add(new Arc());

            Assert.Greater(page.Collect().Count(), countBefore);
        }

        [Test]
        public void Collect_WithAdditionalToolSpecific_ContainsMoreElements()
        {
            var countBefore = page.Collect().Count();

            page.ToolSpecifics.Add(new ToolSpecific());

            Assert.Greater(page.Collect().Count(), countBefore);
        }

    }
}
