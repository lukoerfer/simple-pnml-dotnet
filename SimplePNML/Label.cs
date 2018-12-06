using System.Xml.Serialization;

namespace SimplePNML
{
    public class Label
    {
        [XmlElement("text")]
        public string Text { get; set; }

        [XmlElement("graphics")]
        public Graphics Graphics { get; set; }

    }
}
