using System.Xml.Linq;
using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class ToolDataTest
    {
        [Test, AutoData]
        public void CanCreateToolData(string tool, string version)
        {
            ToolSpecific data = new ToolSpecific(tool, version);
            Assert.AreEqual(tool, data.Tool);
            Assert.AreEqual(version, data.Version);
            Assert.IsNotNull(data.Content);
            Assert.IsEmpty(data.Content);
        }

        
    }
}
