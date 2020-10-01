using NUnit.Framework;

using System;
using System.Linq;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class ArcTest
    {
        private Arc arc;

        [SetUp]
        public void Setup()
        {
            arc = new Arc();
        }

        [Test]
        public void GetId_NewInstance_NotNullOrEmpty()
        {
            var id = arc.Id;

            Assert.IsNotNull(id);
            Assert.IsNotEmpty(id);
        }

        [Test]
        public void SetId_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                arc.Id = null;
            });
        }

        [Test]
        public void SetSource_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                arc.Source = null;
            });
        }

        [Test]
        public void SetTarget_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                arc.Target = null;
            });
        }

        [Test]
        public void SetGraphics_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                arc.Graphics = null;
            });
        }

        [Test]
        public void SetInscription_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                arc.Inscription = null;
            });
        }

        [Test]
        public void SetToolSpecifics_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                arc.ToolSpecifics = null;
            });
        }

        [Test]
        public void Collect_NewInstance_ContainsMoreThanOneElement()
        {
            var children = arc.Collect();

            Assert.Greater(children.Count(), 1);
        }

        [Test]
        public void Collect_WithAdditionalToolSpecific_ContainsMoreElements()
        {
            var countBefore = arc.Collect().Count();

            arc.ToolSpecifics.Add(new ToolSpecific());

            Assert.Greater(arc.Collect().Count(), countBefore);
        }
    }
}
