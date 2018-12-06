using System.Xml.Serialization;

namespace SimplePNML
{
    public class Graphics
    {
        [XmlElement("position")]
        public Coordinates Position { get; set; }

        [XmlElement("offset")]
        public Coordinates Offset { get; set; }

    }
}
