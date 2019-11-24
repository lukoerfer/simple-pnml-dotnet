using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture.NUnit3;
using Moq;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class ConnectableTest
    {
        [Test, AutoData]
        public void CanConvertConnectableToId(string id)
        {
            Connectable connectable = Mock.Of<Connectable>(obj => obj.Id == id);
            string result = connectable;
            Assert.AreEqual(id, result);
        }
    }
}
