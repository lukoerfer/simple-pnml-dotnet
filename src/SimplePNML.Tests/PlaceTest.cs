using NUnit.Framework;

using System;
using System.Linq;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class PlaceTest
    {
        private Place place;

        [SetUp]
        public void Setup()
        {
            place = new Place();
        }

        [Test]
        public void GetId_NewInstance_IsNotNullOrEmpty()
        {
            string id = place.Id;

            Assert.IsNotNull(id);
            Assert.IsNotEmpty(id);
        }

        [Test]
        public void SetId_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                place.Id = null;
            });
        }

        [Test]
        public void SetName_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                place.Name = null;
            });
        }

        [Test]
        public void SetGraphics_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                place.Graphics = null;
            });
        }

        [Test]
        public void SetInitialMarking_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                place.InitialMarking = null;
            });
        }

        [Test]
        public void SetToolSpecifics_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                place.ToolSpecifics = null;
            });
        }

        [Test]
        public void Collect_NewInstance_ContainsMoreThanOneElement()
        {
            Assert.Greater(place.Collect().Count(), 1);
        }

        [Test]
        public void Collect_WithAdditionalToolSpecific_ContainsOneMoreElement()
        {
            var countBefore = place.Collect().Count();

            place.ToolSpecifics.Add(new ToolSpecific());

            Assert.Greater(place.Collect().Count(), countBefore);
        }
    }
}
