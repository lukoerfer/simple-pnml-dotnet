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
            ToolData data = new ToolData(tool, version);
            Assert.AreEqual(tool, data.Tool);
            Assert.AreEqual(version, data.Version);
            Assert.IsEmpty(data.Content);
        }

        [Test, AutoData]
        public void CanSetToolAndVersionFluently(string tool, string version)
        {
            ToolData data = new ToolData()
                .ForTool(tool, version);
            Assert.AreEqual(tool, data.Tool);
            Assert.AreEqual(version, data.Version);
        }

        [Test, AutoData]
        public void CanAddContentFluently(string element, string value)
        {
            XElement content = new XElement(element, value);
            ToolData data = new ToolData()
                .WithContent(content);
            Assert.IsNotEmpty(data.Content);
        }

        [Test, AutoData]
        public void CanAddContentFluentlyViaTuples(string element, string value)
        {
            ToolData data = new ToolData()
                .WithContent((element, value));
            Assert.IsNotEmpty(data.Content);
        }
    }
}
