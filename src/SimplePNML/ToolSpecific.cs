using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// 
    /// </summary>
    [Equals]
    [XmlType]
    public class ToolSpecific
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
        public XmlElement[] Content { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ToolSpecific() : this(null, null) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tool"></param>
        /// <param name="version"></param>
        /// <param name="content"></param>
        public ToolSpecific(string tool, string version, params XmlElement[] content)
        {
            Tool = tool;
            Version = version;
            Content = content;
        }
    }
}
