﻿using System.Collections.Generic;
using System.Linq;
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
        public List<XmlElement> Content { get; set; }

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
            Content = content.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns>A reference to itself</returns>
        public ToolSpecific WithContent(params XmlElement[] content)
        {
            Content = content.ToList();
            return this;
        }
    }
}
