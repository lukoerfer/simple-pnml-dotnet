using NUnit.Framework;

using System;
using System.Linq;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class DocumentTest
    {
        private Document document;

        [SetUp]
        public void Setup()
        {
            document = new Document();
        }

        [Test]
        public void SetNets_NullValue_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                document.Nets = null;
            });
        }

        [Test]
        public void Collect_NewInstance_ContainsOneElement()
        {
            Assert.AreEqual(1, document.Collect().Count());
        }

        [Test]
        public void Collect_WithAdditionalNet_ContainsMoreElements()
        {
            var countBefore = document.Collect().Count();

            document.Nets.Add(new Net());

            Assert.Greater(document.Collect().Count(), countBefore);
        }
    }
}
