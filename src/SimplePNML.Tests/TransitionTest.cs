using NUnit.Framework;

using System;
using System.Linq;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class TransitionTest
    {
        private Transition transition;

        [SetUp]
        public void Setup()
        {
            transition = new Transition();
        }

        [Test]
        public void GetId_NewInstance_NotNullOrEmpty()
        {
            string id = transition.Id;

            Assert.IsNotNull(id);
            Assert.IsNotEmpty(id);
        }

        [Test]
        public void SetId_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                transition.Id = null;
            });
        }

        [Test]
        public void SetName_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                transition.Name = null;
            });
        }

        [Test]
        public void SetGraphics_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                transition.Graphics = null;
            });
        }

        [Test]
        public void SetToolSpecifics_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                transition.ToolSpecifics = null;
            });
        }

        [Test]
        public void Collect_NewInstance_ContainsMoreThanOneElement()
        {
            Assert.Greater(transition.Collect().Count(), 1);
        }

        [Test]
        public void Collect_WithAdditionalToolSpecific_ContainsOneMoreElement()
        {
            var countBefore = transition.Collect().Count();

            transition.ToolSpecifics.Add(new ToolSpecific());

            Assert.Greater(transition.Collect().Count(), countBefore);
        }
    }
}
