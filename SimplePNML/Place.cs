using System.Xml.Serialization;

namespace SimplePNML
{
    [XmlType("place")]
    public class Place
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("name", IsNullable = true)]
        public Label Name { get; set; }

        [XmlElement("graphics", IsNullable = true)]
        public Graphics Graphics { get; set; }

        [XmlElement("initialMarking", IsNullable = true)]
        public Label InitialMarking { get; set; }

    }
}
