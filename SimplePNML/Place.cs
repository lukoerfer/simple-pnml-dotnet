using System.Xml.Serialization;

namespace SimplePNML
{
    [XmlType("place")]
    public class Place : IConnectable
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("name")]
        public Label Name { get; set; }

        [XmlElement("graphics")]
        public Graphics Graphics { get; set; }

        [XmlElement("initialMarking")]
        public Label InitialMarking { get; set; }

    }
}
