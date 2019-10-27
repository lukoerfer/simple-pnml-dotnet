using System.Xml.Serialization;

namespace SimplePNML
{
    public enum FontAlign
    {
        [XmlEnum("left")]
        Left,
        [XmlEnum("center")]
        Center,
        [XmlEnum("right")]
        Right
    }
}
