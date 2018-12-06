using System.Collections.Generic;
using System.Xml.Serialization;

namespace SimplePNML
{
    [XmlType("net")]
    public class Net
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlElement("page")]
        public List<Page> Pages { get; set; } = new List<Page>();
    }
}
