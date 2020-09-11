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
    [Equals(DoNotAddEqualityOperators = true)]
    [XmlType]
    public class ToolSpecific : ICollectable
    {
        private List<XElement> contents = new List<XElement>();

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
        public List<XElement> Contents
        {
            get => contents;
            set => contents = new List<XElement>(value);
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
        /// <param name="contents">XML elements describing the tool-specific data</param>
        public ToolSpecific(string tool, string version, params XElement[] contents)
        {
            Tool = tool;
            Version = version;
            Contents = contents.ToList();
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
