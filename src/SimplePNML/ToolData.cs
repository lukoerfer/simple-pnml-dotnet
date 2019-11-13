using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// 
    /// </summary>
    [Equals]
    [XmlType]
    public class ToolData
    {
        /// <summary>
        /// Gets or sets the name of the tool
        /// </summary>
        [XmlAttribute]
        public string Tool { get; set; }

        /// <summary>
        /// Gets or sets the version of the tool
        /// </summary>
        [XmlAttribute]
        public string Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlAnyElement]
        public List<XElement> Content { get; set; } = new List<XElement>();

        /// <summary>
        /// 
        /// </summary>
        public ToolData() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tool"></param>
        /// <param name="version"></param>
        /// <param name="content"></param>
        public ToolData(string tool, string version, params XElement[] content)
        {
            Tool = tool;
            Version = version;
            Content = content.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tool"></param>
        /// <param name="version"></param>
        /// <param name="content"></param>
        public ToolData(string tool, string version, params (string, string)[] content)
        {
            Tool = tool;
            Version = version;
            Content = content.Select(element => new XElement(element.Item1, element.Item2)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns>A reference to itself</returns>
        public ToolData WithContent(params XElement[] content)
        {
            Content = content.ToList();
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns>A reference to itself</returns>
        public ToolData WithContent(params (string, string)[] content)
        {
            Content = content.Select(element => new XElement(element.Item1, element.Item2)).ToList();
            return this;
        }
    }
}
