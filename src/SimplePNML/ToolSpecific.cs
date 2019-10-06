using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SimplePNML
{
    [XmlType]
    public class ToolSpecific
    {
        [XmlAttribute]
        public string Tool { get; set; }

        [XmlAttribute]
        public string Version { get; set; }

        [XmlAnyElement]
        public XmlElement[] Content { get; set; }
    }
}
