using System.Xml.Serialization;

namespace SimplePNML
{
    [XmlType("transition")]
    public class Transition
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("name")]
        public Label Name { get; set; }

        [XmlElement("graphics")]
        public Graphics Graphics { get; set; }
    }
}
