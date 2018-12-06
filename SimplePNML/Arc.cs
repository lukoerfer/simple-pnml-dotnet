using System.Xml.Serialization;

namespace SimplePNML
{
    [XmlType("arc")]
    public class Arc
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("source")]
        public string Source { get; set; }

        [XmlAttribute("target")]
        public string Target { get; set; }

        [XmlElement("inscription")]
        public Label Inscription { get; set; }

    }
}
