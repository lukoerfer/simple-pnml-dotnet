using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SimplePNML
{
    public enum FontDecoration
    {
        [XmlEnum("underline")]
        Underline,
        [XmlEnum("overline")]
        Overline,
        [XmlEnum("line-through")]
        LineThrough

    }
}
