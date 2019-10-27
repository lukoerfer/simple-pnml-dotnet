using System.Xml.Serialization;

namespace SimplePNML
{
    public enum LineStyle
    {
        [XmlEnum("solid")]
        Solid,
        [XmlEnum("dash")]
        Dash,
        [XmlEnum("dot")]
        Dot
    }
}
