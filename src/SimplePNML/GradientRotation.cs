using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SimplePNML
{
    public enum Gradient
    {
        [XmlEnum("vertical")]
        Vertical,
        [XmlEnum("horizontal")]
        Horizontal,
        [XmlEnum("diagonal")]
        Diagonal
    }
}
