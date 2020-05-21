using System.Linq;
using System.Xml.Linq;
using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class ToolSpecificTest
    {
        [Test]
        public void CanCreate()
        {
            string tool = "MyTool", version = "1.0";
            ToolSpecific toolSpecific = new ToolSpecific(tool, version);
            Assert.AreEqual(tool, toolSpecific.Tool);
            Assert.AreEqual(version, toolSpecific.Version);
            Assert.IsNotNull(toolSpecific.Content);
            Assert.IsEmpty(toolSpecific.Content);
            Assert.AreEqual(1, toolSpecific.Collect().Count());
        }

        [Test]
        public void CanCreateWithContent()
        {
            string tool = "MyTool", version = "1.0";
            ToolSpecific toolSpecific = new ToolSpecific(tool, version);

        }
    }
}
