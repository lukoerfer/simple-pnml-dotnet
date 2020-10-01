using NUnit.Framework;

using System;
using System.Linq;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class NetTest
    {
        private Net net;

        [SetUp]
        public void Setup()
        {
            net = new Net();
        }

        [Test]
        public void GetId_NewInstance_NotNullOrEmpty()
        {
            string id = net.Id;

            Assert.IsNotNull(id);
            Assert.IsNotEmpty(id);
        }

        [Test]
        public void GetType_NewInstance_NotNullOrEmpty()
        {
            string type = net.Type;

            Assert.IsNotNull(type);
            Assert.IsNotEmpty(type);
        }

        [Test]
        public void SetId_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                net.Id = null;
            });
        }

        [Test]
        public void SetType_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                net.Type = null;
            });
        }

        [Test]
        public void SetName_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                net.Name = null;
            });
        }

        [Test]
        public void SetPages_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                net.Pages = null;
            });
        }

        [Test]
        public void Collect_NewInstance_ContainsMoreThenOneElement()
        {
            Assert.Greater(net.Collect().Count(), 1);
        }

        [Test]
        public void Collect_WithAdditionalPage_ContainsMoreElements()
        {
            var countBefore = net.Collect().Count();

            net.Pages.Add(new Page());

            Assert.Greater(net.Collect().Count(), countBefore);
        }
    }
}
