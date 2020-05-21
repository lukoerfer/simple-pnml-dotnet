using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes tool-specific data
    /// </summary>
    [Equals]
    [XmlType]
    public class ToolSpecific : ICollectable
    {
        private List<XElement> content;

        /// <summary>
        /// Gets or sets the name of the tool
        /// </summary>
        [XmlAttribute]
        public string Tool { get; set; } = "";

        /// <summary>
        /// Gets or sets the version of the tool
        /// </summary>
        [XmlAttribute]
        public string Version { get; set; } = "";

        /// <summary>
        /// Gets or sets the XML elements describing the tool data
        /// </summary>
        [XmlAnyElement]
        public IList<XElement> Content
        {
            get => content ?? (content = new List<XElement>());
            set => content = new List<XElement>(value);
        }

        /// <summary>
        /// Creates a new tool-specific data
        /// </summary>
        public ToolSpecific() { }

        /// <summary>
        /// Creates a new tool-specific data
        /// </summary>
        /// <param name="tool">The tool name</param>
        /// <param name="version">The tool version</param>
        /// <param name="content">XML elements describing the tool-specific data</param>
        public ToolSpecific(string tool, string version, params XElement[] content)
        {
            Tool = tool;
            Version = version;
            Content = content.ToList();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            yield return this;
        }
    }
}
