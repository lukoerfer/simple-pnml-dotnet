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
            IConnectable connectable = Mock.Of<IConnectable>(obj => obj.Id == id);
            string result = connectable;
            Assert.AreEqual(id, result);
        }
    }
}
