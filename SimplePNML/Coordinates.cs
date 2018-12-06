using System.Xml.Serialization;

namespace SimplePNML
{
    public class Coordinates
    {
        [XmlAttribute("x")]
        public int X { get; set; }

        [XmlAttribute("y")]
        public int Y { get; set; }
    }
}
