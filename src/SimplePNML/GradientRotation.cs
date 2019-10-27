using System.Xml.Serialization;

namespace SimplePNML
{
    public enum GradientRotation
    {
        [XmlEnum("vertical")]
        Vertical,
        [XmlEnum("horizontal")]
        Horizontal,
        [XmlEnum("diagonal")]
        Diagonal
    }
}
